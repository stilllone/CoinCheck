using CoinCheck.View.InfoView;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace CoinCheck.ViewModel
{
    public partial class CurrencyDetailViewModel : DataProvider.ViewModel
    {
        public CurrencyDetailViewModel()
        {
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
                    Values = GetDataChart(),
                    Fill = gradientBrush,
                    StrokeThickness = 1,
                    PointGeometrySize = 0
                }
            };
            XFormatter = val => new DateTime((long)val).ToString("dd MMM");
            YFormatter = val => val.ToString("C");
        }
        //coins/id

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

        private ChartValues<DateTimePoint> GetDataChart()
        {
            var values = new ChartValues<DateTimePoint>();

            return values;
        }
        #endregion
    }
}
