using Models;
using System.Windows;
using System.Windows.Input;
using Toolkit.MVVM.Commands;

namespace Warehouse.ViewModels
{
    internal class ProductViewModel
    {
        public Product Product { get; set; }
        public ICommand SaveCommand { get; }

        public ProductViewModel(Product product)
        {
            Product = product;
            SaveCommand = new RelayGenericCommand<Window>(window => window.DialogResult = true);
        }
    }
}
