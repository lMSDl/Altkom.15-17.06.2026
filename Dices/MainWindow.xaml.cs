using Dices.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace Dices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Dice> Dices { get; }


        public MainWindow()
        {
            InitializeComponent();
            Dices = new ObservableCollection<Dice>(Enumerable.Range(1, 6).Select(i => new Dice { Value = i }));
            DataContext = this;
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            Dices.RemoveAt(Dices.Count - 1);
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            Dices.Add(new Dice { Value = random.Next(1, 7) });
        }

        private void Button_Roll(object sender, RoutedEventArgs e)
        {
            var random = new Random(DateTime.Now.Millisecond);
            foreach (var dice in Dices.Where(x => !x.IsLocked))
            {
                dice.Value = random.Next(1, 7);
            }
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.DataContext is Dice dice)
            {
                dice.IsLocked = !dice.IsLocked;
            }
        }
    }
}