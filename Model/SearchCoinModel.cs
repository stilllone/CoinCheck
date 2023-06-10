using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace CoinCheck.Model
{
    public partial class SearchCoinModel : ObservableRecipient
    {
        [ObservableProperty]
        private string? id;

        [ObservableProperty]
        private string? coinName;

        [ObservableProperty]
        private string? symbolAPI;

        [ObservableProperty]
        private string? symbol;

        [ObservableProperty]
        private string? marketRank;

        [ObservableProperty]
        private Thumb? coinImage;
    }
}
