using PowerPoint.model;
using PowerPoint.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace PowerPoint
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private Shapes _shapes;
        private Factory _factory;
        private PointF _firstPoint;
        private bool _isPressed = false;
        private Shape _hint;

        public Model()
        {
            _shapes = new Shapes();
            _factory = new Factory();
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
        public List<Shape> GetShapes()
        {
            return _shapes.GetListOfShape();
        }

        // press the mouse
        public void PressPointer(float pointX, float pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _firstPoint = new PointF(pointX, pointY);
                _isPressed = true;
            }
        }

        // move the mouse
        public void MovePointer(string name, float pointX, float pointY)
        {
            if (_isPressed)
            {
                _hint = _factory.CreateShape(name, _firstPoint, new PointF(pointX, pointY));
                NotifyModelChanged();
            }
        }

        // release the mouse
        public Shape ReleasePointer(string name, float pointX, float pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (_hint != null)
                {
                    _hint = _factory.CreateShape(name, _firstPoint, new PointF(pointX, pointY));
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
