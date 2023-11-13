using PowerPoint.model.shape;
using System;
using System.Drawing;

namespace PowerPoint.model.state
{
    public class PointState : IState
    {
        private Model _model;
        private PointF _pointA;
        private bool _isPressed = false;
        private bool _shapeIsSelected = false;
        private int _targetIndex = -1;


        public PointState(Model model)
        {
            _model = model;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            _isPressed = !_isPressed;

            // first press
            _pointA = point;
            int count = _model.GetListOfShape().Count - 1;
            for (int i = count; i >= 0; i--)
            {
                if (_model.GetListOfShape()[i].Contains(point))
                {
                    _targetIndex = i;
                }
            }
            if (_targetIndex != -1)
                _shapeIsSelected = true;
            else
                _shapeIsSelected = false;
            if (_shapeIsSelected)
                Console.WriteLine("The point is in the shape: " + _model.GetListOfShape()[_targetIndex].GetShapeName());
            else
                Console.WriteLine("The point is not in the shape");

            // ControlPaint.DrawReversibleFrame();
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            // move the shape
            if (_targetIndex != -1 && _isPressed && _shapeIsSelected)
            {
                _model.GetListOfShape()[_targetIndex].Move(_pointA, point);
                _pointA = point;
                _model.NotifyModelChanged();
            }
        }

        // mouse release
        public void MouseRelease(PointF point)
        {
            if (_targetIndex != -1 && _isPressed && _shapeIsSelected)
            {
                _model.GetListOfShape()[_targetIndex].Move(_pointA, point);
                _model.NotifyModelChanged();
            }
            _isPressed = false;
            _targetIndex = -1;
        }

        // user click delete button
        public void ClickDeleteButton()
        {
            if (_targetIndex != -1 && _shapeIsSelected)
            {
                _model.Remove(_targetIndex);
                _targetIndex = -1;
            }
        }
    }
}
