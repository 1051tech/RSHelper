using RSHelperLib;
using RSHelperLib.Input;
using RSHelperLib.Noty;
using System;
using System.Threading.Tasks;

namespace RSMagic.Scripts
{
    public sealed class MagicTrainer : RSScript
    {
        private int expMultiplier = 48;
        private int iterations = 500;
        private Random pressGen = new Random(Environment.TickCount);
        public MagicTrainer() => RSHelper.OpenClient();

        public override async Task Run()
        {
            await Noty.Notify("RSMagic is running!", 2);

            for (var i = 0; i <= iterations; i++)
            {
                await RSKeyboard.GenerateKeyPress(Dapplo.Windows.Input.Enums.VirtualKeyCodes.KEY_9);
                if (iterations % 10 == 0)
                    await Noty.Notify($"{i}/{iterations} completed! Estimated exp: {i * expMultiplier}", 3);
                await Task.Delay(pressGen.Next(1250, 1750));
            }
            await Noty.Notify($"RSMagic has completed running! Estimated exp gain: {iterations * expMultiplier}", 3);
        }
    }
}
