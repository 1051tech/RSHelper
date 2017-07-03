using RSHelperLib;
using RSHelperLib.Input;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSMagic
{
    public class Program
    {
        private static RSScript currentScript;
        
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult(); // creates a new async context

        /// <summary>Entry point for the asynchronous context.</summary>
        private async Task MainAsync()
        {
            Console.Title = "RSHelper";
            while (true)
            {
                Console.WriteLine("Select script: ");
                if (!await SelectScript(Console.ReadLine()))
                    break;
            }
            Console.ReadKey();
        }

        //TODO: Don't use switch, instead search for script and return false if not found.
        /// <summary>Script selection method (looped).</summary>
        /// <param name="cmd">The command expected per script.</param>
        private async Task<bool> SelectScript(string cmd)
        {
            switch (cmd.ToLower())
            {
                case "/rsmagic":
                    currentScript = new Scripts.MagicTrainer();
                    break;
                case "/rsabyss":
                    currentScript = new Scripts.AbyssManager();
                    break;

                case "/exit":
                    return false;
                default:
                    Console.WriteLine("Invalid script!");
                    return true;
            }

            currentScript.ScriptTask = Task.Factory.StartNew(async () =>
            {
                currentScript.ScriptThread = Thread.CurrentThread;
                await currentScript.Run();
            });

            await RSKeyboard.WaitForKeyPress(Key.Escape);
            currentScript.ScriptThread.Abort();
            return true;
        }
    }
}
