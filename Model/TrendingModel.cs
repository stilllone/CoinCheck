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
        private string? id;

        [ObservableProperty]
        private int? coinId;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private string? symbol;

        [ObservableProperty]
        private int? marketCapRank;

        [ObservableProperty]
        private string? thumbUrl;

        public BitmapImage? Image => new BitmapImage(new Uri(thumbUrl));

        [ObservableProperty]
        private string? slug;

        [ObservableProperty]
        private decimal? priceBtc;

        [ObservableProperty]
        private decimal? rankInTrend;
    }
}
