using PowerPoint.model;
using PowerPoint.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace PowerPoint
{
    public class Model
    {
        private Shapes _shapes;
        private PointF _firstPoint;
        private bool _isPressed = false;
        private Shape _hint;

        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();


        public Model()
        {
            _shapes = new Shapes();
        }

        // this function is to add the Shape into Shapes (with concrete number)
        public Shape Add(string shapeName, params PointF[] position)
        {
            Shape shape = _shapes.Add(shapeName, position);
            NotifyModelChanged();
            return shape;
        }

        // this function is to add the Shape into Shapes (with random number)
        public Shape Add(string shapeName)
        {
            Shape shape = _shapes.Add(shapeName);
            NotifyModelChanged();
            return shape;
        }

        // this function is to remove the Shape into Shapes
        public void Remove(int targetIndex)
        {
            _shapes.Remove(targetIndex);
            NotifyModelChanged();
        }

        // get shapes
        public List<Shape> Shapes()
        {
            return _shapes.GetListOfShape();
        }

        // press the mouse
        public void PointerPressed(float x, float y)
        {
            if (x > 0 && y > 0)
            {
                _firstPoint = new PointF(x, y);
                _isPressed = true;
            }
        }

        // move the mouse
        public void PointerMoved(string name, float x, float y)
        {
            if (_isPressed)
            {
                _hint = Factory.CreateShape(name, _firstPoint, new PointF(x, y));
                NotifyModelChanged();
            }
        }

        // release the mouse
        public Shape PointerReleased(string name, float x, float y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (_hint != null)
                {
                    _hint = Factory.CreateShape(name, _firstPoint, new PointF(x, y));
                    _shapes.Add(_hint);
                    NotifyModelChanged();
                }
                return _hint;
            }
            return null;
        }

        // clear all the shape
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // draw all the shape
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape shape in _shapes.GetListOfShape())
                shape.Draw(graphics);
            if (_isPressed && _hint != null)
                _hint.Draw(graphics);
        }

        // notify model changed
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

    }
}
