using PowerPoint.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint.model.shape
{
    class Circle : Shape
    {
        private PointF _point1;
        private PointF _point2;

        public Circle(float x1, float y1, float x2, float y2)
        {
            _point1 = new PointF(x1, y1);
            _point2 = new PointF(x2, y2);
            const string CIRCLE = "Circle";
            const string CIRCLE_CHINESE = "圓";
            _name = CIRCLE;
            _chineseName = CIRCLE_CHINESE;
        }

        // get the name of circle
        public override string GetShapeName()
        {
            return _name;
        }

        // get the chinese name of circle
        public override string GetShapeChineseName()
        {
            return _chineseName;
        }

        // get the position of circle
        public override string GetInformation()
        {
            const string LEFT_BRACKET = "(";
            const string RIGHT_BRACKET = ")";
            const string COMMA = ", ";
            return LEFT_BRACKET + _point1.X.ToString() + COMMA + _point1.Y.ToString() + RIGHT_BRACKET + COMMA + LEFT_BRACKET + _point2.X.ToString() + COMMA + _point2.Y.ToString() + RIGHT_BRACKET;
        }

        // function to draw the circle
        public override void Draw()
        {
            Console.WriteLine("test");
        }
    }
}
