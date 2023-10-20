using PowerPoint.Properties;
using System.Drawing;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        private PointF _point1;
        private PointF _point2;

        public Rectangle(float x1, float y1, float x2, float y2)
        {
            _point1 = new PointF(x1, y1);
            _point2 = new PointF(x2, y2);
            const string RECTANGLE = "Rectangle";
            const string RECTANGLE_CHINESE = "矩形";
            _name = RECTANGLE;
            _chineseName = RECTANGLE_CHINESE;
        }

        // get the name of rectangle
        public override string GetShapeName()
        {
            return _name;
        }

        // get the chinese name of rectangle
        public override string GetShapeChineseName()
        {
            return _chineseName;
        }

        // get the position of rectangle
        public override string GetInformation()
        {
            const string LEFT_BRACKET = "(";
            const string RIGHT_BRACKET = ")";
            const string COMMA = ", ";
            return LEFT_BRACKET + _point1.X.ToString() + COMMA + _point1.Y.ToString() + RIGHT_BRACKET + COMMA + LEFT_BRACKET + _point2.X.ToString() + COMMA + _point2.Y.ToString() + RIGHT_BRACKET;
        }
        
        // function to draw the rectangle
        public override void Draw()
        {
        }
    }
}