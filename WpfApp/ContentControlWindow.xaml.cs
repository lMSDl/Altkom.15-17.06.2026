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
        public ICollection<Product> Products { get; set; }
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
            Products = new List<Product>(_service.ReadAll());
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            var sortDescriptions = ((DataGrid)sender).Items.SortDescriptions;
            //czyścimy wszystkie sortowania, aby sortować tylko po IsDamaged i wybranej kolumnie
            sortDescriptions.Clear();

            //wymuszamy sortowanie po IsDamaged w kolejności rosnącej, a następnie po wybranej kolumnie w kolejności malejącej
            sortDescriptions.Add(new SortDescription(nameof(Product.IsDamaged), ListSortDirection.Ascending));
            //dodajemy sortowanie po wybranej kolumnie w kolejności takiej jak wybrał użytkownik (jeśli kliknął w nagłówek kolumny, to sortowanie będzie w kolejności rosnącej, jeśli kliknął ponownie, to w kolejności malejącej)
            sortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, e.Column.SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending));

            e.Handled = true;
        }
    }
}
