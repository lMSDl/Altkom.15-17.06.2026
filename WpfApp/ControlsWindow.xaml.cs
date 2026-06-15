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
    /// Interaction logic for ControlsWindow.xaml
    /// </summary>
    public partial class ControlsWindow : Window
    {
        public ControlsWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(cb1.IsChecked == true && cb2.IsChecked == true && cb3.IsChecked == true)
            {
                cbAll.IsChecked = true;
            }
            else if(cb1.IsChecked == false && cb2.IsChecked == false && cb3.IsChecked == false)
            {
                cbAll.IsChecked = false;
            }
            else
            {
                cbAll.IsChecked = null;
            }
            e.Handled = true;
        }   

        private void CheckBoxAll_Click(object sender, RoutedEventArgs e)
        {
            cb1.IsChecked = cb2.IsChecked = cb3.IsChecked = cbAll.IsChecked = cbAll.IsChecked ?? false;
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var result = MessageBox.Show("Czy ukryć ten przycisk?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes && sender is FrameworkElement element)
            {
                element.Visibility = Visibility.Collapsed;

                Task.Delay(2500).ContinueWith(x => Application.Current.Dispatcher.Invoke(() => element.Visibility = Visibility.Hidden));
                Task.Delay(5000).ContinueWith(x => Application.Current.Dispatcher.Invoke(() => element.Visibility = Visibility.Visible));
            }
            e.Handled = true;
        }
    }
}
