using CoinCheck.Helpers;
using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class ConvertCoinViewModel : DataProvider.ViewModel
    {
        //https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=btc%2Ceth%2Cltc
        //simple/price

        public ConvertCoinViewModel(IEventAggregator eventAggregator)
        {
            Task.Run(() => GetListOfSupportedCurrecies());
            CoinCount = CoinCount == null ? 1 : CoinCount;
            EventAggregator = eventAggregator;
        }

        [ObservableProperty]
        private IEventAggregator eventAggregator;

        private void PublishNotification(string notificationText)
        {
            EventAggregator.GetEvent<NotificationEvent>().Publish(notificationText);
        }

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
                    PublishNotification("Too Many Requests. Please try again later.");
                }
                catch (HttpRequestException ex) when (response.StatusCode == HttpStatusCode.NotFound)
                {
                    PublishNotification("Endpoint not found.");
                }
                catch (NullReferenceException)
                {
                    PublishNotification("Write some data");
                }
                catch (HttpRequestException ex)
                {
                    PublishNotification("An error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    PublishNotification("An error occurred: " + ex.Message);
                }
            }
        }

        [ObservableProperty]
        private string coinId;

        [ObservableProperty]
        private double? coinCount;

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
