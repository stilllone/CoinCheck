using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        [RelayCommand]
        private async void SearchCoin()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetAsync($"https://api.coingecko.com/api/v3/search?query={searchRequest}");
                response.EnsureSuccessStatusCode();
                string? jsonRequest = await response.Content.ReadAsStringAsync();
                FillSearchCollection(jsonRequest);
            }
        }

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
    }
}
