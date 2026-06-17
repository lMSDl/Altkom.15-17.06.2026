using System.Windows.Input;

namespace Dices.Commands
{
    internal class RelayGenericCommand<T> : BaseCommand
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

        public override bool CanExecute(object? parameter)
        {
            return _canExecute((T)parameter!);
        }

        public override void Execute(object? parameter)
        {
            _execute((T)parameter!);
        }
    }
}
