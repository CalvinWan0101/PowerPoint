﻿using PowerPoint.model.shape;
using System.Drawing;

namespace PowerPoint.model.state
{
    public class PointState : IState
    {
        private Model _model;
        private PointF _pointA;
        private PointF _pointRecord1;
        private PointF _pointRecord2;
        private PointF _drawPointRecord1;
        private PointF _drawPointRecord2;
        private PointF _startPointRecord;
        private bool _mouseIsPressed = false;
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

        public PointF PointRecord1
        {
            get
            {
                return _pointRecord1;
            }
            set
            {
                _pointRecord1 = value;
            }
        }

        public PointF PointRecord2
        {
            get
            {
                return _pointRecord2;
            }
            set
            {
                _pointRecord2 = value;
            }
        }

        public PointF DrawPointRecord1
        {
            get
            {
                return _drawPointRecord1;
            }
            set
            {
                _drawPointRecord1 = value;
            }
        }

        public PointF DrawPointRecord2
        {
            get
            {
                return _drawPointRecord2;
            }
            set
            {
                _drawPointRecord2 = value;
            }
        }

        public PointState(Model model)
        {
            _model = model;
        }

        private int _targetIndex = -1;

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

        // mouse press
        public void MousePress(PointF point)
        {
            _mouseIsPressed = !_mouseIsPressed;
            _pointA = point;
            _startPointRecord = point;
            _targetIndex = _model.FindTargetIndex(point);
            _isZoom = IsClickTheRightBottomCorner(point);
            _model.NotifyModelChanged();
            //if (_targetIndex != -1) 
            //{
            //    _pointRecord1 = _model.GetShapeByIndex(_targetIndex).Point1;
            //    _pointRecord2 = _model.GetShapeByIndex(_targetIndex).Point2;
            //    if (_model.GetShapeByIndex(_targetIndex) is Line)
            //    {
            //        Line line = (Line)_model.GetShapeByIndex(_targetIndex);
            //        _drawPointRecord1 = line.DrawPoint1;
            //        _drawPointRecord2 = line.DrawPoint2;
            //    }
            //}
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
            _pointA = point;
            _model.NotifyModelChanged();
        }

        // mouse release when mouse not release
        private void IsNotZoomMouseRelease(PointF point)
        {
            //_model.GetListOfShape()[_targetIndex].Move(_pointA, point);
            //_model.NotifyModelChanged();
            _model.MoveCommand(_targetIndex, _startPointRecord, point);
        }

        // user click delete button
        public void ClickDeleteButton()
        {
            if (_targetIndex != -1)
            {
                _model.Remove(_targetIndex);
                _targetIndex = -1;
                _model.TargetIndex = -1;
            }
        }
    }
}
