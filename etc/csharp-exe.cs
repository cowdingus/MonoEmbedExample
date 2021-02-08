using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CSharpExe
{
	class ExposedCInterface
	{
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public extern static void ExposedCFunction();
	}

	class CSharpExe
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-- CSharpExe");
			Console.WriteLine("-- Calling ExposedCInterface.ExposedCFunction");
			ExposedCInterface.ExposedCFunction();
		}
	}
}
