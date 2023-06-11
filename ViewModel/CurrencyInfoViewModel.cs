using CoinCheck.View.InfoView;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace CoinCheck.ViewModel
{
    public partial class CurrencyInfoViewModel : DataProvider.ViewModel
    {

        //coins/id
        public CurrencyInfoViewModel(string coinName) 
        {
            this.coinName = coinName;
        }

        [ObservableProperty]
        private string coinName;

        private void GetInfoByName(string coinName)
        {
            //get by name and find, then show info
            //can be get from coins/markets
        }
    }
}
