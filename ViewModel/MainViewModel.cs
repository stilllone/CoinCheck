using CoinCheck.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

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

    }
}
