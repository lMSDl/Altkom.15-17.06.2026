using OrdersApp.Models;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrdersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public IEnumerable<Order> Orders { get; set; }
        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (_selectedOrder != value)
                {
                    _selectedOrder = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedOrder)));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Orders = new List<Order>
            {
                new Order
                {
                    DateTime = DateTime.Now,
                    CustomerName = "John Doe",
                    Products = new List<Product>
                    {
                        new Product { Name = "Product 1", Price = 10.0f, Quantity = 1 },
                        new Product { Name = "Product 2", Price = 20.0f, Quantity = 2 }
                    }
                },
                new Order
                {
                    DateTime = DateTime.Now,
                    CustomerName = "Jane Smith",
                    Products = new List<Product>
                    {
                        new Product { Name = "Product 3", Price = 30.0f, Quantity = 3 },
                        new Product { Name = "Product 4", Price = 40.0f, Quantity = 4 }
                    }
                }
            };
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}