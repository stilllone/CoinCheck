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
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static CoinCheck.Model.ChartModel;

namespace CoinCheck.ViewModel
{
    public partial class CurrencyDetailViewModel : DataProvider.ViewModel, IDisposable
    {
        //coins/id
        public CurrencyDetailViewModel(IParameterService paramService)
        {

            ParamService = paramService;
            this.CoinId = ReceiveParameter();
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

        public string ReceiveParameter()
        {
            return ParamService.GetParameter<string>("CoinId");
        }

        [ObservableProperty]
        private IParameterService paramService;
        [ObservableProperty]
        private string coinId;
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

        private async void GetDataForChart()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/{coinId}/market_chart?vs_currency=usd&days=14&interval=daily");
                response.EnsureSuccessStatusCode();
                string? jsonRequest = await response.Content.ReadAsStringAsync();
                if (jsonRequest != null)
                    FillChart(jsonRequest);
            }
        }

        private void FillChart(string? json)
        {
            ChartModel pricesData = JsonConvert.DeserializeObject<ChartModel>(json);

            foreach (List<double> price in pricesData.Prices)
            {
                DateTimePoint dateTimePoint = new DateTimePoint(DateTime.FromBinary((long)price[0]), price[1]);
                chartData.Add(dateTimePoint);
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
                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/{coinId}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=false");
                    response.EnsureSuccessStatusCode();
                    string? jsonRequest = await response.Content.ReadAsStringAsync();
                    if (jsonRequest != null)
                    {
                        GetTickers(jsonRequest);
                        GetPrice(jsonRequest);
                    }
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
            MarketDataItem = marketData.ToObject<MarketData>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
