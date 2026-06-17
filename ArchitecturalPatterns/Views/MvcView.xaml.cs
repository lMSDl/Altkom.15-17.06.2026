using ArchitecturalPatterns.Models;
using System.Windows;
using System.Windows.Controls;

namespace ArchitecturalPatterns.Views
{
    /// <summary>
    /// Interaction logic for MvcView.xaml
    /// </summary>
    public partial class MvcView : Page
    {
        private readonly SomeModel _model;
        public MvcView()
        {
            InitializeComponent();
            _model = new SomeModel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _model.Value = TextBox_Input.Text;
            Label_Value.Content = _model.Value;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Input.Text = _model.Value;
        }

    }
}
