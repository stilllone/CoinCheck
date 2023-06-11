using CoinCheck.Interfaces;
using CoinCheck.View;
using CoinCheck.View.InfoView;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

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
        public void NavigateInfo() => Navigation.NavigateTo<CurrencyDetailViewModel>();

        [RelayCommand]
        public void OnToggleHamburger() => IsHamburgerOpen = !IsHamburgerOpen;

        [ObservableProperty]
        private bool isHamburgerOpen;
    }
}
