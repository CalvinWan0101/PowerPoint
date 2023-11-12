using PowerPoint.model.shape;
using PowerPoint.presentation_model;
using System;
using System.Drawing;

namespace PowerPoint.model.state
{
    public class DrawingState : IState
    {
        private Model _model;

        private PointF _pointA;
        private string _shapeName;
        private bool _mouseIsPressed = false;

        public DrawingState(Model model)
        {
            _model = model;
        }

        // set shape name
        public void SetShapeName(string shapeName)
        {
            _shapeName = shapeName;
        }

        // mouse press
        public void MousePress(PointF point)
        {
            _mouseIsPressed = true;
            _pointA = point;
            Console.WriteLine("MousePress");
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            if (_mouseIsPressed)
            {
                _model.GetShapes().SetHint(_shapeName, _pointA, point);
                _model.NotifyModelChanged();
                Console.WriteLine("MouseMove");
                Console.WriteLine(_model.GetShapes().GetHint().GetShapeName());
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
                Console.WriteLine("MouseRelease");
            }
        }

        // draw all the shape
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape shape in _model.GetListOfShape())
                shape.Draw(graphics);
            if (_mouseIsPressed && _model.GetShapes().GetHint() != null)
                _model.GetShapes().GetHint().Draw(graphics);
        }

        // clear all the shape
        public void Clear()
        {
            _model.GetShapes().Clear();
            _model.NotifyModelChanged();
        }
    }
}
