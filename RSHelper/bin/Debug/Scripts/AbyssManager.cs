///<author>LupusOverflo</author>
///<name>RSAbyss</name>
///<version>0.1</version>

using RSHelperLib;
using RSHelperLib.API;
using RSHelperLib.Input;
using RSHelperLib.Noty;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

public class AbyssManager : IScript
{
    private DateTime startingTime;
    private int roundTrips;
    private decimal roundTripsPerHour;
    private int profitOnAverage;
    private const int NATURE_RUNE_ID = 561;
    private const int PURE_ESSENCE_ID = 7936;
	
	private TimeSpan ElapsedTime => DateTime.Now.Subtract(startingTime);

    public AbyssManager()
    {
        RSHelper.OpenClient();
    }

    public async Task Run()
    {
        var natTask = ItemPrice.GetAsync(NATURE_RUNE_ID);
        var essTask = ItemPrice.GetAsync(PURE_ESSENCE_ID);
        var natObj = await natTask;
        var essObj = await essTask;
        profitOnAverage = 40 * (natObj.Current.RealPrice - essObj.Current.RealPrice);

        await Noty.Notify("RSAbyss is now running!", 2);
        startingTime = DateTime.Now;
        while (true)
        {
            await RSKeyboard.WaitForKeyPress(Key.Home);
            await Noty.Alert();
            roundTrips++;
            CalculateRoundTrips();
            await Noty.Notify($"Trips/hr: {roundTripsPerHour} | Profit/hr: {roundTripsPerHour * profitOnAverage}"
                + Environment.NewLine
                + $"Elapsed time: {ElapsedTime.ToString(@"hh\:mm\:ss")}", 3);
            if (roundTrips % 10 == 0)
            {
                await Noty.Alert(3);
                await Noty.Notify("Recharge essence pounches!", 2);
            }
        }
    }

    private void CalculateRoundTrips() =>
            roundTripsPerHour = decimal.Round(roundTrips / (decimal)ElapsedTime.TotalHours, 1);
}