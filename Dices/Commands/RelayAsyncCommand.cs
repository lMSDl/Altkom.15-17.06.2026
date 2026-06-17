using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dices.Commands
{
    internal class RelayAsyncCommand : BaseCommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private bool _isWorking;

        public RelayAsyncCommand(Func<Task> execute) : this(execute, () => true)
        { }
        public RelayAsyncCommand(Func<Task> execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return !_isWorking && _canExecute();
        }

        public override void Execute(object? parameter)
        {
            _isWorking = true;
            _execute().ContinueWith(t =>
            {
                _isWorking = false;
            });
        }
    }
}
