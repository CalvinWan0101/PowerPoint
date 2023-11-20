using System.Drawing;

namespace PowerPoint.model.state
{
    public class PointState : IState
    {
        private Model _model;
        private PointF _pointA;
        private bool _isPressed = false;
        private int _targetIndex = -1;
        private bool _isZoom = false;

        public PointState(Model model)
        {
            _model = model;
        }

        // get target index
        public int GetTargetIndex()
        {
            return _targetIndex;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            _isPressed = !_isPressed;
            _pointA = point;
            _targetIndex = _model.FindTargetIndex(point);
            _isZoom = IsZoom(point);
        }

        // is zoom
        public bool IsZoom(PointF point)
        {
            const int RADIUS = 50;
            if (_targetIndex != -1)
            {
                PointF temp = _model.GetListOfShape()[_targetIndex].GetPoint2();
                if (_targetIndex != -1 && temp.X + RADIUS >= point.X && temp.X - RADIUS <= point.X && temp.Y + RADIUS >= point.Y && temp.Y - RADIUS <= point.Y)
                {
                    return true;
                }
            }
            return false;
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            // move the shape
            if (_targetIndex != -1 && _isPressed)
            {
                if (_isZoom)
                {
                    _model.GetListOfShape()[_targetIndex].Zoom(_pointA, point);
                    _pointA = point;
                    _model.NotifyModelChanged();
                } else
                {
                    _model.GetListOfShape()[_targetIndex].Move(_pointA, point);
                    _pointA = point;
                    _model.NotifyModelChanged();
                }
            }
        }

        // mouse release
        public void MouseRelease(PointF point)
        {
            if (_targetIndex != -1 && _isPressed)
            {
                if (_isZoom)
                {
                    IsZoomMouseRelease(point);
                } else
                {
                    IsNotZoomMouseRelease(point);
                }
            }
            _isPressed = false;
        }

        // mouse release when mouse release
        private void IsZoomMouseRelease(PointF point)
        {
            _isZoom = false;
            _model.GetListOfShape()[_targetIndex].Zoom(_pointA, point);
            _model.GetListOfShape()[_targetIndex].UpdatePoint();
            _pointA = point;
            _model.NotifyModelChanged();
        }

        // mouse release when mouse not release
        private void IsNotZoomMouseRelease(PointF point)
        {
            _model.GetListOfShape()[_targetIndex].Move(_pointA, point);
            _model.GetListOfShape()[_targetIndex].UpdatePoint();
            _pointA = point;
            _model.NotifyModelChanged();
        }

        // user click delete button
        public void ClickDeleteButton()
        {
            if (_targetIndex != -1)
            {
                _model.Remove(_targetIndex);
                _targetIndex = -1;
            }
        }
    }
}
