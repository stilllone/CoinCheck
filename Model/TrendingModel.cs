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
        [ObservableProperty]
        [JsonProperty("id")]
        private string? id;

        [ObservableProperty]
        [JsonProperty("coin_id")]
        private int? coinId;

        [ObservableProperty]
        [JsonProperty("name")]
        private string? name;

        [ObservableProperty]
        [JsonProperty("symbol")]
        private string? symbol;

        [ObservableProperty]
        [JsonProperty("market_cap_rank")]
        private int? marketCapRank;

        [ObservableProperty]
        [JsonProperty("thumb")]
        private string? thumbUrl;

        public BitmapImage? Image => new BitmapImage(new Uri(thumbUrl));

        [ObservableProperty]
        [JsonProperty("slug")]
        private string? slug;

        [ObservableProperty]
        [JsonProperty("price_btc")]
        private decimal? priceBtc;

        [ObservableProperty]
        [JsonProperty("rank_in_trend")]
        private decimal? rankInTrend;
    }
}
