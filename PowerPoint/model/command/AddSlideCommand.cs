namespace PowerPoint.model.command
{
    public class AddSlideCommand : ICommand
    {
        public AddSlideCommand(Model model) : base(model)
        {
        }

        public override void Execute()
        {
        }

        public override void ExecuteBack()
        {
        }
    }
}
