using CoinCheck.Interfaces;
using CoinCheck.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private Func<Type, DataProvider.ViewModel> _viewModel;
        public NavigationService(Func<Type, DataProvider.ViewModel> viewModel) 
        {
            this._viewModel = viewModel;
        }

        private DataProvider.ViewModel currentView;
        public DataProvider.ViewModel CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : DataProvider.ViewModel
        {
            DataProvider.ViewModel viewModel = _viewModel.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
