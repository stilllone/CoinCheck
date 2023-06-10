using CommunityToolkit.Mvvm.ComponentModel;
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
        public string id;

        [ObservableProperty]
        public string symbol;

        [ObservableProperty]
        public string coinName;
        [ObservableProperty]
        public string imageUri;
        
        public BitmapImage? Image => new BitmapImage(new Uri(imageUri));

        [ObservableProperty]
        public decimal currentPrice;

        [ObservableProperty]
        public long marketCap;

        [ObservableProperty]
        public int marketCapRank;

        [ObservableProperty]
        public long fullyDilutedValuation;

        [ObservableProperty]
        public long totalVolume;

        [ObservableProperty]
        public decimal high24h;

        [ObservableProperty]
        public decimal low24h;

        [ObservableProperty]
        public decimal priceChange24h;

        [ObservableProperty]
        public decimal priceChangePercentage24h;

        [ObservableProperty]
        public decimal marketCapChange24h;

        [ObservableProperty]
        public decimal marketCapChangePercentage24h;

        [ObservableProperty]
        public decimal circulatingSupply;

        [ObservableProperty]
        public decimal totalSupply;

        [ObservableProperty]
        public decimal maxSupply;

        [ObservableProperty]
        public decimal ath;

        [ObservableProperty]
        public decimal athChangePercentage;

        [ObservableProperty]
        public decimal atl;

        [ObservableProperty]
        public decimal atlChangePercentage;

    }
}
