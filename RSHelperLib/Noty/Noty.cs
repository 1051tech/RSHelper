using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Linq;

namespace RSHelperLib.Noty
{
    /// <summary>
    /// Encapsulates functionality for notifying users of potential messages/actions.
    /// </summary>
    public static class Noty
    {
        private static NotifyIcon _noty = null;
        private static NotifyIcon RSNoty
        {
            get
            {
                if (_noty == null)
                {
                    _noty = new NotifyIcon()
                    {
                        Icon = Properties.Resources.RSHelper,
                        Text = "RSHelper",
                        BalloonTipIcon = ToolTipIcon.Info,
                        BalloonTipTitle = "Notification from script:",
                        Visible = true,
                        ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Quit", new EventHandler((object sender, EventArgs e) => Environment.Exit(0))) { Index = 0 } }),
                    };
                }
                return _noty;
            }
        } // creates a new system tray icon if doesn't already exist

        /// <summary>Sends a messaging using the Windows notifications.</summary>
        /// <param name="msg">The message to display.</param>
        /// <param name="duration">The duration to display for in seconds<i>(maximum of 5)</i>.</param>
        public static async Task Notify(string msg, int duration)
        {
            await Task.Run(() =>
            {
                duration = duration <= 5 ? duration : 5;
                RSNoty.BalloonTipText = msg;
                RSNoty.ShowBalloonTip(duration);
            });
        }

        /// <summary>Creates a beep, used for alerting the user or acknowledging input.</summary>
        /// <param name="beepCount">How many times to beep <i>(maximum of 4)</i>.</param>
        /// <returns></returns>
        public static async Task Alert(int beepCount = 1)
        {
            await Task.Run(() =>
            {
                beepCount = beepCount <= 4 ? beepCount : 4;
                for (var i = 0; i < beepCount; i++)
                    Console.Beep(10000, 250);
            });
        }

        private static void OnQuit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
