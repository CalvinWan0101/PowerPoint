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
            _id = _model.GetListOfShape()[_model.GetListOfShape().Count - 1].Id;
            _model.NotifyModelChanged();
        }

        // unexecute
        public override void ExecuteBack()
        {
            for (int i = 0; i < _model.GetListOfShape().Count; i++)
            {
                if (_model.GetListOfShape()[i].Id == _id)
                {
                    _model.GetShapes().Remove(i);
                    break;
                }
            }
            _model.NotifyModelChanged();
        }
    }
}
