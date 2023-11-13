using PowerPoint.presentation_model;
using System.Drawing;

namespace PowerPoint.model.shape
{
    class Rectangle : Shape
    {
        private PointF _point1;
        private PointF _point2;
        const string RECTANGLE = "Rectangle";
        const string RECTANGLE_CHINESE = "矩形";
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        public Rectangle(PointF point1, PointF point2)
        {
            _point1 = point1;
            _point2 = point2;
            _name = RECTANGLE;
            _chineseName = RECTANGLE_CHINESE;
            _information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
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
            return _information;
        }

        // function to check if the rectangle contains the point
        public override bool Contains(PointF point)
        {
            return (point.X - _point1.X) * (point.X - _point1.X) + (point.Y - _point1.Y) * (point.Y - _point1.Y) <= (_point2.X - _point1.X) * (_point2.X - _point1.X);
        }

        // function to move the rectangle
        public override void Move(PointF firstPoint, PointF secondPoint)
        {
            _point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            _point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            _information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // function to draw the rectangle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_point1, _point2);
        }

        // function to draw the selected rectangle
        public override void DrawSelected(IGraphics graphics)
        {
            graphics.DrawRectangle(_point1, _point2);
            graphics.DrawSelectedShape(_point1, _point2);
        }
    }
}