using System;
using System.Drawing;
using PowerPoint.presentation_model;

namespace PowerPoint.model.shape {
    public class Rectangle : Shape {
        const string RECTANGLE = "Rectangle";

        public Rectangle(PointF point1, PointF point2) {
            Point1 = point1;
            Point2 = point2;
            UpdatePoint();
            Name = RECTANGLE;
        }

        // make sure the point
        public override void UpdatePoint() {
            PointF temp1 = Point1;
            PointF temp2 = Point2;

            Point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            Point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));
        }

        // function to move the rectangle
        public override void Move(PointF firstPoint, PointF secondPoint) {
            Point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
        }

        // function to zoom the rectangle
        public override void Zoom(PointF secondPoint) {
            Point2 = secondPoint;
        }

        // function to draw the rectangle
        public override void Draw(IGraphics graphics) {
            graphics.DrawRectangle(Point1, Point2);
        }

        // function to draw the selected rectangle
        public override void DrawSelected(IGraphics graphics) {
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}