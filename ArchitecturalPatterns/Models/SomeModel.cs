namespace ArchitecturalPatterns.Models
{
    internal class SomeModel : NotifyPropertyChanged
    {
        private string _value = string.Empty;

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}
