using CoinCheck.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class TrendingViewModel : DataProvider.ViewModel
    {
       
        //https://api.coingecko.com/api/v3/search/trending
        //search/trending
        public TrendingViewModel()
        {
            Task.Run(() => GetTrendingCoinsAsync());
        }

        private async void GetTrendingCoinsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.coingecko.com/api/v3/search/trending");
                response.EnsureSuccessStatusCode();
                string? jsonRequest = await response.Content.ReadAsStringAsync();
                TrendingCollection = FillCollection(jsonRequest);
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

        [ObservableProperty]
        private ObservableCollection<TrendingModel> trendingCollection;

    }
}
