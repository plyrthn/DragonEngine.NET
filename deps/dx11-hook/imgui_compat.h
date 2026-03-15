#pragma once
// compat shims for addon libs that target older imgui versions
#include "imgui.h"
#include "imgui_internal.h"

#ifndef ImGuiKeyModFlags
typedef ImGuiKeyChord ImGuiKeyModFlags;
enum ImGuiKeyModFlags_ {
    ImGuiKeyModFlags_None  = 0,
    ImGuiKeyModFlags_Ctrl  = ImGuiMod_Ctrl,
    ImGuiKeyModFlags_Shift = ImGuiMod_Shift,
    ImGuiKeyModFlags_Alt   = ImGuiMod_Alt,
    ImGuiKeyModFlags_Super = ImGuiMod_Super
};
#endif

// _c struct typedefs provided by cimgui.h (1.92.6+)

// CaptureMouseFromApp was renamed to SetNextFrameWantCaptureMouse in 1.89.x and removed in 1.92.x
#if IMGUI_VERSION_NUM >= 19200
namespace ImGui {
    inline void CaptureMouseFromApp(bool want_capture_mouse = true) {
        SetNextFrameWantCaptureMouse(want_capture_mouse);
    }
}
#endif
