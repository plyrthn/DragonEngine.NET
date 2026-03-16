// DELibInitializer.asi wrapper
// Patches AMSI (AmsiInitialize + AmsiScanBuffer) before loading the real
// DELibInitializer which starts the CLR. Prevents MpOAV.dll from crashing
// the game process during assembly scanning.
//
// Deploy:
//   Rename original DELibInitializer.asi -> DELibInitializer_real.asi
//   Place this built DLL as DELibInitializer.asi in the same directory
//
// Build (MSVC):
//   cl /LD /O2 delib_wrapper.c /Fe:DELibInitializer.asi /link /DLL
//
// Build (MinGW cross-compile from Linux):
//   x86_64-w64-mingw32-gcc -shared -O2 -o DELibInitializer.asi delib_wrapper.c

#include <windows.h>

static void PatchAmsi(void) {
    HMODULE hAmsi = LoadLibraryW(L"amsi.dll");
    if (!hAmsi) return;

    FARPROC pInit = GetProcAddress(hAmsi, "AmsiInitialize");
    if (pInit) {
        // mov eax, 0x80004001 (E_NOTIMPL); ret
        unsigned char patch[] = { 0xB8, 0x01, 0x40, 0x00, 0x80, 0xC3 };
        DWORD old;
        if (VirtualProtect(pInit, sizeof(patch), PAGE_EXECUTE_READWRITE, &old)) {
            memcpy(pInit, patch, sizeof(patch));
            VirtualProtect(pInit, sizeof(patch), old, &old);
        }
    }

    FARPROC pScan = GetProcAddress(hAmsi, "AmsiScanBuffer");
    if (pScan) {
        // xor eax,eax; ret (S_OK)
        unsigned char patch[] = { 0x33, 0xC0, 0xC3 };
        DWORD old;
        if (VirtualProtect(pScan, sizeof(patch), PAGE_EXECUTE_READWRITE, &old)) {
            memcpy(pScan, patch, sizeof(patch));
            VirtualProtect(pScan, sizeof(patch), old, &old);
        }
    }
}

static wchar_t g_RealPath[MAX_PATH];

static DWORD WINAPI LoadRealInit(LPVOID param) {
    LoadLibraryW(g_RealPath);
    return 0;
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
    if (fdwReason == DLL_PROCESS_ATTACH) {
        DisableThreadLibraryCalls(hinstDLL);

        PatchAmsi();

        GetModuleFileNameW(hinstDLL, g_RealPath, MAX_PATH);
        wchar_t* last = wcsrchr(g_RealPath, L'\\');
        if (last) {
            wcscpy(last + 1, L"DELibInitializer_real.asi");
        }

        HANDLE h = CreateThread(NULL, 0, LoadRealInit, NULL, 0, NULL);
        if (h) CloseHandle(h);
    }
    return TRUE;
}
