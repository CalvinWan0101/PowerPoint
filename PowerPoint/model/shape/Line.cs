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


        private PointF _drawPoint1Record = new PointF(-1, -1);
        private PointF _drawPoint2Record = new PointF(-1, -1);

        public PointF DrawPoint1Record { get => _drawPoint1Record; set => _drawPoint1Record = value; }
        public PointF DrawPoint2Record { get => _drawPoint2Record; set => _drawPoint2Record = value; }

        public PointF DrawPoint1
        {
            get
            {
                return _drawPoint1;
            }
            set
            {
                if (value.X == _drawPoint2.X ^ value.Y == _drawPoint2.Y)
                {
                    _drawPoint1Record = _drawPoint1;
                    Console.WriteLine("DrawPoint1Record");
                }
                _drawPoint1 = value;
            }
        }

        public PointF DrawPoint2
        {
            get
            {
                return _drawPoint2;
            }
            set
            {
                if (_drawPoint1.X == value.X ^ _drawPoint1.Y == value.Y)
                {
                    _drawPoint2Record = _drawPoint2;
                    Console.WriteLine("DrawPoint2Record");
                }
                _drawPoint2 = value;
            }
        }

        public Line(PointF point1, PointF point2)
        {
            DrawPoint1 = point1;
            DrawPoint2 = point2;
            Point1 = point1;
            Point2 = point2;
            UpdatePoint();
            Name = LINE;
            ChineseName = LINE_CHINESE;
            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
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
            DrawPoint1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            DrawPoint2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
        }

        private void ZoomParel(PointF secondPoint)
        {

            if (Math.Abs(_drawPoint1Record.X - secondPoint.X) < Math.Abs(_drawPoint2Record.X - secondPoint.X))
            {
                DrawPoint1 = secondPoint;
            }
            else
            {
                DrawPoint2 = secondPoint;
            }
        }

        private void ZoomVertical(PointF secondPoint)
        {
            if (Math.Abs(_drawPoint1Record.Y - secondPoint.Y) < Math.Abs(_drawPoint2Record.Y - secondPoint.Y))
            {
                DrawPoint1 = secondPoint;
            }
            else
            {
                DrawPoint2 = secondPoint;
            }
        }

        private void ZoomOtherwise(PointF secondPoint)
        {
            if (DrawPoint1.X == Point1.X && DrawPoint1.Y == Point2.Y)
            {
                DrawPoint1 = new PointF(Point1.X, secondPoint.Y);
            }
            else if (DrawPoint1.X == Point2.X && DrawPoint1.Y == Point1.Y)
            {
                DrawPoint1 = new PointF(secondPoint.X, Point1.Y);
            }
            else if (DrawPoint1 == Point2)
            {
                DrawPoint1 = secondPoint;
            }

            if (DrawPoint2.X == Point1.X && DrawPoint2.Y == Point2.Y)
            {
                DrawPoint2 = new PointF(Point1.X, secondPoint.Y);
            }
            else if (DrawPoint2.X == Point2.X && DrawPoint2.Y == Point1.Y)
            {
                DrawPoint2 = new PointF(secondPoint.X, Point1.Y);
            }
            else if (DrawPoint2 == Point2)
            {
                DrawPoint2 = secondPoint;

            }
        }

        // function to zoom the line
        public override void Zoom(PointF secondPoint)
        {
            if (DrawPoint1 == DrawPoint2) { }
            else if (DrawPoint1.Y == DrawPoint2.Y)
            {
                ZoomParel(secondPoint);
            }
            else if (DrawPoint1.X == DrawPoint2.X)
            {
                ZoomVertical(secondPoint);
            }
            else
            {
                ZoomOtherwise(secondPoint);
            }

            Point2 = secondPoint;
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
            graphics.DrawSelectedShape(DrawPoint1, DrawPoint2);
        }
    }
}
