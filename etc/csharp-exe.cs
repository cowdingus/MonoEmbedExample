using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CSharpExe
{
	class ExposedCInterface
	{
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public extern static void ExposedCFunction1();

		[DllImport ("__Internal", EntryPoint="ExposedCFunction")]
		public extern static void ExposedCFunction2();
	}

	class CSharpExe
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-- CSharpExe");
			Console.WriteLine("-- Calling ExposedCInterface.ExposedCFunction1");
			ExposedCInterface.ExposedCFunction1();
			Console.WriteLine("-- Calling ExposedCInterface.ExposedCFunction2");
			ExposedCInterface.ExposedCFunction2();
		}
	}
}
