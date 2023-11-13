using PowerPoint.model.shape;
using System;
using System.Drawing;

namespace PowerPoint.model.state
{
    public class PointState : IState
    {
        private Model _model;
        private int _targetIndex = -1;

        public PointState(Model model)
        {
            _model = model;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            int count = _model.GetListOfShape().Count - 1;
            for (int i = count; i >= 0; i--)
            {
                if (_model.GetListOfShape()[i].Contains(point))
                {
                    _targetIndex = i;
                    break;
                }
            }
            if (_targetIndex == -1)
            {
                Console.WriteLine("The point is not in the shape");
            }
            else
            {
                Console.WriteLine("The point is in the shape");
            }

            // use ControlPaint.DrawReversibleFrame to draw a 可選取的外框 for _model.GetListOfShape()[i]
            // ControlPaint.DrawReversibleFrame();
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            throw new NotImplementedException();
        }

        // mouse release
        public void MouseRelease(PointF point)
        {
            throw new NotImplementedException();
        }
    }
}
