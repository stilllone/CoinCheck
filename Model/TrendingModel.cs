using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace CoinCheck.Model
{
    [JsonObject]
    public partial class TrendingModel : ObservableRecipient
    {
        [JsonProperty("id")]
        [ObservableProperty]
        private string? id;

        [JsonProperty("coin_id")]
        [ObservableProperty]
        private int? coinId;

        [JsonProperty("name")]
        [ObservableProperty]
        private string? coinName;

        [JsonProperty("symbol")]
        [ObservableProperty]
        private string? symbol;

        [JsonProperty("market_cap_rank")]
        [ObservableProperty]
        private int? marketCapRank;

        [JsonProperty("thumb")]
        [ObservableProperty]
        private string? thumbUrl;

        public BitmapImage? Image => new BitmapImage(new Uri(thumbUrl));

        [JsonProperty("slug")]
        [ObservableProperty]
        private string? slug;

        [JsonProperty("price_btc")]
        [ObservableProperty]
        private decimal? priceBtc;

        [JsonProperty("score")]
        [ObservableProperty]
        private decimal? rankInTrend;
    }
}
