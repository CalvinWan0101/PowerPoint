using PowerPoint.model.shape;
using System;
using System.ComponentModel;
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

            if (_targetIndex != -1 &&
                _model.GetListOfShape()[_targetIndex].GetPoint2().X + 50 >= point.X &&
                _model.GetListOfShape()[_targetIndex].GetPoint2().X - 50 <= point.X &&
                _model.GetListOfShape()[_targetIndex].GetPoint2().Y + 50 >= point.Y &&
                _model.GetListOfShape()[_targetIndex].GetPoint2().Y - 50 <= point.Y)
            {
                _isZoom = true;
                Console.WriteLine("in");
            }
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
                    _isZoom = false;
                    _model.GetListOfShape()[_targetIndex].Zoom(_pointA, point);
                    _model.GetListOfShape()[_targetIndex].UpdatePoint();
                    _pointA = point;
                    _model.NotifyModelChanged();
                } else
                {
                    _model.GetListOfShape()[_targetIndex].Move(_pointA, point);
                    _model.GetListOfShape()[_targetIndex].UpdatePoint();
                    _pointA = point;
                    _model.NotifyModelChanged();
                }
            }
            _isPressed = false;
            Console.WriteLine(_targetIndex);
            if (_model.FindTargetIndex(point) == -1)
            {
                _model.NotifyModelChanged();
            }
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
