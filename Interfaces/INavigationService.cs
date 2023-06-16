namespace CoinCheck.Interfaces
{
    public interface INavigationService
    {
        DataProvider.ViewModel CurrentView { get; }
        void NavigateTo<T>(object parameter = null) where T : DataProvider.ViewModel;
    }
}
