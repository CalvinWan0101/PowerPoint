using PowerPoint.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        private int _x1;
        private int _x2;
        private int _y1;
        private int _y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;

            const string RECTANGLE = "Rectangle";
            _name = RECTANGLE;
        }

        // get the position of rectangle
        public override string GetInformation()
        {
            const string LEFT_BRACKET = "(";
            const string RIGHT_BRACKET = ")";
            const string COMMA = ", ";
            return LEFT_BRACKET + _x1.ToString() + COMMA + _y1.ToString() + RIGHT_BRACKET + COMMA + LEFT_BRACKET + _x2.ToString() + COMMA + _y2.ToString() + RIGHT_BRACKET;
        }

        // get the name of rectangle
        public override string GetShapeName()
        {
            return _name;
        }
    }
}