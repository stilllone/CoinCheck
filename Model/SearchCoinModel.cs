using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace CoinCheck.Model
{
    public partial class SearchCoinModel : ObservableRecipient
    {
        [JsonProperty("id")]
        [ObservableProperty]
        private string? id;

        [JsonProperty("name")]
        [ObservableProperty]
        private string? coinName;

        [JsonProperty("api_symbol")]
        [ObservableProperty]
        private string? symbolAPI;

        [JsonProperty("symbol")]
        [ObservableProperty]
        private string? symbol;

        [JsonProperty("market_cap_rank")]
        [ObservableProperty]
        private string? marketRank;

        [JsonProperty("thumb")]
        [ObservableProperty]
        private string? thumb;

        public BitmapImage? CoinImage => new(new Uri(thumb));
    }
}
