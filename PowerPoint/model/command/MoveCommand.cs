using System.Drawing;

namespace PowerPoint.model.command
{
    public class MoveCommand : ICommand
    {
        private int _targetIndex;
        private PointF _originPoint1;
        private PointF _originPoint2;
        private PointF _newPoint1;
        private PointF _newPoint2;

        public MoveCommand(Model model, int targetIndex, PointF startPoint, PointF endPoint) : base(model)
        {
            _targetIndex = targetIndex;
            _newPoint1 = _originPoint1 +new SizeF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            _newPoint2 = _originPoint2 + new SizeF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
        }

        public override void Execute()
        {
            _originPoint1 = _model.GetListOfShape()[_targetIndex].Point1;
            _originPoint2 = _model.GetListOfShape()[_targetIndex].Point2;
            _model.GetListOfShape()[_targetIndex].Point1 = _newPoint1;
            _model.GetListOfShape()[_targetIndex].Point2 = _newPoint2;
            _model.NotifyModelChanged();
        }

        public override void Unexcute()
        {
            _model.GetListOfShape()[_targetIndex].Point1 = _originPoint1;
            _model.GetListOfShape()[_targetIndex].Point2 = _originPoint2;
            _model.NotifyModelChanged();
        }
    }
}
