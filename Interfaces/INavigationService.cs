using CoinCheck.DataProvider;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.Interfaces
{
    public interface INavigationService
    {
        DataProvider.ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : DataProvider.ViewModel;

    }
}
