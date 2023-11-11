using PowerPoint.model.shape;
using PowerPoint.presentation_model;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private Shapes _shapes;

        public Model()
        {
            _shapes = new Shapes();
        }

        // this function is to add the Shape into Shapes (with concrete number)
        public void Add(string shapeName, params PointF[] position)
        {
            _shapes.Add(shapeName, position);
            NotifyModelChanged();
        }

        // this function is to add the Shape into Shapes (with random number)
        public Shape Add(string shapeName)
        {
            Shape shape = _shapes.Add(shapeName);
            NotifyModelChanged();
            return shape;
        }

        // this function is to add the Shape into Shapes (with exist shape)
        public Shape Add(Shape shape)
        {
            _shapes.Add(shape);
            NotifyModelChanged();
            return shape;
        }

        // this function is to remove the Shape into Shapes
        public void Remove(int targetIndex)
        {
            _shapes.Remove(targetIndex);
            NotifyModelChanged();
        }

        // clear all the shape
        public void Clear()
        {
            _shapes.Clear();
            NotifyModelChanged();
        }

        // get shapes
        public BindingList<Shape> GetShapes()
        {
            return _shapes.GetListOfShape();
        }

        // draw all the shape
        public void Draw(IGraphics graphics, bool isPressed, Shape hint)
        {
            graphics.ClearAll();
            foreach (Shape shape in _shapes.GetListOfShape())
                shape.Draw(graphics);
            if (isPressed && hint != null)
                hint.Draw(graphics);
        }

        // notify model changed
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
