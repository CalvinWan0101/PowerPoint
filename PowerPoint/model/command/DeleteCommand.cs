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

        // execute
        public override void Execute()
        {
            _shape = _model.GetListOfShape()[_index];
            _model.GetShapes().Remove(_index);
            _model.NotifyModelChanged();
        }

        // unexecute
        public override void ExecuteBack()
        {
            _model.GetShapes().Add(_shape);
            _model.NotifyModelChanged();
        }
    }
}
