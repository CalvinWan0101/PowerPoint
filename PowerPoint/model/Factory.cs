using PowerPoint.Properties;
using PowerPoint.model.shape;
using System;

namespace PowerPoint
{
    public class Factory
    {
        const int ZERO = 0;
        const int ONE = 1;
        const int TWO = 2;
        const int THREE = 3;

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";

        private static Random _random = new Random();
        const int RANDOM_NUMBER_MAX = 511;
        // create the corresponding Shape, like Line or Rectangle (with concrete number)
        public static Shape CreateShape(string shapeName, params int[] position)
        {
            switch (shapeName)
            {
                case LINE:
                    return new Line(position[ZERO], position[ONE], position[TWO], position[THREE]);
                case RECTANGLE:
                    return new Rectangle(position[ZERO], position[ONE], position[TWO], position[THREE]);
                case CIRCLE:
                    return new Circle(position[ZERO], position[ONE], position[TWO], position[THREE]);
            }
            return null;
        }

        // create the corresponding Shape, like Line or Rectangle (with random number)
        public static Shape CreateShape(string shapeName)
        {
            switch (shapeName)
            {
                case LINE:
                    return new Line(_random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX));
                case RECTANGLE:
                    return new Rectangle(_random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX));
                case CIRCLE:
                    return new Circle(_random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX));
            }
            return null;
        }
    }
}
