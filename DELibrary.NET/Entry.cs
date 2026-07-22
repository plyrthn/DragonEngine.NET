using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DragonEngineLibrary
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int InitializeDelegate(IntPtr gameDirectory);

    public static class Entrya
    {
        public static int Initialize(IntPtr gameDirectory)
        {
            string directory = Marshal.PtrToStringUni(gameDirectory);

            Process.Start("explorer", "http://google.com");
            Console.WriteLine($"Environment.Version: {Environment.Version}");
            Console.WriteLine($"RuntimeInformation.FrameworkDescription: {RuntimeInformation.FrameworkDescription}");

            // Do your startup here.

            return 0;
        }
    }
}
