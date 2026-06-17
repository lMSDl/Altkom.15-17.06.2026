using System.Windows.Input;

namespace Dices.Commands
{
    internal class RelayCommand : BaseCommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute) : this(execute, () => true)
        {
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute();
        }

        public override void Execute(object? parameter)
        {
            _execute();
        }
    }
}
