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
            const string COMMA = ", ";
            const string TEMPLATE = "({0:D3}, {1:D3})";
            return string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // function to draw the circle
        public override void Draw(Panel panel)
        {
            Graphics graphics = panel.CreateGraphics();
            Pen pen = new Pen(Color.Black, 3);
            float centerX = (_point1.X + _point2.X) / 2;
            float centerY = (_point1.Y + _point2.Y) / 2;
            float radius = (float)Math.Sqrt(Math.Pow(_point2.X - _point1.X, 2) + Math.Pow(_point2.Y - _point1.Y, 2)) / 2;
            RectangleF rectangle = new RectangleF(centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            graphics.DrawEllipse(pen, rectangle);
            pen.Dispose();
            graphics.Dispose();
        }
    }
}
