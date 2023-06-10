using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace CoinCheck.Model
{
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
        private Thumb? thumb; //make it convert in model from url

        [ObservableProperty]
        private string? slug;

        [ObservableProperty]
        private decimal? priceBtc;

        [ObservableProperty]
        private decimal? rankInTrend;
    }
}
