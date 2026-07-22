using System;
using System.Runtime.InteropServices;

namespace DragonEngineLibrary
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int InitializeDelegate(IntPtr gameDirectory);
}
