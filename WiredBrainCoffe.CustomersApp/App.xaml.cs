using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WiredBrainCoffe.CustomersApp.Data;
using WiredBrainCoffe.CustomersApp.ViewModel;
using WiredBrainCoffee.CustomersApp.Data;

namespace WiredBrainCoffe.CustomersApp
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            this.serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
            services.AddTransient<IProductDataProvider, ProductDataProvider>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = this.serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
