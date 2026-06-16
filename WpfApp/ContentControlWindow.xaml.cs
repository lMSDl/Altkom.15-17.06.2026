using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
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
    public partial class ContentControlWindow : Window
    {
        public IEnumerable<Product> Products { get; set; }
        private IService<Product> _service;

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
