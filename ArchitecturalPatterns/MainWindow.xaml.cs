using ArchitecturalPatterns.Views;
using System.Windows;
using System.Windows.Controls;

namespace ArchitecturalPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Page _mvc = new MvcView();
        private readonly Page _mvp = new MvpView();
        private readonly Page _mvvm = new MvvmView();

        private void ToggleButton_MVC_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_mvc);
            ToggleButton_MVC.IsChecked = true;
            ToggleButton_MVP.IsChecked = false;
            ToggleButton_MVVM.IsChecked = false;
        }
        private void ToggleButton_MVP_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_mvp);
            ToggleButton_MVC.IsChecked = false;
            ToggleButton_MVP.IsChecked = true;
            ToggleButton_MVVM.IsChecked = false;
        }

        private void ToggleButton_MVVM_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_mvvm);
            ToggleButton_MVC.IsChecked = false;
            ToggleButton_MVP.IsChecked = false;
            ToggleButton_MVVM.IsChecked = true;
        }
    }
}