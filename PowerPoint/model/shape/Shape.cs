using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Properties
{
    public abstract class Shape
    {
        protected string _name;

        // function to get the chinese name of the shape
        public abstract string GetShapeChineseName();

        // function to get the name of the shape
        public abstract string GetShapeName();

        // function to get the information of the shape
        public abstract string GetInformation();

        // function to draw the shape
        public abstract void Draw();
    }
}
