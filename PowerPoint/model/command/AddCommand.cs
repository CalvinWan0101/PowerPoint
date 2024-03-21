using System;
using System.Drawing;

namespace PowerPoint.model.command {
    public class AddCommand : ICommand {
        private string _shapeName;

        // private PointF[] _position = new PointF[2];
        private PointF _pointA;
        private PointF _pointB;
        private string _id;
        private int _slideIndex;

        public string Id {
            set { _id = value; }
            get { return _id; }
        }

        public AddCommand(Model model, string shapeName, PointF pointA, PointF pointB) : base(model) {
            _shapeName = shapeName;
            _pointA = pointA;
            _pointB = pointB;
            _slideIndex = model.SlideIndex;
        }

        // execute
        public override void Execute() {
            _model.GetShapes(_slideIndex).Add(_shapeName, _pointA, _pointB);
            _id = _model.GetLastShape(_slideIndex).Id;
            _model.NotifyModelChanged();
        }

        // unexecute
        public override void ExecuteBack() {
            Console.WriteLine(_slideIndex);
            _model.RemoveShapeById(_slideIndex, _id);
        }
    }
}