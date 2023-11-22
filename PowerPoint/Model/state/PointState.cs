using System;
using System.Drawing;

namespace PowerPoint.model.state
{
    public class PointState : IState
    {
        private Model _model;
        private PointF _pointA;
        private bool _mouseIsPressed = false;
        private int _targetIndex = -1;
        private bool _isZoom = false;

        // for the test
        public bool MouseIsPressed { get => _mouseIsPressed; set => _mouseIsPressed = value; }

        // for the test
        public int TargetIndex
        {
            get { return _targetIndex; }
            set { _targetIndex = value; }
        }

        // for the test
        public bool IsZoom
        {
            get { return _isZoom; }
            set { _isZoom = value; }
        }

        public PointState(Model model)
        {
            _model = model;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            _mouseIsPressed = !_mouseIsPressed;
            _pointA = point;
            _targetIndex = _model.FindTargetIndex(point);
            _isZoom = IsClickTheRightBottomCorner(point);
        }

        // is zoom
        public bool IsClickTheRightBottomCorner(PointF point)
        {
            const int RADIUS = 50;
            if (_targetIndex != -1)
            {
                PointF temp = _model.GetListOfShape()[_targetIndex].Point2;
                if (temp.X + RADIUS >= point.X && temp.X - RADIUS <= point.X && temp.Y + RADIUS >= point.Y && temp.Y - RADIUS <= point.Y)
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
            if (_targetIndex != -1 && _mouseIsPressed)
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
            if (_targetIndex != -1 && _mouseIsPressed)
            {
                if (_isZoom)
                {
                    IsZoomMouseRelease(point);
                } else
                {
                    IsNotZoomMouseRelease(point);
                }
            }
            _mouseIsPressed = false;
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
