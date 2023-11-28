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
        public bool MouseIsPressed
        {
            get
            {
                return _mouseIsPressed;
            }
            set
            {
                _mouseIsPressed = value;
            }
        }

        // for the test
        public int TargetIndex
        {
            get
            {
                return _targetIndex;
            }
            set
            {
                _targetIndex = value;
            }
        }

        // for the test
        public bool IsZoom
        {
            get
            {
                return _isZoom;
            }
            set
            {
                _isZoom = value;
            }
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
            _model.NotifyModelChanged();
        }

        // is zoom
        public bool IsClickTheRightBottomCorner(PointF point)
        {
            const int RADIUS = 10;
            if (_targetIndex != -1)
            {
                if (_targetIndex < _model.GetListOfShape().Count)
                {
                    PointF temp = _model.GetListOfShape()[_targetIndex].Point2;
                    if (temp.X + RADIUS >= point.X && temp.X - RADIUS <= point.X && temp.Y + RADIUS >= point.Y && temp.Y - RADIUS <= point.Y)
                    {
                        return true;
                    }
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
                    _model.GetListOfShape()[_targetIndex].Zoom(point);
                    _pointA = point;
                    _model.NotifyModelChanged();
                }
                else
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
                }
                else
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
            _model.GetListOfShape()[_targetIndex].Zoom(point);
            _model.GetListOfShape()[_targetIndex].UpdatePoint();
            //PointF temp1 = _model.GetListOfShape()[_targetIndex].Point1;
            //PointF temp2 = _model.GetListOfShape()[_targetIndex].Point2;
            //_model.GetListOfShape()[_targetIndex].Point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            //_model.GetListOfShape()[_targetIndex].Point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y)); 
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
