using CoinCheck.Interfaces;
using CoinCheck.Services;
using CoinCheck.View;
using CoinCheck.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CoinCheck
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // register navigation 
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<CurrencyInfoViewModel>();
            services.AddSingleton<TopCurrencyViewModel>();
            //services.AddSingleton<MainView>();


            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, DataProvider.ViewModel>>(serviceProvider => viewModelType => (DataProvider.ViewModel)serviceProvider.GetRequiredService(viewModelType));
            
            _serviceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
            base.OnStartup(e);
        }
    }
}
