using System.Windows;
using WiredBrainCoffe.CustomersApp.Data;
using WiredBrainCoffe.CustomersApp.ViewModel;

namespace WiredBrainCoffe.CustomersApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await this.viewModel.LoadAsync();
        }
    }
}
