using System;
using System.Drawing;
using PowerPoint.model.shape;
using Rectangle = PowerPoint.model.shape.Rectangle;

namespace PowerPoint.model {
    public class Factory {
        const int ZERO = 0;
        const int ONE = 1;
        const int TWO = 2;

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";

        private Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        public Factory() {
        }

        // create the corresponding Shape, like Line or Rectangle (with concrete number)
        public Shape CreateShape(string shapeName, params PointF[] position) {
            switch (shapeName) {
                case LINE:
                    return new Line(position[ZERO], position[ONE]);
                case RECTANGLE:
                    return new Rectangle(position[ZERO], position[ONE]);
                case CIRCLE:
                    return new Circle(position[ZERO], position[ONE]);
            }

            return null;
        }

        // create the corresponding Shape, like Line or Rectangle (with random number)
        public Shape CreateShape(string shapeName) {
            PointF point1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF point2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));

            switch (shapeName) {
                case LINE:
                    return new Line(point1, point2);
                case RECTANGLE:
                    return new Rectangle(point1, point2);
                case CIRCLE:
                    return new Circle(point1, point2);
            }

            return null;
        }
    }
}