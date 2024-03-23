using System;
using System.Drawing;
using PowerPoint.presentation_model;

namespace PowerPoint.model.shape {
    public class Circle : Shape {
        const string CIRCLE = "Circle";

        public Circle(PointF point1, PointF point2) {
            Point1 = point1;
            Point2 = point2;
            UpdatePoint();
            Name = CIRCLE;
        }

        // make sure the point
        public override void UpdatePoint() {
            PointF temp1 = Point1;
            PointF temp2 = Point2;

            Point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            Point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));
        }

        // function to move the circle
        public override void Move(PointF firstPoint, PointF secondPoint) {
            Point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
        }

        // function to zoom the circle
        public override void Zoom(PointF secondPoint) {
            Point2 = secondPoint;
        }

        // function to draw the circle
        public override void Draw(IGraphics graphics) {
            graphics.DrawCircle(Point1, Point2);
        }

        // function to draw the selected circle
        public override void DrawSelected(IGraphics graphics) {
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}