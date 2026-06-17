using System.Windows.Input;

namespace ArchitecturalPatterns.Commands
{

    //RelayCommand to klasa implementująca interfejs ICommand, która pozwala na przekazanie akcji do wykonania oraz warunku, który określa, czy akcja może być wykonana.
    //Jest to przydatne w architekturze MVVM do powiązania logiki biznesowej z interfejsem użytkownika.
    internal class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public RelayCommand(Action<object?> execute)
        {
            _execute = execute;
        }
        //opcjonalny konstruktor, który pozwala na przekazanie funkcji określającej, czy akcja może być wykonana.
        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute) : this(execute)
        {
            _canExecute = canExecute;
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        // Zdarzenie CanExecuteChanged jest wywoływane, gdy zmienia się stan wykonywalności polecenia.
        // W tym przypadku korzystamy z CommandManager.RequerySuggested, który automatycznie powiadamia interfejs użytkownika o zmianach stanu wykonywalności poleceń w WPF.
        public event EventHandler? CanExecuteChanged
        {
            add {
                CommandManager.RequerySuggested += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
            }
        }

        //Metoda RaiseCanExecuteChanged() jest używana do ręcznego wywołania zdarzenia CanExecuteChanged, które informuje interfejs użytkownika, że stan wykonywalności polecenia uległ zmianie.
        //W tym przypadku metoda ta jest zakomentowana, ponieważ korzystamy z CommandManager.RequerySuggested.
        /*public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }*/
    }
}
