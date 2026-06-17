namespace ArchitecturalPatterns.Presenters
{
    internal interface IView
    {
        void Display(string value);
        void Load(string value);
    }
}
