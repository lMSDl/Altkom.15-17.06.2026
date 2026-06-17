using System.ComponentModel;
using System.Windows.Input;

namespace Toolkit.MVVM.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand OnLoadedCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseViewModel()
        {

            OnLoadedCommand = new Commands.RelayCommand(async () => await OnLoaded());

        }

        protected virtual Task OnLoaded()
        {
            return Task.CompletedTask;
        }
    }
}
