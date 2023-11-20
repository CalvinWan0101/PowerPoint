using System.Drawing;

namespace PowerPoint.model.state
{
    public class DrawingState : IState
    {
        private Model _model;

        private PointF _pointA;
        private string _shapeName;
        private bool _mouseIsPressed = false;

        // for the test
        public bool MouseIsPressed
        {
            get { return _mouseIsPressed; }
            set { _mouseIsPressed = value; }
        }

        // for the test
        public string ShapeName
        {
            get { return _shapeName; }
            set { _shapeName = value; }
        }

        public DrawingState(Model model)
        {
            _model = model;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            _mouseIsPressed = true;
            _pointA = point;
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            if (_mouseIsPressed)
            {
                _model.GetShapes().SetHint(_shapeName, _pointA, point);
                _model.NotifyModelChanged();
            }
        }

        // mouse release
        public void MouseRelease(PointF point)
        {
            if (_mouseIsPressed)
            {
                _mouseIsPressed = false;
                if (_shapeName != null)
                {
                    _model.GetShapes().SetHint(_shapeName, _pointA, point);
                    _model.GetShapes().AddHint();
                    _model.NotifyModelChanged();
                    _shapeName = null;
                }
            }
        }

        // clear all the shape
        public void Clear()
        {
            _model.GetShapes().Clear();
            _model.NotifyModelChanged();
        }
    }
}
