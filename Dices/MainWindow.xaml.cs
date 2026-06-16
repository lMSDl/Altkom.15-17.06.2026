using Dices.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Dices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Dice> Dices { get; }


        public MainWindow()
        {
            InitializeComponent();
            Dices = new ObservableCollection<Dice>(Enumerable.Range(1, 6).Select(i => new Dice { Value = i }));
            DataContext = this;
        }

        public int Sum => Dices.Sum(x => x.Value);

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            Dices.RemoveAt(Dices.Count - 1);
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            Dices.Add(new Dice { Value = random.Next(1, 7) });
        }

        private /*async*/ void Button_Roll(object sender, RoutedEventArgs e)
        {
            RollButton.IsEnabled = false;
            var random = new Random(DateTime.Now.Millisecond);

            //niezalecane podejście fire-and-forget, bo może prowadzić do nieoczekiwanych błędów, jeśli np. użytkownik uruchomi kolejne rzuty zanim poprzednie się zakończą
            /*foreach (var dice in Dices.Where(x => !x.IsLocked))
            {
                _ = RollAsync(random, dice);
            }*/

            var rollTasks = Dices.Where(x => !x.IsLocked).Select(x => RollAsync(random, x));
            /*await Task.WhenAll(rollTasks);
            RollButton.IsEnabled = true;*/
            
            Task.WhenAll(rollTasks).ContinueWith(_ => Dispatcher.Invoke(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sum)));
                return RollButton.IsEnabled = true;
            }));
        }

        private static async Task RollAsync(Random random, Dice dice)
        {
            for (var i = 0; i < random.Next(25, 75); i++)
            {
                dice.Value = random.Next(1, 7);
                await Task.Delay(25);
            }
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Dice dice)
            {
                dice.IsLocked = !dice.IsLocked;
            }
        }
    }
}