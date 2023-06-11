using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CoinCheck.Model
{
    public partial class ChartModel : ObservableRecipient
    {
        public List<List<double>> Prices { get; set; }
    }
}
