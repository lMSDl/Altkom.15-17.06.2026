namespace WpfApp.Models
{
    //partial - pozwala podzielić definicję klasy na wiele plików, co jest przydatne w dużych projektach lub przy generowaniu kodu.
    //wymagania: wszystkie części klasy muszą być oznaczone jako partial, muszą mieć tę samą nazwę i znajdować się w tym samym namespace oraz tym samym assembly.
    internal partial class Item
    {
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Description: {Description}, Price: {Price:C}");
        }
    }
}
