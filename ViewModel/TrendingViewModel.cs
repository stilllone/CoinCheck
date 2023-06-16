using CoinCheck.Interfaces;
using CoinCheck.Model;
using CoinCheck.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class TrendingViewModel : DataProvider.ViewModel
    {
        //https://api.coingecko.com/api/v3/search/trending
        //search/trending
        public TrendingViewModel(INavigationService navService, IParameterService paramService)
        {
            Navigation = navService;
            ParameterService = paramService;

            Task.Run(() => GetTrendingCoinsAsync());
        }

        [ObservableProperty]
        private INavigationService navigation;

        [ObservableProperty]
        private IParameterService parameterService;

        private async void GetTrendingCoinsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync("https://api.coingecko.com/api/v3/search/trending");
                    response.EnsureSuccessStatusCode();
                    string? jsonRequest = await response.Content.ReadAsStringAsync();
                    TrendingCollection = FillCollection(jsonRequest);
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
                    Debug.WriteLine("An http error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private ObservableCollection<TrendingModel> FillCollection(string? json)
        {
            // Parse the JSON object
            JObject jsonObject = JObject.Parse(json);
            JArray coinsArray = (JArray)jsonObject["coins"];
            ObservableCollection<TrendingModel> trendingList = new ObservableCollection<TrendingModel>();

            foreach (JObject coinObject in coinsArray)
            {
                JObject itemObject = (JObject)coinObject["item"];
                TrendingModel coin = itemObject.ToObject<TrendingModel>();
                trendingList.Add(coin);
            }

            return new ObservableCollection<TrendingModel>(trendingList);
        }

        [RelayCommand]
        public void NavigateDetailInfo(string coinId)
        {
            ParameterService.SetParameter("CoinId", coinId);
            Navigation.NavigateTo<CurrencyDetailViewModel>(coinId);
        }

        [ObservableProperty]
        private ObservableCollection<TrendingModel> trendingCollection;

    }
}
