cmake_minimum_required(VERSION 3.18)
cmake_policy(SET CMP0091 NEW)
project(DELibInitializer)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# nethost.h/hostfxr.h/coreclr_delegates.h and nethost.lib ship as part of the
# .NET SDK's win-x64 apphost pack. Pin to the .NET 10 pack specifically
# (there can be several SDK feature bands installed side by side) and pick
# the newest 10.x version present rather than hardcoding an exact patch.
if(NOT DEFINED DOTNET_HOST_PACK_DIR)
    # The apphost pack can live under a few roots depending on how .NET was
    # installed: the default Program Files location locally, or wherever
    # DOTNET_ROOT points (that's where actions/setup-dotnet drops it on CI).
    set(DOTNET_PACK_ROOTS "")
    if(DEFINED ENV{DOTNET_ROOT})
        list(APPEND DOTNET_PACK_ROOTS "$ENV{DOTNET_ROOT}")
    endif()
    if(DEFINED ENV{ProgramFiles})
        list(APPEND DOTNET_PACK_ROOTS "$ENV{ProgramFiles}/dotnet")
    endif()

    if(NOT DOTNET_PACK_ROOTS)
        message(FATAL_ERROR "Neither DOTNET_ROOT nor ProgramFiles is set, cannot locate the .NET host pack")
    endif()

    set(DOTNET_HOST_PACK_CANDIDATES "")
    foreach(root ${DOTNET_PACK_ROOTS})
        file(GLOB _candidates
            "${root}/packs/Microsoft.NETCore.App.Host.win-x64/10.*")
        list(APPEND DOTNET_HOST_PACK_CANDIDATES ${_candidates})
    endforeach()

    if(NOT DOTNET_HOST_PACK_CANDIDATES)
        message(FATAL_ERROR "Could not find a .NET 10 Microsoft.NETCore.App.Host.win-x64 pack "
                             "under any of: ${DOTNET_PACK_ROOTS}. Install the .NET 10 SDK.")
    endif()

    list(SORT DOTNET_HOST_PACK_CANDIDATES COMPARE NATURAL)
    list(GET DOTNET_HOST_PACK_CANDIDATES -1 DOTNET_HOST_PACK_LATEST)
    set(DOTNET_HOST_PACK_DIR "${DOTNET_HOST_PACK_LATEST}/runtimes/win-x64/native")
endif()

message(STATUS "DELibInitializer: using .NET host pack at ${DOTNET_HOST_PACK_DIR}")

add_library(DELibInitializer SHARED
    dllmain.cpp
    DotNetHost.cpp
)

target_include_directories(DELibInitializer PRIVATE ${DOTNET_HOST_PACK_DIR})
target_link_directories(DELibInitializer PRIVATE ${DOTNET_HOST_PACK_DIR})
# Static libnethost.lib (paired with NETHOST_USE_AS_STATIC in DotNetHost.h) so
# the .asi has no runtime dependency on nethost.dll being resolvable next to it.
target_link_libraries(DELibInitializer PRIVATE libnethost)

# Ships as a .asi (loaded by the game's ASI loader), matching the existing
# DELibInitializer.asi naming already deployed alongside DELibrary.NET.
set_target_properties(DELibInitializer PROPERTIES
    PREFIX ""
    SUFFIX ".asi"
)
set_property(TARGET DELibInitializer PROPERTY MSVC_RUNTIME_LIBRARY "MultiThreaded")
