﻿using PowerPoint.model;
using PowerPoint.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
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
            _name = LINE;
            _chineseName = LINE_CHINESE;
            _information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
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
            return _information;
        }

        // function to draw the line
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_point1, _point2);
        }
    }
}