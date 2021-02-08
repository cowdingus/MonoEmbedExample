#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>

#include <iostream>

void exposedCFunction()
{
	std::cout << "== exposedCFunction is called" << std::endl;
}

int main(int argc, char *argv[])
{
	MonoDomain* domain;
	domain = mono_jit_init("MonoEmbed");

	if (!domain)
	{
		std::cerr << "JIT INIT ERROR" << std::endl;
		throw "Can't initialize Mono JIT";
	}
	else
		std::cout << "Mono JIT initialized" << std::endl;

	MonoAssembly* assembly;
	assembly = mono_domain_assembly_open(domain, "csharp-exe.exe");

	if (!assembly)
	{
		std::cerr << "ASSEMBLY LOAD ERROR" << std::endl;
		throw "Can't load csharp-exe.exe";
	}
	else
		std::cout << "csharp-exe.exe loaded" << std::endl;

	mono_add_internal_call("CSharpExe.ExposedCInterface::ExposedCFunction", reinterpret_cast<void*>(exposedCFunction));

	auto retval = mono_jit_exec(domain, assembly, argc - 1, argv + 1);

	mono_jit_cleanup(domain);

	return retval;
}
