using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class TopCurrencyViewModel : DataProvider.ViewModel
    {
        //https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false&locale=en
        //coins/markets
        public TopCurrencyViewModel() 
        {
            Task.Run(() => GetCoinsAsync());
        }

        private async void GetCoinsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false&locale=en");
                response.EnsureSuccessStatusCode();
                string? jsonOfRequest = await response.Content.ReadAsStringAsync();
                TopCurrencyCollection = JsonConvert.DeserializeObject<ObservableCollection<CoinModel>>(jsonOfRequest);
            }
            
        }
        //private async void GetCoinsCollectionAsync(ObservableCollection<CoinModel> coins)
        //{
        //    TopCurrencyCollection = coins;
        //}

        [ObservableProperty]
        ObservableCollection<CoinModel> topCurrencyCollection;

        
    }
}
