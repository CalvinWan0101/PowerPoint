using PowerPoint.presentation_model;
using System.Drawing;

namespace PowerPoint.model.shape
{
    public class Line : Shape
    {
        private PointF _point1;
        private PointF _point2;
        const string LINE = "Line";
        const string LINE_CHINESE = "線";
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        public Line(PointF point1, PointF point2)
        {
            _point1 = point1;
            _point2 = point2;
            Name = LINE;
            ChineseName = LINE_CHINESE;
            Information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // get the name of line
        public override string GetShapeName()
        {
            return Name;
        }

        // get the chinese name of line
        public override string GetShapeChineseName()
        {
            return ChineseName;
        }

        // get the position of line
        public override string GetInformation()
        {
            return Information;
        }

        // function to check if the line contains the point
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

        // function to move the line
        public override void Move(PointF firstPoint, PointF secondPoint)
        {
            _point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            _point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // function to draw the line
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_point1, _point2);
        }

        // function to draw the selected line
        public override void DrawSelected(IGraphics graphics)
        {
            graphics.DrawLine(_point1, _point2);
            graphics.DrawSelectedShape(_point1, _point2);
        }
    }
}
