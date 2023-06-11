using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CoinCheck.Model
{
    public partial class ChartModel : ObservableRecipient
    {
        public ChartModel(long volume, double price)
        {
            this.volume = volume;
            this.price = price;
        }

        [ObservableProperty]
        private long volume;

        [ObservableProperty]
        private double price;
        public class ChartPrices
        {
            public List<List<double>> Prices { get; set; }
        }
    }
}
