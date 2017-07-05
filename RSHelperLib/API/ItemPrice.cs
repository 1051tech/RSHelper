using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace RSHelperLib.API
{
    public static class ItemPrice
    {
        public static async Task<ItemPriceObj> GetAsync(int itemId)
        {
            return await Task.Run(() =>
            {
                var wc = new WebClient();
                var url = "http://services.runescape.com/m=itemdb_rs/api/catalogue/detail.json?item=" + itemId;
                var json = wc.DownloadString(url);
                return JsonConvert.DeserializeObject<ItemPriceWrapper>(json).Item;
            });
        }
    }

    public class ItemPriceWrapper
    {
        public ItemPriceObj Item;
    }

    public class ItemPriceObj
    {
        public string Icon { get; set; }
        public string IconLarge { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string TypeIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Members { get; set; }

        public GrandExchangeReport Current { get; set; }
        public GrandExchangeReport Today { get; set; }
        public GrandExchangeTrend Day30 { get; set; }
        public GrandExchangeTrend Day90 { get; set; }
        public GrandExchangeTrend Day180 { get; set; }

        public class GrandExchangeReport
        {
            public string Trend { get; set; }
            public string Price { get; set; }
            public int RealPrice => int.Parse(Price.Trim(' '));
        }

        public class GrandExchangeTrend
        {
            public string Trend { get; set; }
            public string Change { get; set; }
        }
    }
}
