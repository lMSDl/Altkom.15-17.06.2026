using ArchitecturalPatterns.ViewModels;
using System.Windows.Controls;

namespace ArchitecturalPatterns.Views
{
    /// <summary>
    /// Interaction logic for MvvmView.xaml
    /// </summary>
    public partial class MvvmView : Page
    {
        public MvvmView()
        {
            InitializeComponent();
            //zamiast Code-behind, używamy Page.DataContext w xaml do powiązania z ViewModel
            //DataContext = new ViewModel();
        }
    }
}
