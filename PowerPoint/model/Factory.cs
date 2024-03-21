using System;
using System.Drawing;
using PowerPoint.model.shape;
using Rectangle = PowerPoint.model.shape.Rectangle;

namespace PowerPoint.model {
    public class Factory {
        private Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        // create the corresponding Shape, like Line or Rectangle (with concrete number)
        public Shape CreateShape(string shapeName, params PointF[] position) {
            switch (shapeName) {
                case "Line":
                    return new Line(position[0], position[1]);
                case "Rectangle":
                    return new Rectangle(position[0], position[1]);
                case "Circle":
                    return new Circle(position[0], position[1]);
            }

            return null;
        }

        // create the corresponding Shape, like Line or Rectangle (with random number)
        public Shape CreateShape(string shapeName) {
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