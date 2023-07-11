using System.Windows;
using System.Windows.Controls;

namespace WiredBrainCoffe.CustomersApp.Controls.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void ButtonMoveNavigation_Clcik(object sender, RoutedEventArgs e)
        {
            //int column = (int) customerListGrid.GetValue(Grid.ColumnProperty);
            //int newColumn = column == 0 ? 2 : 0;

            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            int column = Grid.GetColumn(customerListGrid);
            int newColumn = column == 0 ? 2 : 0;

            Grid.SetColumn(customerListGrid, newColumn);
        }
    }
}
