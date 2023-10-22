using PowerPoint.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public class Line : Shape
    {
        private PointF _point1;
        private PointF _point2;

        public Line(float x1, float y1, float x2, float y2)
        {
            _point1 = new PointF(x1, y1);
            _point2 = new PointF(x2, y2);
            const string LINE = "Line";
            const string LINE_CHINESE = "線";
            _name = LINE;
            _chineseName = LINE_CHINESE;
        }

        // get the name of line
        public override string GetShapeName()
        {
            return _name;
        }

        // get the chinese name of line
        public override string GetShapeChineseName()
        {
            return _chineseName;
        }

        // get the position of line
        public override string GetInformation()
        {
            //const string LEFT_BRACKET = "(";
            //const string RIGHT_BRACKET = ")";
            //return LEFT_BRACKET + _point1.X.ToString() + COMMA + _point1.Y.ToString() + RIGHT_BRACKET + COMMA + LEFT_BRACKET + _point2.X.ToString() + COMMA + _point2.Y.ToString() + RIGHT_BRACKET;
            const string COMMA = ", ";
            const string TEMPLATE = "({0:D3}, {1:D3})";
            return string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // function to draw the line
        public override void Draw(Panel panel)
        {
            const int PEN_SIZE = 2;
            Graphics graphics = panel.CreateGraphics();
            Pen pen = new Pen(Color.Black, PEN_SIZE);
            graphics.DrawLine(pen, _point1, _point2);
            pen.Dispose();
            graphics.Dispose();
        }
    }
}
