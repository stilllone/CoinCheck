using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class TrendingViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private ObservableCollection<TrendingModel> trendingCollection;

        [RelayCommand]
        public void OnInfoCurrency(string coinName)
        {
            
        }


    }
}
