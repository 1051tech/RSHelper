///<author>LupusOverflo</author>
///<name>RSMagic</name>
///<version>0.11</version>

using RSHelperLib;
using RSHelperLib.Input;
using RSHelperLib.Noty;
using System;
using System.Threading.Tasks;

public sealed class MagicTrainer : IScript
{
    private int expMultiplier = 48;
    private int iterations = 500;
    private Random pressGen = new Random(Environment.TickCount);
    public MagicTrainer() => RSHelper.OpenClient();

    public async Task Run()
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