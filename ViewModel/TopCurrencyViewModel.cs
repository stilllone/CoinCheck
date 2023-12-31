﻿using CoinCheck.Helpers;
using CoinCheck.Interfaces;
using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class TopCurrencyViewModel : DataProvider.ViewModel
    {
        //https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false&locale=en
        //coins/markets
        public TopCurrencyViewModel(INavigationService navService, IParameterService paramService, IEventAggregator eventAggregator)
        {
            Navigation = navService;
            ParameterService = paramService;
            Task.Run(() => GetCoinsAsync());
            EventAggregator = eventAggregator;
        }

        [ObservableProperty]
        private IEventAggregator eventAggregator;
        private void PublishNotification(string notificationText)
        {
            EventAggregator.GetEvent<NotificationEvent>().Publish(notificationText);
        }

        [ObservableProperty]
        private INavigationService navigation;
        [ObservableProperty]
        private IParameterService parameterService;

        private async void GetCoinsAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                HttpRequestMessage requestMessage = new(HttpMethod.Get,
                "https://api.coingecko.com//api/v3/coins/markets?vs_currency=eur&order=market_cap_desc&per_page=10&page=1&sparkline=false&locale=en&precision=4");

                requestMessage.Headers.Add("User-Agent", "User-Agent-Here");
                HttpResponseMessage response = null;
                try
                {
                    response = await client.SendAsync(requestMessage);
                    response.EnsureSuccessStatusCode();

                    string jsonOfRequest = await response.Content.ReadAsStringAsync();
                    TopCurrencyCollection = JsonConvert.DeserializeObject<ObservableCollection<CoinModel>>(jsonOfRequest);
                    Debug.WriteLine(TopCurrencyCollection[0].High24h);
                    Debug.WriteLine(TopCurrencyCollection[0].Low24h);
                    Debug.WriteLine(TopCurrencyCollection[0].PriceChangePercentage24h);
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
                    PublishNotification("Something happened with data");
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

        [RelayCommand]
        public void NavigateDetailInfo(string coinId)
        {
            ParameterService.SetParameter("CoinId", coinId);
            Navigation.NavigateTo<CurrencyDetailViewModel>(coinId);
        }

        [ObservableProperty]
        ObservableCollection<CoinModel> topCurrencyCollection;
    }
}
