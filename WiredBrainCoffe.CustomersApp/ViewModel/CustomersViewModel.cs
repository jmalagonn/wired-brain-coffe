using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffe.CustomersApp.Data;
using WiredBrainCoffe.CustomersApp.Model;

namespace WiredBrainCoffe.CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider customerDataProvider;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            this.customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        private CustomerItemViewModel? selectedCustomer;
        public CustomerItemViewModel? SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
            }
        }

        private NavigationSide navigationSide;
        public NavigationSide NavigationSide 
        { 
            get => navigationSide; 
            private set
            {
                navigationSide = value;
                RaisePropertyChanged(nameof(NavigationSide));
            }
        }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await this.customerDataProvider.GetAllAsync();

            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }

        public void Add()
        {
            var customer = new Customer { FirstName="New" };
            var viewModel = new CustomerItemViewModel(customer);

            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        internal void MoveNavigation()
        {
            NavigationSide = NavigationSide == NavigationSide.Left
                ? NavigationSide.Right
                : NavigationSide.Left;
        }
    }

    public enum NavigationSide
    {
        Left,
        Right,
    }
}
