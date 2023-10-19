using PowerPoint.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shapes
    {
        private List<Shape> _shapes = new List<Shape>();

        // add a new shape to the end of the list
        public Shape Add(string shapeName, params int[] position)
        {
            _shapes.Add(Factory.CreateShape(shapeName, position));
            return Factory.CreateShape(shapeName, position);
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
    }
}
