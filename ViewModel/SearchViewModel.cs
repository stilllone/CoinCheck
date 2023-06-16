using CoinCheck.Helpers;
using CoinCheck.Interfaces;
using CoinCheck.Model;
using CoinCheck.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Events;
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
    public partial class SearchViewModel : DataProvider.ViewModel
    {
        //https://api.coingecko.com/api/v3/search?query=request
        //search
        //need to adapt only for "coins"

        public SearchViewModel(INavigationService navService, IParameterService paramService, IEventAggregator eventAggregator)
        {
            Navigation = navService;
            ParameterService = paramService;
            EventAggregator = eventAggregator;
        }

        [ObservableProperty]
        private IEventAggregator eventAggregator;
        private void PublishNotification(string notificationText)
        {
            EventAggregator.GetEvent<NotificationEvent>().Publish(notificationText);
        }

        [RelayCommand]
        private async void SearchCoin()
        {
            using (HttpClient client = new())
            {
                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync($"https://api.coingecko.com/api/v3/search?query={searchRequest}");
                    response.EnsureSuccessStatusCode();
                    string? jsonRequest = await response.Content.ReadAsStringAsync();
                    FillSearchCollection(jsonRequest);
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
        private INavigationService navigation;
        [ObservableProperty]
        private IParameterService parameterService;

        private void FillSearchCollection(string json)
        {
            JObject jsonObject = JObject.Parse(json);
            JArray coinsArray = (JArray)jsonObject["coins"];
            SearchCollection = coinsArray.ToObject<ObservableCollection<SearchCoinModel>>();
        }

        [ObservableProperty]
        private ObservableCollection<SearchCoinModel> searchCollection;

        [ObservableProperty]
        private string searchRequest;

        [RelayCommand]
        public void NavigateDetailInfo(string coinId)
        {
            ParameterService.SetParameter("CoinId", coinId);
            Navigation.NavigateTo<CurrencyDetailViewModel>(coinId);
        }
    }
}
