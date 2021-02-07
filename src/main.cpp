#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>

int main(int argc, char *argv[])
{
	MonoDomain* domain;
	domain = mono_jit_init("MonoEmbed");

	MonoAssembly* assembly;
	assembly = mono_domain_assembly_open(domain, "csharp-exe.exe");

	if (!assembly)
		throw "Can't load csharp-exe.exe";

	auto retval = mono_jit_exec(domain, assembly, argc - 1, argv + 1);

	mono_jit_cleanup(domain);
}
