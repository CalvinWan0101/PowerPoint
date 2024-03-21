using PowerPoint.model.shape;

namespace PowerPoint.model.command {
    public class DeleteCommand : ICommand {
        private int _index;
        private Shape _shape;
        private int _slideIndex;

        public DeleteCommand(Model model, int index) : base(model) {
            _index = index;
            _slideIndex = model.SlideIndex;
        }

        // execute
        public override void Execute() {
            _shape = _model.GetListOfShape(_slideIndex)[_index];
            _model.GetShapes(_slideIndex).Remove(_index);
            _model.NotifyModelChanged();
        }

        // unexecute
        public override void ExecuteBack() {
            _model.GetShapes(_slideIndex).Add(_shape);
            _model.NotifyModelChanged();
        }
    }
}