using WiredBrainCoffe.CustomersApp.Model;

namespace WiredBrainCoffe.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer model;

        public CustomerItemViewModel(Customer model)
        {
            this.model = model;
        }

        public int Id => this.model.Id;

        public string? FirstName
        {
            get => this.model.FirstName;
            set 
            { 
                this.model.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string? LastName
        {
            get => this.model.LastName;
            set
            {
                this.model.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public bool IsDeveloper
        {
            get => this.model.IsDeveloper;
            set
            {
                this.model.IsDeveloper = value;
                RaisePropertyChanged(nameof(IsDeveloper));
            }
        }
    }
}
