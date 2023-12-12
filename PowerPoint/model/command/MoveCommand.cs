using PowerPoint.model.shape;
using System.Drawing;

namespace PowerPoint.model.command
{
    public class MoveCommand : ICommand
    {
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        private int _targetIndex;
        private PointF _originPoint1;
        private PointF _originPoint2;

        private PointF _originDrawPoint1;
        private PointF _originDrawPoint2;

        private PointF _startPoint;
        private PointF _endPoint;

        private PointF _point1;
        private PointF _point2;

        public MoveCommand(Model model, int targetIndex, PointF startPoint, PointF endPoint, PointF pointRecord1, PointF pointRecord2, PointF originDrawPoint1, PointF originDrawPoint2) : base(model)
        {
            _targetIndex = targetIndex;
            _startPoint = startPoint;
            _endPoint = endPoint;
            _originPoint1 = pointRecord1;
            _originPoint2 = pointRecord2;

            if (_model.GetListOfShape()[_targetIndex] is Line line)
            {
                _originDrawPoint1 = originDrawPoint1;
                _originDrawPoint2 = originDrawPoint2;
            }
        }

        public override void Execute()
        {
            //_point1 = _originPoint1 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);
            //_point2 = _originPoint2 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);
            //_model.GetListOfShape()[_targetIndex].Point1 = _point1;
            //_model.GetListOfShape()[_targetIndex].Point2 = _point2;
            //_model.GetListOfShape()[_targetIndex].Information = string.Format(TEMPLATE, (int)this._point1.X, (int)this._point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
            //_model.NotifyModelChanged();

            _point1 = _originPoint1 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);
            _point2 = _originPoint2 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);
            _model.GetListOfShape()[_targetIndex].Point1 = _point1;
            _model.GetListOfShape()[_targetIndex].Point2 = _point2;

            if (_model.GetListOfShape()[_targetIndex] is Line line)
            {
                line.DrawPoint1 = _originDrawPoint1 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);
                line.DrawPoint2 = _originDrawPoint2 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);
            }

            _model.GetListOfShape()[_targetIndex].Information = string.Format(TEMPLATE, (int)this._point1.X, (int)this._point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
            _model.NotifyModelChanged();

        }

        public override void Unexcute()
        {
            _model.GetListOfShape()[_targetIndex].Point1 = _originPoint1;
            _model.GetListOfShape()[_targetIndex].Point2 = _originPoint2;
            if (_model.GetListOfShape()[_targetIndex] is Line line)
            {
                line.DrawPoint1 = _originDrawPoint1;
                line.DrawPoint2 = _originDrawPoint2;
            }
            _model.GetListOfShape()[_targetIndex].Information = string.Format(TEMPLATE, (int)this._originPoint1.X, (int)this._originPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)_originPoint2.X, (int)_originPoint2.Y);
            _model.NotifyModelChanged();
        }
    }
}
