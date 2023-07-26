using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffe.CustomersApp.Model;
using WiredBrainCoffee.CustomersApp.Data;

namespace WiredBrainCoffe.CustomersApp.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductDataProvider productDataProvider;

        public ProductsViewModel(IProductDataProvider productDataProvider)
        {
            this.productDataProvider = productDataProvider;
        }

        public ObservableCollection<Product> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            var products = await this.productDataProvider.GetAllAsync();

            if (products is not null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }
    }
}
