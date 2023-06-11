using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class ConvertCoinViewModel : DataProvider.ViewModel
    {
        //https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=btc%2Ceth%2Cltc
        //simple/price

        public ConvertCoinViewModel()
        {
            Task.Run(() => GetListOfSupportedCurrecies());
        }
        [RelayCommand]
        public async void ConvertCurrency(string coinId, string intoCurrency)
        {
            using (HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.coingecko.com/api/v3/")
            })
            {
                client.DefaultRequestHeaders.Clear();
                var response = await client.GetAsync($"simple/price?ids={coinId}&vs_currencies={intoCurrency}");
                string? jsonRequest = await response.Content.ReadAsStringAsync();
                var coin = JsonConvert.DeserializeObject<ConvertCoinModel>(jsonRequest);
                convertedCurrency = coin.MainCoin.CurrencyConverted;
            }
        }

        [ObservableProperty]
        private string coinId;

        [ObservableProperty] 
        private string intoCurrencyId;

        [ObservableProperty]
        private double convertedCurrency;

        [ObservableProperty]
        private List<string> supportedCurrencies;

        private async void GetListOfSupportedCurrecies()
        {
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Clear();
                var response = await client.GetAsync("https://api.coingecko.com/api/v3/simple/supported_vs_currencies");
                string? jsonRequest = await response.Content.ReadAsStringAsync();
                supportedCurrencies = JsonConvert.DeserializeObject<List<string>>(jsonRequest);
            }
        }
    }
}
