using ArchitecturalPatterns.Models;
using System.Windows.Input;

namespace ArchitecturalPatterns.ViewModels
{
    internal class ViewModel : NotifyPropertyChanged
    {
        private string _inputValue = string.Empty;
        public string InputValue
        {
            get => _inputValue;
            set
            {
                _inputValue = value;
                OnPropertyChanged();

                //podniesienie zdarzenia CanExecuteChanged dla poleceń SaveCommand i LoadCommand, aby UI mogło zaktualizować stan przycisków w zależności od wartości InputValue
                //zakomentowane, ponieważ korzystamy z CommandManager.RequerySuggested, które automatycznie powiadamia UI o zmianach stanu wykonywalności poleceń
                // ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
                //((RelayCommand)LoadCommand).RaiseCanExecuteChanged();
            }
        }

        public SomeModel Model { get; set; } = new SomeModel() { Value = "ala ma kota" };

        //ICommand to interfejs, który reprezentuje polecenie w architekturze MVVM. XAML używa bindingu do powiązania poleceń z akcjami w ViewModelu.
        //W tym przypadku SaveCommand i LoadCommand są właściwościami typu ICommand, które są powiązane z akcjami zapisu i odczytu danych w modelu.
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public ViewModel()
        {
            //Przykładowe implementacje poleceń SaveCommand i LoadCommand przy użyciu RelayCommand bez CanExecute.
            /*SaveCommand = new Commands.RelayCommand(_ => Model.Value = InputValue );
            LoadCommand = new Commands.RelayCommand(_ => InputValue = Model.Value);*/

            //Przykładowe implementacje poleceń SaveCommand i LoadCommand przy użyciu RelayCommand z CanExecute, które określają, czy akcja może być wykonana w zależności od wartości InputValue i Model.Value.
            /*SaveCommand = new Commands.RelayCommand(_ =>
            {
                Model.Value = InputValue;
                ((RelayCommand)LoadCommand).RaiseCanExecuteChanged();
            }, _ => !string.IsNullOrEmpty(InputValue));
            LoadCommand = new Commands.RelayCommand(_ =>
            {
                InputValue = Model.Value;
                ((RelayCommand)LoadCommand).RaiseCanExecuteChanged();
            }, _ => InputValue != Model.Value);*/

            SaveCommand = new Commands.RelayCommand(_ =>
                Model.Value = InputValue, _ => !string.IsNullOrEmpty(InputValue));
            LoadCommand = new Commands.RelayCommand(_ =>
                InputValue = Model.Value, _ => InputValue != Model.Value);
        }
    }
}
