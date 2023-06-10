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
    public partial class MainViewModel : ObservableRecipient
    {
        public MainViewModel() 
        {

        }

        #region navigate
        [ObservableProperty]
        private UserControl _currentView = new MainView();

        public ICommand NavigateCommand => new RelayCommand<Type>(NavigateTo);
        private void Navigate(UserControl view) => CurrentView = view;
        private void NavigateTo(Type viewType)
        {
            UserControl view = Activator.CreateInstance(viewType) as UserControl;
            Navigate(view);
        }
        #endregion

        [ObservableProperty]
        private string coinName;

        //create navigate or new view by name and get info
        [RelayCommand]
        public void OnInfoCurrency(string coinName)
        {
            var possibleVM = new CurrencyInfoViewModel(coinName);
            Navigate(new CurrencyInfoView(possibleVM));
        }
    }
}
