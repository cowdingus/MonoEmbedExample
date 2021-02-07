using System;
using System.Runtime.InteropServices;

[DllImport ("__Internal", EntryPoint="exposedCFunction")]
static extern void ExposedCFunction();

namespace CSharpExe
{
	class CSharpExe
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-- CSharpExe");
		}
	}
}
