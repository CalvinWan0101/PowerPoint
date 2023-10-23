using PowerPoint.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace PowerPoint
{
    public class Shapes
    {
        private List<Shape> _shapes = new List<Shape>();

        // add a new shape to the end of the list (with concrete number)
        public Shape Add(string shapeName, params PointF[] position)
        {
            Shape shape = Factory.CreateShape(shapeName, position);
            _shapes.Add(shape);
            return shape;
        }

        // add a new shape to the end of the list (with random number)
        public Shape Add(string shapeName)
        {
            Shape shape = Factory.CreateShape(shapeName);
            _shapes.Add(shape);
            return shape;
        }

        // add a new shape to the end of the list (with random number)
        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        // remove the shape depend on its index
        public void Remove(int targetIndex)
        {
            int count = 0;
            foreach (Shape shape in _shapes)
            {
                if (count == targetIndex)
                {
                    _shapes.Remove(shape);
                    break;
                }
                count++;
            }
        }

        // clear all the shape
        public void Clear()
        {
            _shapes.Clear();
        }

        // get shapes
        public List<Shape> GetListOfShape()
        {
            return _shapes;
        }
    }
}
