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

        private Product _selectedProduct;
        private ObservableCollection<Product> _products;

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        IService<Product> _service = new BogusService<Product>(new ProductFaker());
        public ICommand RemoveCommand { get; }
        public ProductsViewModel()
        {
            RemoveCommand = new RelayCommand(RemoveProduct, () => SelectedProduct != null);
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
            Products = new ObservableCollection<Product>(_service.ReadAll());
            await base.OnLoaded();
        }



    }
}
