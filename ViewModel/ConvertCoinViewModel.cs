using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        //need to update
        [RelayCommand]
        private async void ConvertCurrency()
        {
            using (HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.coingecko.com/api/v3/")
            })
            {
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync($"simple/price?ids={CoinId}&vs_currencies={IntoCurrency.ToLower()}");
                    response.EnsureSuccessStatusCode();
                    string? jsonRequest = await response.Content.ReadAsStringAsync();
                    ConvertCoinModel coin = JsonConvert.DeserializeObject<ConvertCoinModel>(jsonRequest, new CustomConverter());
                    ConvertedCurrency = coin.MainCoin[IntoCurrency];
                    ConvertedResult = $"{CoinCount} = {(long)CoinCount * (long)ConvertedCurrency}";
                }
                catch (HttpRequestException ex) when ((int)response?.StatusCode == 429)
                {
                    Debug.WriteLine("Too Many Requests. Please try again later.");
                }
                catch (HttpRequestException ex) when (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Debug.WriteLine("Endpoint not found.");
                }
                catch (HttpRequestException ex)
                {
                    Debug.WriteLine("An error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        [ObservableProperty]
        private string coinId;

        [ObservableProperty]
        private double coinCount;

        [ObservableProperty] 
        private string intoCurrency;

        [ObservableProperty] 
        private string convertedResult;

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
                SupportedCurrencies = JsonConvert.DeserializeObject<List<string>>(jsonRequest);
            }
        }
    }
}
