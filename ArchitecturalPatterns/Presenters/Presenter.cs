using ArchitecturalPatterns.Models;

namespace ArchitecturalPatterns.Presenters
{
    internal class Presenter : IPresenter
    {
        private readonly IView _view;
        private readonly SomeModel _model;

        public Presenter(IView view)
        {
            _model = new SomeModel();
            _view = view;
        }

        public void Load()
        {
            _view.Load(_model.Value);
        }

        public void Save(string value)
        {
            _model.Value = value;
            _view.Display(_model.Value);
        }
    }
}
