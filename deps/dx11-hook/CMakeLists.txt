cmake_minimum_required(VERSION 3.15)
cmake_policy(SET CMP0091 NEW)
project(dehook)

set(CMAKE_CXX_STANDARD 11)

if(NOT DEFINED IMGUI_SRC_DIR)
    set(IMGUI_SRC_DIR ${CMAKE_CURRENT_SOURCE_DIR}/../imgui-src)
endif()
if(NOT DEFINED HEXA_DIR)
    set(HEXA_DIR ${CMAKE_CURRENT_SOURCE_DIR}/../hexa-native)
endif()
if(NOT DEFINED MINHOOK_DIR)
    set(MINHOOK_DIR ${CMAKE_CURRENT_SOURCE_DIR}/../minhook)
endif()
if(NOT DEFINED CIMGUIZMO_DIR)
    set(CIMGUIZMO_DIR ${CMAKE_CURRENT_SOURCE_DIR}/../cimguizmo)
endif()
if(NOT DEFINED HOOK_SRC_DIR)
    set(HOOK_SRC_DIR ${CMAKE_CURRENT_SOURCE_DIR})
endif()

# MinHook (compiled from source)
add_library(minhook STATIC
    ${MINHOOK_DIR}/src/buffer.c
    ${MINHOOK_DIR}/src/hook.c
    ${MINHOOK_DIR}/src/trampoline.c
    ${MINHOOK_DIR}/src/hde/hde32.c
    ${MINHOOK_DIR}/src/hde/hde64.c
)
target_include_directories(minhook PRIVATE ${MINHOOK_DIR}/include)
set_property(TARGET minhook PROPERTY MSVC_RUNTIME_LIBRARY "MultiThreadedDLL")

# Hook DLL: imgui core + backends + hook logic, linked against Hexa's import libs at runtime
add_library(dehook SHARED
    ${IMGUI_SRC_DIR}/imgui.cpp
    ${IMGUI_SRC_DIR}/imgui_draw.cpp
    ${IMGUI_SRC_DIR}/imgui_tables.cpp
    ${IMGUI_SRC_DIR}/imgui_widgets.cpp
    ${IMGUI_SRC_DIR}/imgui_impl_dx11.cpp
    ${IMGUI_SRC_DIR}/imgui_impl_dx12.cpp
    ${IMGUI_SRC_DIR}/imgui_impl_win32.cpp
    ${HOOK_SRC_DIR}/dx11_hook.cpp
)

target_include_directories(dehook PRIVATE
    ${IMGUI_SRC_DIR}
    ${CIMGUIZMO_DIR}/ImGuizmo
    ${MINHOOK_DIR}/include
)

target_compile_definitions(dehook PRIVATE IMGUI_DEFINE_MATH_OPERATORS)

target_link_libraries(dehook PRIVATE
    ${HEXA_DIR}/cimgui_import.lib
    ${HEXA_DIR}/cimguizmo_import.lib
    ${HEXA_DIR}/cimnodes_import.lib
    ${HEXA_DIR}/cimplot_import.lib
    ${HEXA_DIR}/cimplot3d_import.lib
    minhook
    d3d11.lib
    d3d12.lib
    dxgi.lib
)

set_property(TARGET dehook PROPERTY MSVC_RUNTIME_LIBRARY "MultiThreadedDLL")
