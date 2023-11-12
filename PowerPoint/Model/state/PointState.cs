using System;
using System.Drawing;

namespace PowerPoint.model.state
{
    public class PointState : IState
    {
        private Model _model;
        
        public PointState(Model model)
        {
            _model = model;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            throw new NotImplementedException();
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
