using System.Drawing;
using PowerPoint.model.shape;

namespace PowerPoint.model.command {
    public class ZoomCommand : ICommand {
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";
        private int _targetIndex;
        private PointF _originPoint1;
        private PointF _originPoint2;
        private PointF _originDrawPoint1;
        private PointF _originDrawPoint2;
        private PointF _endPoint;
        private PointF _point1;
        private PointF _point2;
        private int _slideIndex;

        public ZoomCommand(Model model, int targetIndex, PointF endPoint, PointF pointRecord1, PointF pointRecord2,
            PointF originDrawPoint1, PointF originDrawPoint2) : base(model) {
            _targetIndex = targetIndex;
            _endPoint = endPoint;
            _originPoint1 = pointRecord1;
            _originPoint2 = pointRecord2;

            if (_model.GetListOfShape()[_targetIndex] is Line) {
                _originDrawPoint1 = originDrawPoint1;
                _originDrawPoint2 = originDrawPoint2;
            }

            _slideIndex = model.SlideIndex;
        }

        // execute
        public override void Execute() {
            _model.GetListOfShape(_slideIndex)[_targetIndex].Zoom(_endPoint);
            _model.GetListOfShape(_slideIndex)[_targetIndex].UpdatePoint();
            _model.GetListOfShape(_slideIndex)[_targetIndex].Information =
                string.Format(TEMPLATE, (int)this._point1.X, (int)this._point1.Y) + COMMA +
                string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
            _model.NotifyModelChanged();
        }

        // unexecute
        public override void ExecuteBack() {
            _model.GetListOfShape(_slideIndex)[_targetIndex].Point1 = _originPoint1;
            _model.GetListOfShape(_slideIndex)[_targetIndex].Point2 = _originPoint2;
            if (_model.GetListOfShape(_slideIndex)[_targetIndex] is Line) {
                Line line = (Line)_model.GetListOfShape(_slideIndex)[_targetIndex];
                line.DrawPoint1 = _originDrawPoint1;
                line.DrawPoint2 = _originDrawPoint2;
            }

            _model.GetListOfShape(_slideIndex)[_targetIndex].Information =
                string.Format(TEMPLATE, (int)this._originPoint1.X, (int)this._originPoint1.Y) + COMMA +
                string.Format(TEMPLATE, (int)_originPoint2.X, (int)_originPoint2.Y);
            _model.NotifyModelChanged();
        }
    }
}