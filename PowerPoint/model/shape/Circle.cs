using PowerPoint.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.model.shape
{
    class Circle : Shape
    {
        private PointF _point1;
        private PointF _point2;

        const string CIRCLE = "Circle";
        const string CIRCLE_CHINESE = "圓";
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        public Circle(PointF point1, PointF point2)
        {
            _point1 = point1;
            _point2 = point2;
            _name = CIRCLE;
            _chineseName = CIRCLE_CHINESE;
            _information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
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
            return _information;
        }

        // function to draw the circle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_point1, _point2);
        }
    }
}