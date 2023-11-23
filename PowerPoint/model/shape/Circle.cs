using PowerPoint.presentation_model;
using System;
using System.Drawing;

namespace PowerPoint.model.shape
{
    public class Circle : Shape
    {
        const string CIRCLE = "Circle";
        const string CIRCLE_CHINESE = "圓";
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        public Circle(PointF point1, PointF point2)
        {
            this.Point1 = point1;
            Point2 = point2;
            UpdatePoint();
            Name = CIRCLE;
            ChineseName = CIRCLE_CHINESE;
            Information = string.Format(TEMPLATE, (int)this.Point1.X, (int)this.Point1.Y) + COMMA + string.Format(TEMPLATE, (int)Point2.X, (int)Point2.Y);
        }

        // make sure the point
        public override void UpdatePoint()
        {
            PointF temp1 = Point1;
            PointF temp2 = Point2;

            Point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            Point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));
        }

        // function to check if the circle contains the point
        public override bool Contains(PointF point)
        {
            return Point1.X <= point.X && point.X <= Point2.X && Point1.Y <= point.Y && point.Y <= Point2.Y;
        }

        // function to move the circle
        public override void Move(PointF firstPoint, PointF secondPoint)
        {
            Point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)Point1.X, (int)Point1.Y) + COMMA + string.Format(TEMPLATE, (int)Point2.X, (int)Point2.Y);
        }

        // function to zoom the circle
        public override void Zoom(PointF secondPoint)
        {
            Point2 = new PointF(secondPoint.X, secondPoint.Y);
            Information = string.Format(TEMPLATE, (int)Point1.X, (int)Point1.Y) + COMMA + string.Format(TEMPLATE, (int)Point2.X, (int)Point2.Y);
        }

        // function to draw the circle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(Point1, Point2);
        }

        // function to draw the selected circle
        public override void DrawSelected(IGraphics graphics)
        {
            graphics.DrawCircle(Point1, Point2);
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}