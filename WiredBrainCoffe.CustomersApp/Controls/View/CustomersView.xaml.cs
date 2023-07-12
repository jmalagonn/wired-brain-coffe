using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffe.CustomersApp.Data;
using WiredBrainCoffe.CustomersApp.ViewModel;

namespace WiredBrainCoffe.CustomersApp.Controls.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomersViewModel viewModel;

        public CustomersView()
        {
            InitializeComponent();
            this.viewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = this.viewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await this.viewModel.LoadAsync();
        }

        private void ButtonMoveNavigation_Clcik(object sender, RoutedEventArgs e)
        {
            this.viewModel.MoveNavigation();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.Add();
        }
    }
}
