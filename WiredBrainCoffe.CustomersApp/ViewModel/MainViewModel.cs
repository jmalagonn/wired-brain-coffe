using System;
using System.Threading.Tasks;
using WiredBrainCoffe.CustomersApp.Command;

namespace WiredBrainCoffe.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            CustomersViewModel=customersViewModel;
            ProductsViewModel=productsViewModel;
            SelectedViewModel = CustomersViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }        

        public ViewModelBase? SelectedViewModel 
        { 
            get => selectedViewModel; 
            set
            {
                this.selectedViewModel = value;
                RaisePropertyChanged(nameof(SelectedViewModel));
            }
        }

        public CustomersViewModel CustomersViewModel { get; }

        public ProductsViewModel ProductsViewModel { get; }

        public DelegateCommand SelectViewModelCommand { get; }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
