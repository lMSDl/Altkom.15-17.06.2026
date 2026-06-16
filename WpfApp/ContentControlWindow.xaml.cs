using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ContentControlWindow.xaml
    /// </summary>
    public partial class ContentControlWindow : Window, INotifyPropertyChanged // implementacja INotifyPropertyChanged, aby można było powiadamiać UI o zmianach właściwości
    {
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                //powiadomienie UI o zmianie właściwości SelectedProduct, aby ContentControl mógł się zaktualizować
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedProduct)));
            }
        }
        public IEnumerable<Product> Products { get; set; }
        private IService<Product> _service;
        private Product selectedProduct;

        //implementacja INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public ContentControlWindow()
        {
            InitializeComponent();
            //ustawienie DataContext na this, aby można było bindować do właściwości Products
            DataContext = this;

            _service= new BogusService<Product>(new ProductFaker());
            Products = _service.ReadAll();
        }
    }
}
