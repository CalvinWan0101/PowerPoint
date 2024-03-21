namespace PowerPoint.model.command {
    public class DeleteSlideCommand : ICommand {
        int _slideIndex;
        Shapes _shapes;

        public DeleteSlideCommand(Model model, int slideIndex) : base(model) {
            _slideIndex = slideIndex;
            _shapes = _model.GetShapes(_slideIndex);
        }

        // execute
        public override void Execute() {
            _model.RemoveSlide(_slideIndex);
        }

        // execute back
        public override void ExecuteBack() {
            _model.AddSlide(_slideIndex, _shapes);
        }
    }
}