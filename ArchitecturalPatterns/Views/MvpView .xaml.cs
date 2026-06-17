using ArchitecturalPatterns.Presenters;
using System.Windows;
using System.Windows.Controls;

namespace ArchitecturalPatterns.Views
{
    /// <summary>
    /// Interaction logic for MvpView.xaml
    /// </summary>
    public partial class MvpView : Page, IView
    {
        private readonly IPresenter _presenter;
        public MvpView()
        {
            InitializeComponent();
            _presenter = new Presenter(this);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Save(TextBox_Input.Text);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Load();
        }

        public void Display(string value)
        {
            Label_Value.Content = value;
        }

        public void Load(string value)
        {
            TextBox_Input.Text = value;
        }
    }
}
