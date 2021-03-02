using System;
using System.Runtime.InteropServices;

namespace NoSleepState
{
    /// <summary>
    /// Enables an application to inform the system that it is in use, thereby
    /// preventing the system from entering sleep or turning off the display 
    /// while the application is running.
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setthreadexecutionstate"/>
    public static class SleepState
    {
        [Flags]
        public enum EXECUTION_STATE : uint
        {
            /// <summary>
            /// Forces the system to be in the working state by resetting the 
            /// system idle timer.
            /// </summary>
            ES_SYSTEM_REQUIRED = 0x00000001,

            /// <summary>
            /// Forces the display to be on by resetting the display idle timer.
            /// </summary>
            ES_DISPLAY_REQUIRED = 0x00000002,

            // Legacy flag, should not be used.
            // ES_USER_PRESENT   = 0x00000004,

            /// <summary>
            /// Enables away mode. This value must be specified with ES_CONTINUOUS.
            /// Away mode should be used only by media-recording and media-distribution
            /// applications that must perform critical background processing on desktop
            /// computers while the computer appears to be sleeping. See Remarks.
            /// </summary>
            ES_AWAYMODE_REQUIRED = 0x00000040,

            /// <summary>
            /// Informs the system that the state being set should remain in
            /// effect until the next call that uses ES_CONTINUOUS and one of
            /// the other state flags is cleared.
            /// </summary>
            ES_CONTINUOUS = 0x80000000,
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        public static void EnableAwayMode()
        {
            Console.WriteLine($"Enable Away Mode");

            if (SetThreadExecutionState(
                  EXECUTION_STATE.ES_CONTINUOUS
                | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                | EXECUTION_STATE.ES_SYSTEM_REQUIRED
                | EXECUTION_STATE.ES_AWAYMODE_REQUIRED) == 0) // Away mode for Windows >= Vista

                SetThreadExecutionState(
                      EXECUTION_STATE.ES_CONTINUOUS
                    | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                    | EXECUTION_STATE.ES_SYSTEM_REQUIRED); // Windows < Vista, forget away mode
        }

        public static void DisableAwayMode()
        {
            Console.WriteLine($"Disable Away Mode");
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
    }
}
