using PowerPoint.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        private Shapes _shapes;

        public Model()
        {
            _shapes = new Shapes();
        }

        // this function is to add the Shape into Shapes
        public Shape Add(string shapeName, params int[] position)
        {
            return _shapes.Add(shapeName, position);
        }

        // this function is to remove the Shape into Shapes
        public void Remove(int targetIndex)
        {
            _shapes.Remove(targetIndex);
        }
    }


}
