using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CoinCheck.Model
{
    public partial class CoinModel : ObservableRecipient
    {
        [ObservableProperty]
        [JsonProperty("id")]
        public string id;

        [JsonProperty("symbol")]
        [ObservableProperty]
        public string symbol;

        [JsonProperty("name")]
        [ObservableProperty]
        public string coinName;

        [JsonProperty("image")]
        [ObservableProperty]
        public string? imageUri;

        public BitmapImage? Image => new(new Uri(imageUri));

        [JsonProperty("current_price")]
        [ObservableProperty]
        public decimal currentPrice;

        [JsonProperty("market_cap")]
        [ObservableProperty]
        public long marketCap;
        [JsonProperty("market_cap_rank")]
        [ObservableProperty]

        public int marketCapRank;
        [JsonProperty("fully_diluted_valuation")]
        [ObservableProperty]

        public long fullyDilutedValuation;
        [JsonProperty("total_volume")]
        [ObservableProperty]
        public long totalVolume;

        [JsonProperty("high_24h")]
        [ObservableProperty]
        public decimal high24h;

        [JsonProperty("low_24h")]
        [ObservableProperty]
        public decimal low24h;

        [JsonProperty("price_change_24h")]
        [ObservableProperty]
        public decimal priceChange24h;

        [JsonProperty("price_change_percentage_24h")]
        [ObservableProperty]
        public decimal priceChangePercentage24h;

        [JsonProperty("market_cap_change_24h")]
        [ObservableProperty]
        public decimal marketCapChange24h;

        [JsonProperty("market_cap_change_percentage_24h")]
        [ObservableProperty]
        public decimal marketCapChangePercentage24h;


    }
}
