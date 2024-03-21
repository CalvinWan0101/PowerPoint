namespace PowerPoint.model.command {
    public abstract class ICommand {
        protected Model _model;

        public ICommand(Model model) {
            this._model = model;
        }

        // execute
        public abstract void Execute();

        // unexecute
        public abstract void ExecuteBack();
    }
}