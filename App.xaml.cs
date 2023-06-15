using CoinCheck.DataProvider;
using CoinCheck.Interfaces;
using CoinCheck.Services;
using CoinCheck.View;
using CoinCheck.View.InfoView;
using CoinCheck.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Prism.Common;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CoinCheck
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // register navigation 
            services.AddScoped<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<IParameterService, ParameterService>();



            services.AddSingleton<TopCurrencyViewModel>();
            services.AddSingleton<TrendingViewModel>();
            services.AddSingleton<SearchViewModel>();
            services.AddSingleton<ConvertCoinViewModel>();

            //services.AddSingleton<CurrencyInfoView>(provider => new CurrencyInfoView
            //{
            //    DataContext = provider.GetRequiredService<CurrencyDetailViewModel>()
            //});

            services.AddSingleton<CurrencyInfoView>(provider =>
            {
                CurrencyInfoView currencyInfoView = new CurrencyInfoView();

                // Get the current view model type from the provider
                Type currentViewModelType = provider.GetService<DataProvider.ViewModel>().GetType();

                if (currentViewModelType == typeof(CurrencyDetailViewModel))
                {
                    currencyInfoView.DataContext = provider.GetRequiredService<CurrencyDetailViewModel>();
                }
                else if (currentViewModelType == typeof(TrendingViewModel))
                {
                    currencyInfoView.DataContext = provider.GetRequiredService<TrendingViewModel>();
                }
                else if (currentViewModelType == typeof(SearchViewModel))
                {
                    currencyInfoView.DataContext = provider.GetRequiredService<SearchViewModel>();
                }

                return currencyInfoView;
            });

            services.AddTransient(provider =>
            {
                IParameterService parameterService = provider.GetRequiredService<IParameterService>();
                return new CurrencyDetailViewModel(parameterService);
            });
            services.AddSingleton<INavigationService, Services.NavigationService>();
            services.AddSingleton<Func<Type, DataProvider.ViewModel>>(serviceProvider => viewModelType => (DataProvider.ViewModel)serviceProvider.GetRequiredService(viewModelType));


            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }

            base.OnExit(e);
        }
    }
}
