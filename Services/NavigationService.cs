using CoinCheck.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace CoinCheck.Services
{
    public partial class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, DataProvider.ViewModel> _viewModelFactory;

        public NavigationService(Func<Type, DataProvider.ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        [ObservableProperty]
        private DataProvider.ViewModel currentView = new();

        public void NavigateTo<TViewModel>(object parameter = null) where TViewModel : DataProvider.ViewModel
        {
            DataProvider.ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
