using Dapplo.Windows.Input;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSHelperLib.Input
{
    /// <summary>
    /// Encapsulates keyboard input functionality.
    /// </summary>
    public static class RSKeyboard
    {
        private static ConcurrentBag<ThreadState> waitingStates = new ConcurrentBag<ThreadState>()
        { ThreadState.Running, ThreadState.Background, ThreadState.WaitSleepJoin, ThreadState.Suspended, ThreadState.SuspendRequested };

        /// <summary>Creates a task that waits for a keypress and completes when keypress is triggered.</summary>
        /// <param name="key">The key to wait for.</param>
        public static async Task WaitForKeyPress(Key key)
        {
            Thread keyboardThread = new Thread(new ParameterizedThreadStart(KeyboardThread));
            keyboardThread.SetApartmentState(ApartmentState.STA);
            keyboardThread.Start(key);

            while (waitingStates.Any(state => state == keyboardThread.ThreadState))
                await Task.Delay(20);
        }

        /// <summary>Generates a keypress within a timeframe that appears human.</summary>
        /// <param name="key">The key to generate keypress for.</param>
        public static async Task GenerateKeyPress(Dapplo.Windows.Input.Enums.VirtualKeyCodes key)
        {
            var rand = new Random(Environment.TickCount);
            InputGenerator.KeyDown(new Dapplo.Windows.Input.Enums.VirtualKeyCodes[] { key });
            await Task.Delay(rand.Next(300, 500));
            InputGenerator.KeyDown(new Dapplo.Windows.Input.Enums.VirtualKeyCodes[] { key });
        }

        public static void KeyboardThread(object keyObj)
        {
            var key = (Key)keyObj;
            bool keyWasDown = false;
            while (true)
            {
                if (Keyboard.IsKeyDown(key))
                    keyWasDown = true;
                if (Keyboard.IsKeyUp(key) && keyWasDown)
                    break;
                Thread.Sleep(20);
            }
        }
    }
}
