using PowerPoint.model;
using PowerPoint.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        private PointF _point1;
        private PointF _point2;

        public Rectangle(PointF point1, PointF point2)
        {
            _point1 = point1;
            _point2 = point2;
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
            const string COMMA = ", ";
            const string TEMPLATE = "({0:D3}, {1:D3})";
            return string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // function to draw the rectangle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_point1, _point2);
        }
    }
}