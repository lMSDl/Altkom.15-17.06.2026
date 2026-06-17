using System.ComponentModel;
using System.Windows.Input;

namespace Toolkit.MVVM.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool isLoading;

        public ICommand OnLoadedCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseViewModel()
        {

            OnLoadedCommand = new Commands.RelayCommand(async () =>
            {
                IsLoading = true;
                try { await OnLoaded(); }
                finally { IsLoading = false; }
            });

        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        protected virtual Task OnLoaded()
        {
            return Task.CompletedTask;
        }
    }
}
