using RSHelperLib;
using RSHelperLib.API;
using RSHelperLib.Input;
using RSHelperLib.Noty;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSMagic.Scripts
{
    public sealed class AbyssManager : RSScript
    {
        private Stopwatch counter;
        private int roundTrips;
        private decimal roundTripsPerHour;
        private int profitOnAverage;
        private const int NATURE_RUNE_ID = 561;
        private const int PURE_ESSENCE_ID = 7936;

        public AbyssManager()
        {
            counter = new Stopwatch();
            RSHelper.OpenClient();
        }

        public override async Task Run()
        {
            var natTask = ItemPrice.GetAsync(NATURE_RUNE_ID);
            var essTask = ItemPrice.GetAsync(PURE_ESSENCE_ID);
            var natObj = await natTask;
            var essObj = await essTask;
            profitOnAverage = 40 * (natObj.Current.Price - essObj.Current.Price);

            await Noty.Notify("RSAbyss is now running!", 2);
            counter.Start();
            while (true)
            {
                await RSKeyboard.WaitForKeyPress(Key.Home);
                await Noty.Alert();
                roundTrips++;
                CalculateRoundTrips();
                await Noty.Notify($"Trips/hr: {roundTripsPerHour} | Profit/hr: {roundTripsPerHour * profitOnAverage}"
                    + Environment.NewLine
                    + $"Elapsed time: {counter.Elapsed.ToString(@"hh\:mm\:ss")}", 3);
                if (roundTrips % 10 == 0)
                {
                    await Noty.Alert(3);
                    await Noty.Notify("Recharge essence pounches!", 2);
                }
            }
        }

        private void CalculateRoundTrips() =>
                roundTripsPerHour = decimal.Round(roundTrips / (decimal)counter.Elapsed.TotalHours, 1);
    }
}
