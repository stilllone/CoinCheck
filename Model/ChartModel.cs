using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CoinCheck.Model
{
    public partial class ChartModel : ObservableRecipient
    {
        [ObservableProperty]
        private long volume;

        [ObservableProperty]
        private double price;
        public class ChartPrices
        {
            public ObservableCollection<ChartModel> Prices;
        }
    }
}
