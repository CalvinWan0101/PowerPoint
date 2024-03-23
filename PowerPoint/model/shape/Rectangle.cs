using System;
using System.Drawing;
using PowerPoint.presentation_model;

namespace PowerPoint.model.shape {
    public class Rectangle : Shape {
        public static readonly string NAME = "Rectangle";

        public Rectangle(PointF point1, PointF point2) {
            Point1 = point1;
            Point2 = point2;
            UpdatePoint();
            Name = NAME;
        }

        public override void Move(PointF firstPoint, PointF secondPoint) {
            Point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
        }

        public override void Zoom(PointF secondPoint) {
            Point2 = secondPoint;
        }

        public override void Draw(IGraphics graphics) {
            graphics.DrawRectangle(Point1, Point2);
        }

        public override void DrawSelected(IGraphics graphics) {
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}