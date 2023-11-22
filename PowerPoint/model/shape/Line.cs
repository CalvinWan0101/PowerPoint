using PowerPoint.presentation_model;
using System;
using System.Drawing;

namespace PowerPoint.model.shape
{
    public class Line : Shape
    {
        const string LINE = "Line";
        const string LINE_CHINESE = "線";
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        public Line(PointF point1, PointF point2)
        {
            Point1 = point1;
            Point2 = point2;
            UpdatePoint();
            Name = LINE;
            ChineseName = LINE_CHINESE;
            Information = string.Format(TEMPLATE, (int)Point1.X, (int)Point1.Y) + COMMA + string.Format(TEMPLATE, (int)Point2.X, (int)Point2.Y);
        }

        // make sure the point
        public override void UpdatePoint()
        {
            PointF temp1 = Point1;
            PointF temp2 = Point2;

            Point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            Point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));
        }

        // function to check if the line contains the point
        public override bool Contains(PointF point)
        {
            return Point1.X <= point.X && point.X <= Point2.X && Point1.Y <= point.Y && point.Y <= Point2.Y;
        }

        // function to move the line
        public override void Move(PointF firstPoint, PointF secondPoint)
        {
            Point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)Point1.X, (int)Point1.Y) + COMMA + string.Format(TEMPLATE, (int)Point2.X, (int)Point2.Y);
        }

        // function to zoom the line
        public override void Zoom(PointF firstPoint, PointF secondPoint)
        {
            Point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)Point1.X, (int)Point1.Y) + COMMA + string.Format(TEMPLATE, (int)Point2.X, (int)Point2.Y);
        }

        // function to draw the line
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(Point1, Point2);
        }

        // function to draw the selected line
        public override void DrawSelected(IGraphics graphics)
        {
            graphics.DrawLine(Point1, Point2);
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}
