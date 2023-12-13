using System.Drawing;

namespace PowerPoint.model.command
{
    public class AddCommand : ICommand
    {
        const int TWO = 2;

        private string _shapeName;
        private PointF[] _position = new PointF[TWO];
        private string _id;

        public string Id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }

        public AddCommand(Model model, string shapeName, params PointF[] position) : base(model)
        {
            _shapeName = shapeName;
            _position = position;
        }

        // execute
        public override void Execute()
        {
            _model.GetShapes().Add(_shapeName, _position);
            _id = _model.GetLastShape().Id;
            _model.NotifyModelChanged();
        }

        // unexecute
        public override void ExecuteBack()
        {
            _model.RemoveShapeById(_id);
        }
    }
}
