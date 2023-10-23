using PowerPoint.Properties;
using System.Collections.Generic;

namespace PowerPoint
{
    public class Model
    {
        private Shapes _shapes;

        public Model()
        {
            _shapes = new Shapes();
        }

        // this function is to add the Shape into Shapes (with concrete number)
        public Shape Add(string shapeName, params int[] position)
        {
            return _shapes.Add(shapeName, position);
        }

        // this function is to add the Shape into Shapes (with random number)
        public Shape Add(string shapeName)
        {
            return _shapes.Add(shapeName);
        }

        // this function is to remove the Shape into Shapes
        public void Remove(int targetIndex)
        {
            _shapes.Remove(targetIndex);
        }

        // get shapes
        public List<Shape> Shapes()
        {
            return _shapes.GetListOfShape();
        }
    }
}
