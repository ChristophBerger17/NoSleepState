# NoSleepState

A small tool that prevents Windows 10 go into sleep state or lock the screen.

## Motivation

Sometimes it's quite anoying, when the screen of a Windows 10 PC is locked after a certain time.
Especially, when executing long running tasks like lab measurements that need to be observed by an operator from time to time to check it's current state.
In order to prevent the screen from beeing disabled, the usual workaround was to run a video in the background.
I haven't found any other solution, so I implemented a tiny little tool that prevented the screen from beeing locked using the Windows built-in [SetThreadExecutionState](https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadexecutionstate) functionallity.

## How to use

Download the release file (`nosleepstate.zip`) and unpack.
Run the `NoSleepState.exe` to prevent your Windows 10 to lock or disable the screen.

This runs a little program that is shown in the Windows taskbar.

In order to exit, right click the icon in the taskbar and select `Exit NoSleepState`.

**Tipp**: create a shortcut in the startup folder to automatically run the tool upon Windows logon.

**Warning**: Keeping the PC unlock may be a security issue. So please make sure to close the tool or manually lock the screen when you leave!

## How to build

All you need to do to build the project is to load the solution into Visual Studio (2017+) and compile the project.
Once compiled, the tool can be executed from `NoSleepState/bin/Release/NoSleepState.exe`.
