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

        [ObservableProperty]
        [JsonProperty("symbol")]
        public string symbol;

        [ObservableProperty]
        [JsonProperty("name")]
        public string coinName;

        [JsonProperty("image")]
        [ObservableProperty]
        public string? imageUri;
        
        public BitmapImage? Image => new(new Uri(imageUri));

        [ObservableProperty]
        [JsonProperty("current_price")]
        public decimal currentPrice;

        [ObservableProperty]
        [JsonProperty("market_cap")]
        public long marketCap;

        [ObservableProperty]
        [JsonProperty("market_cap_rank")]
        public int marketCapRank;

        [ObservableProperty]
        [JsonProperty("fully_diluted_valuation")]
        public long fullyDilutedValuation;

        [ObservableProperty]
        [JsonProperty("total_volume")]
        public long totalVolume;

        [ObservableProperty]
        [JsonProperty("high_24h")]
        public decimal high24h;

        [ObservableProperty]
        [JsonProperty("low_24h")]
        public decimal low24h;

        [ObservableProperty]
        [JsonProperty("price_change_24h")]
        public decimal priceChange24h;

        [ObservableProperty]
        [JsonProperty("price_change_percentage_24h")]
        public decimal priceChangePercentage24h;

        [ObservableProperty]
        [JsonProperty("market_cap_change_24h")]
        public decimal marketCapChange24h;

        [ObservableProperty]
        [JsonProperty("market_cap_change_percentage_24h")]
        public decimal marketCapChangePercentage24h;

        [ObservableProperty]
        [JsonProperty("circulating_supply")]
        public decimal circulatingSupply;

        [ObservableProperty]
        [JsonProperty("total_supply")]
        public decimal totalSupply;

        [ObservableProperty]
        [JsonProperty("max_supply")]
        public decimal maxSupply;

        [ObservableProperty]
        [JsonProperty("ath")]
        public decimal ath;

        [ObservableProperty]
        [JsonProperty("ath_change_percentage")]
        public decimal athChangePercentage;

        [ObservableProperty]
        [JsonProperty("atl")]
        public decimal atl;

        [ObservableProperty]
        [JsonProperty("atl_change_percentage")]
        public decimal atlChangePercentage;
    }
}
