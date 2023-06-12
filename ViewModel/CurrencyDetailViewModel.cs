using CoinCheck.Interfaces;
using CoinCheck.Model;
using CoinCheck.View.InfoView;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static CoinCheck.Model.ChartModel;

namespace CoinCheck.ViewModel
{
    public partial class CurrencyDetailViewModel : DataProvider.ViewModel
    {
        //coins/id
        public CurrencyDetailViewModel()
        {

            //loading info
            Task.Run(()=> GetDataForChart());
            Task.Run(() => GetCoinDetailInfo());

            //chart
            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
            ZoomingMode = ZoomingOptions.X;
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = chartData,
                    Fill = gradientBrush,
                    StrokeThickness = 1,
                    PointGeometrySize = 0
                }
            };
            XFormatter = val => new DateTime((long)val).ToString("dd");
            YFormatter = val => val.ToString("C");
        }
        

        [ObservableProperty]
        private string coinName;
        #region charts
        [ObservableProperty]
        private ZoomingOptions zoomingMode;

        private void ToogleZoomingMode(object sender, RoutedEventArgs e)
        {
            switch (ZoomingMode)
            {
                case ZoomingOptions.None:
                    ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }


        [ObservableProperty]
        private ChartValues<DateTimePoint> chartData = new();
        

        private void FillChart(string? json)
        {
            ChartModel pricesData = JsonConvert.DeserializeObject<ChartModel>(json);

            foreach (List<double> price in pricesData.Prices)
            {
                DateTimePoint dateTimePoint = new DateTimePoint(DateTime.FromBinary((long)price[0]), price[1]);
                chartData.Add(dateTimePoint);
            }
        }

        private async void GetDataForChart()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/{coinName}/market_chart?vs_currency=usd&days=7&interval=daily");
                response.EnsureSuccessStatusCode();
                string? jsonRequest = await response.Content.ReadAsStringAsync();
                if (jsonRequest != null)
                    FillChart(jsonRequest);
            }
        }
        #endregion

        #region detailinfo

        [ObservableProperty]
        private ObservableCollection<Ticker> tickersCollection = new();

        [ObservableProperty]
        private MarketData marketDataItem = new();

        private async void GetCoinDetailInfo()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/{coinName}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=false");
                response.EnsureSuccessStatusCode();
                string? jsonRequest = await response.Content.ReadAsStringAsync();
                if (jsonRequest != null)
                {
                    GetTickers(jsonRequest);
                    GetPrice(jsonRequest);
                }
            }
        }
        private void GetTickers(string json)
        {
            JObject jsonObject = JObject.Parse(json);
            JArray tickersArray = (JArray)jsonObject["tickers"];
            TickersCollection = JsonConvert.DeserializeObject<ObservableCollection<Ticker>>(tickersArray.ToString());
        }

        private void GetPrice(string json)
        {
            JObject jsonObject = JObject.Parse(json);
            var marketData = jsonObject["market_data"];
            marketDataItem = marketData.ToObject<MarketData>();
        }
        #endregion
    }
}
