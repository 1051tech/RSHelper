using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace RSHelperLib
{
    /// <summary>
    /// Encapsulates p/invokes and functions for focusing the RuneScape client window.
    /// Represents a singular client.
    /// </summary>
    internal sealed class RSObj
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool SetFocus(IntPtr hWnd);

        private readonly Process _proc;

        public RSObj()
        {
            _proc = Process.GetProcessesByName("rs2client").Single();
        }

        public void Open()
        {
            SetForegroundWindow(_proc.MainWindowHandle);
        }
    }
}
