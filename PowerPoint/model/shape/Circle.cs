﻿using System;
using System.Drawing;
using PowerPoint.presentation_model;

namespace PowerPoint.model.shape {
    public class Circle : Shape {
        public static readonly string NAME = "Circle";

        public Circle(PointF point1, PointF point2) {
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
            graphics.DrawCircle(Point1, Point2);
        }

        // function to draw the selected circle
        public override void DrawSelected(IGraphics graphics) {
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}