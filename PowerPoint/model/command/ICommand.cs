namespace PowerPoint.model.command
{
    public abstract class ICommand
    {
        protected Model _model;

        public ICommand(Model model)
        {
            this._model = model;
        }

        public abstract void Execute();
        public abstract void Unexcute();
    }
}
