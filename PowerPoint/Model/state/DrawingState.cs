using System.Drawing;

namespace PowerPoint.model.state
{
    public class DrawingState : IState
    {
        private Model _model;

        private PointF _pointA;
        private string _shapeName;
        private bool _isMousePressed = false;

        // for the test
        public bool IsMousePressed { get => _isMousePressed; set => _isMousePressed = value; }

        // for the test
        public string ShapeName { get => _shapeName; set => _shapeName = value; }

        public DrawingState(Model model)
        {
            _model = model;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            _isMousePressed = true;
            _pointA = point;
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            if (_isMousePressed)
            {
                _model.GetShapes().SetHint(_shapeName, _pointA, point);
                _model.NotifyModelChanged();
            }
        }

        // mouse release
        public void MouseRelease(PointF point)
        {
            if (_isMousePressed)
            {
                _isMousePressed = false;
                if (_shapeName != null)
                {
                    _model.GetShapes().SetHint(_shapeName, _pointA, point);
                    _model.GetShapes().AddHint();
                    _model.NotifyModelChanged();
                    _shapeName = null;
                }
            }
        }
    }
}
