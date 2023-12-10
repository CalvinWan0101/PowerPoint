using PowerPoint.model.shape;

namespace PowerPoint.model.command
{
    public class DeleteCommand : ICommand
    {
        private int _index;
        private Shape _shape;

        public DeleteCommand(Model model, int index) : base(model)
        {
            _index = index;
        }

        public override void Execute()
        {
            _shape = _model.GetListOfShape()[_index];
            _model.GetShapes().Remove(_index);
            _model.NotifyModelChanged();
        }

        public override void Unexcute()
        {
            _model.GetShapes().Add(_shape);
            _model.NotifyModelChanged();
        }
    }
}
