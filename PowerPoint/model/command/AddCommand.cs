using System;
using System.Drawing;

namespace PowerPoint.model.command
{
    public class AddCommand : ICommand
    {
        const int TWO = 2;

        private string _shapeName;
        private PointF[] _position = new PointF[TWO];
        private string _id;
        private int _slideIndex;

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
            _slideIndex = model.SlideIndex;
        }

        // execute
        public override void Execute()
        {
            _model.GetShapes(_slideIndex).Add(_shapeName, _position);
            _id = _model.GetLastShape(_slideIndex).Id;
            _model.NotifyModelChanged();
        }

        // unexecute
        public override void ExecuteBack()
        {
            Console.WriteLine(_slideIndex);
            _model.RemoveShapeById(_slideIndex, _id);
        }
    }
}
