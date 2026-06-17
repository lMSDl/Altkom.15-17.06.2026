using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Toolkit.MVVM.ViewModels;

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

        override protected async Task OnLoaded()
        {
            await Task.Delay(5000);
            Products = new ObservableCollection<Product>(_service.ReadAll());
            await base.OnLoaded();
        }

    }
}
