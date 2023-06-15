using CoinCheck.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace CoinCheck.ViewModel
{
    public partial class MainViewModel : DataProvider.ViewModel
    {
        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
        }
        [ObservableProperty]
        private INavigationService navigation;

        [RelayCommand]
        public void NavigateCurrencies() => Navigation.NavigateTo<TopCurrencyViewModel>();

        [RelayCommand]
        public void NavigateTrending() => Navigation.NavigateTo<TrendingViewModel>();

        [RelayCommand]
        public void NavigateSearch() => Navigation.NavigateTo<SearchViewModel>();

        [RelayCommand]
        public void NavigateConvert() => Navigation.NavigateTo<ConvertCoinViewModel>();

        [RelayCommand]
        public void OnToggleHamburger() => IsHamburgerOpen = !IsHamburgerOpen;

        [ObservableProperty]
        private bool isHamburgerOpen;

        private bool isDarkTheme;
        public bool IsDarkTheme
        {
            get { return isDarkTheme; }
            set
            {
                if (isDarkTheme != value)
                {
                    isDarkTheme = value;
                    UpdateTheme();
                    OnPropertyChanged(nameof(IsDarkTheme));
                }
            }
        }
        [RelayCommand]
        private void UpdateTheme()
        {
            ResourceDictionary newThemeDictionary;
            if (IsDarkTheme)
            {
                newThemeDictionary = new ResourceDictionary { Source = new Uri("Themes/Dark.xaml", UriKind.Relative) };
            }
            else
            {
                newThemeDictionary = new ResourceDictionary { Source = new Uri("Themes/Light.xaml", UriKind.Relative) };
            }
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newThemeDictionary);
        }
    }
}
