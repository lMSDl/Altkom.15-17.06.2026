using ArchitecturalPatterns.Models;

namespace ArchitecturalPatterns.ViewModels
{
    internal class ViewModel
    {
        public string InputValue { get; set; } = string.Empty;
        public SomeModel Model { get; set; } = new SomeModel() { Value = "ala ma kota"};
    }
}
