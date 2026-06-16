using System.ComponentModel;

namespace Dices.Models
{
    public class Dice : INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }

        private bool _isLocked;
        public bool IsLocked
        {
            get => _isLocked;
            set
            {
                if (_isLocked != value)
                {
                    _isLocked = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLocked)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


    }

}
