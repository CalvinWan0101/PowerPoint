namespace PowerPoint.model.command {
    public class AddSlideCommand : ICommand {
        int _slideIndex;

        public AddSlideCommand(Model model) : base(model) {
            _slideIndex = model.SlideIndex;
        }

        public override void Execute() {
            _model.AddSlide();
        }

        public override void ExecuteBack() {
            _model.RemoveSlide(_slideIndex);
        }
    }
}