using System.Windows.Input;

namespace Dices.Commands
{
    internal class RelayGenericCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T,bool> _canExecute;

        public RelayGenericCommand(Action<T> execute) : this(execute, (_) => true)
        {
        }
        public RelayGenericCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute((T)parameter!);
        }

        public void Execute(object? parameter)
        {
            _execute((T)parameter!);
        }
    }
}
