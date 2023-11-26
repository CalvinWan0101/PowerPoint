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

        private PointF _drawPoint1;
        private PointF _drawPoint2;


        private PointF _drawPoint1Record;
        private PointF _drawPoint2Record;

        public PointF DrawPoint1
        {
            get => _drawPoint1;
            set => _drawPoint1 = value;
        }

        public PointF DrawPoint2
        {
            get => _drawPoint2;
            set => _drawPoint2 = value;
        }

        public Line(PointF point1, PointF point2)
        {
            DrawPoint1 = point1;
            DrawPoint2 = point2;
            UpdatePoint();
            Name = LINE;
            ChineseName = LINE_CHINESE;
            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
        }

        // make sure the point
        public override void UpdatePoint()
        {
            Point1 = new PointF(Math.Min(DrawPoint1.X, DrawPoint2.X), Math.Min(DrawPoint1.Y, DrawPoint2.Y));
            Point2 = new PointF(Math.Max(DrawPoint1.X, DrawPoint2.X), Math.Max(DrawPoint1.Y, DrawPoint2.Y));
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
            DrawPoint1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            DrawPoint2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
        }

        // function to zoom the line
        public override void Zoom(PointF secondPoint)
        {

            // left bottom
            if (DrawPoint1.X == Point1.X && DrawPoint1.Y == Point2.Y)
            {
                DrawPoint1 = new PointF(Point1.X, secondPoint.Y);
            }
            // right top
            else if (DrawPoint1.X == Point2.X && DrawPoint1.Y == Point1.Y)
            {
                DrawPoint1 = new PointF(secondPoint.X, Point1.Y);
            }
            // right bottom
            else if (DrawPoint1.X == Point2.X && DrawPoint1.Y == Point2.Y)
            {
                DrawPoint1 = new PointF(secondPoint.X, secondPoint.Y);
            }

            // left bottom
            if (DrawPoint2.X == Point1.X && DrawPoint2.Y == Point2.Y)
            {
                DrawPoint2 = new PointF(Point1.X, secondPoint.Y);
            }
            // right top
            else if (DrawPoint2.X == Point2.X && DrawPoint2.Y == Point1.Y)
            {
                DrawPoint2 = new PointF(secondPoint.X, Point1.Y);
            }
            // right bottom
            else if (DrawPoint2.X == Point2.X && DrawPoint2.Y == Point2.Y)
            {
                DrawPoint2 = new PointF(secondPoint.X, secondPoint.Y);
            }

            Point2 = secondPoint;
            //UpdatePoint();

            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
        }

        // function to draw the line
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(DrawPoint1, DrawPoint2);
        }

        // function to draw the selected line
        public override void DrawSelected(IGraphics graphics)
        {
            graphics.DrawLine(DrawPoint1, DrawPoint2);
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}
