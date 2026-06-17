using Dices.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Toolkit.MVVM.ViewModels;
using Toolkit.MVVM.Commands;

namespace Dices.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Dice>? Dices { get; private set; }
        public int Sum => Dices?.Sum(x => x.Value) ?? 0;

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand RollCommand { get; }
        public ICommand DiceClickCommand { get; }

        public MainViewModel()  
        {
            AddCommand = new RelayCommand(AddDice);
            RemoveCommand = new RelayCommand(RemoveDice, () => Dices?.Count > 0);
            RollCommand = new RelayAsyncCommand(Roll, () => Dices?.Any(x => !x.IsLocked) ?? false );

            DiceClickCommand = new RelayGenericCommand<Dice>(dice => DiceLock(dice));
        }

        protected override Task OnLoaded()
        {
            Dices = new ObservableCollection<Dice>(Enumerable.Range(1, 6).Select(i => new Dice { Value = i }));
            OnPropertyChanged(nameof(Dices));
            return base.OnLoaded();
        }

        private void RemoveDice()
        {
            Dices!.RemoveAt(Dices.Count - 1);
        }

        private void AddDice()
        {
            var random = new Random();
            Dices!.Add(new Dice { Value = random.Next(1, 7) });
        }

        private async Task Roll()
        {
            var random = new Random(DateTime.Now.Millisecond);

            var rollTasks = Dices!.Where(x => !x.IsLocked).Select(x => RollAsync(random, x));

            await Task.WhenAll(rollTasks);
            OnPropertyChanged(nameof(Sum));
        }

        private static async Task RollAsync(Random random, Dice dice)
        {
            for (var i = 0; i < random.Next(25, 75); i++)
            {
                dice.Value = random.Next(1, 7);
                await Task.Delay(25);
            }
        }

        private void DiceLock(Dice dice)
        {
            dice.IsLocked = !dice.IsLocked;
        }
    }
}
