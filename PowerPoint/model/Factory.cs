using System;
using System.Drawing;
using PowerPoint.model.shape;
using Rectangle = PowerPoint.model.shape.Rectangle;

namespace PowerPoint.model {
    public class Factory {
        private static Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        public static Shape CreateShape(string shapeName, PointF pointA, PointF pointB) {
            switch (shapeName) {
                case "Line":
                    return new Line(pointA, pointB);
                case "Rectangle":
                    return new Rectangle(pointA, pointB);
                case "Circle":
                    return new Circle(pointA, pointB);
            }

            return null;
        }

        public static Shape CreateShape(string shapeName) {
            PointF point1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF point2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            switch (shapeName) {
                case "Line":
                    return new Line(point1, point2);
                case "Rectangle":
                    return new Rectangle(point1, point2);
                case "Circle":
                    return new Circle(point1, point2);
            }

            return null;
        }
    }
}