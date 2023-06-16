using CoinCheck.Helpers;
using CoinCheck.Interfaces;
using CoinCheck.View.UIElements;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using System;
using System.Windows;

namespace CoinCheck.ViewModel
{
    public partial class MainViewModel : DataProvider.ViewModel
    {
       
        public MainViewModel(INavigationService navService, IEventAggregator eventAggregator)
        {
            Navigation = navService;
            EventAggregator = eventAggregator;
            eventAggregator.GetEvent<NotificationEvent>().Subscribe(ShowNotification);
        }

        [ObservableProperty]
        private NotificationView notification;

        private void ShowNotification(string message)
        {
            var notificationView = new NotificationView();
            var notificationViewModel = new NotificationViewModel();
            notificationViewModel.NotificationText = message;
            notificationView.DataContext = notificationViewModel;
            this.Notification = notificationView;
        }

        [ObservableProperty]
        private INavigationService navigation;

        [ObservableProperty]
        private IEventAggregator eventAggregator;

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
            var themeUri = IsDarkTheme ? new Uri("Themes/Dark.xaml", UriKind.Relative) : new Uri("Themes/Light.xaml", UriKind.Relative);
            ((App)Application.Current).ChangeTheme(themeUri);
        }
    }
}
