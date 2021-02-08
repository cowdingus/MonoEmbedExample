using System;
using System.Runtime.InteropServices;

namespace CSharpExe
{
	/*
	class ExposedCInterface
	{
		[DllImport ("__Internal", EntryPoint="ExposedCFunction")]
		static public extern void ExposedCFunction();
	}
	*/

	class CSharpExe
	{
[DllImport ("__Internal", EntryPoint="ExposedCFunction")]
static extern void ExposedCFunction();
		static void Main(string[] args)
		{
			Console.WriteLine("-- CSharpExe");
			Console.WriteLine("-- Calling ExposedCInterface.ExposedCFunction");
			// ExposedCInterface.ExposedCFunction();
			ExposedCFunction();
		}
	}
}
