﻿using PowerPoint.model.shape;
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
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            // move the shape
            if (_targetIndex != -1 && _isPressed)
            {
                _model.GetListOfShape()[_targetIndex].Move(_pointA, point);
                _pointA = point;
                _model.NotifyModelChanged();
            }
        }

        // mouse release
        public void MouseRelease(PointF point)
        {
            if (_targetIndex != -1 && _isPressed)
            {
                _model.GetListOfShape()[_targetIndex].Move(_pointA, point);
                _model.NotifyModelChanged();
            }
            _isPressed = false;
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
