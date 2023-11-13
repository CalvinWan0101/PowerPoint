using PowerPoint.presentation_model;
using System.Drawing;

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

        // function to check if the circle contains the point
        public override bool Contains(PointF point)
        {
            PointF temp1;
            PointF temp2;
            if (_point1.X > _point2.X)
            {
                temp1 = _point1;
                temp2 = _point2;
            }
            else
            {
                temp1 = _point2;
                temp2 = _point1;
            }

            return point.X <= temp1.X && point.X >= temp2.X && point.Y <= temp1.Y && point.Y >= temp2.Y;
        }

        // function to move the circle
        public override void Move(PointF pointA, PointF pointB)
        {
            _point1 += new SizeF(pointB.X - pointA.X, pointB.Y - pointA.Y);
            _point2 += new SizeF(pointB.X - pointA.X, pointB.Y - pointA.Y);
        }

        // function to draw the circle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_point1, _point2);
        }

        // function to draw the selected circle
        public override void DrawSelected(IGraphics graphics)
        {
            graphics.DrawCircle(_point1, _point2);
            graphics.DrawSelectedShape(_point1, _point2);
        }
    }
}