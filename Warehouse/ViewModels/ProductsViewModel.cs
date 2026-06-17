using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Toolkit.MVVM.Commands;
using Toolkit.MVVM.ViewModels;
using Warehouse.Properties;

namespace Warehouse.ViewModels
{
    internal class ProductsViewModel : BaseViewModel
    {

        private Product? _selectedProduct;

        public Product? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();

        IService<Product> _service = new BogusService<Product>(new ProductFaker());
        public ICommand RemoveCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ProductsViewModel()
        {
            RemoveCommand = new RelayCommand(RemoveProduct, () => SelectedProduct != null);
            AddCommand = new RelayGenericCommand<Type>(AddProduct);
            EditCommand = new RelayGenericCommand<Type>(EditProduct, _ => SelectedProduct != null);
        }

        private void AddProduct(Type type)
        {
            var product = AddOrEdit(type, new Product());

            if (product == null)
            {
                return;
            }

            _service.Add(product);
            Products.Add(product);
        }

        private void EditProduct(Type type)
        {
            var product = AddOrEdit(type, (Product)SelectedProduct.Clone());

            if (!_service.Replace(SelectedProduct, product))
            {
                return;
            }

            int index = Products.IndexOf(SelectedProduct);
            Products[index] = product;
            SelectedProduct = product;
        }

        private Product? AddOrEdit(Type type, Product product)
        {
            //nie powinniśmy używać w VM klas okien, bo to łamie MVVM
            //Window window = new ProductView()

            //dlatego używamy refleksji, aby utworzyć instancję okna na podstawie przekazanego typu
            //alternatywnym podejściem byłoby użycie wzorca fabryki, który tworzyłby okna na podstawie typu, ale w tym przypadku refleksja jest wystarczająca
            var window = Activator.CreateInstance(type) as Window;
            ProductViewModel viewModel = new ProductViewModel(product);
            window.DataContext = viewModel;

            if (window.ShowDialog() == true)
                return viewModel.Product;
            return null;
        }

        private void RemoveProduct()
        {
            var result = MessageBox.Show(string.Format(Resources.ProductDeleteConfirmation, SelectedProduct.Name), Resources.Delete, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result != MessageBoxResult.Yes)
            {
                return;
            }


            if (_service.Delete(SelectedProduct))
            {
                Products.Remove(SelectedProduct);
            }
        }

        override protected async Task OnLoaded()
        {
            await Task.Delay(5000);
            foreach (var product in _service.ReadAll())
            {
                Products.Add(product);
            }
            await base.OnLoaded();
        }



    }
}
