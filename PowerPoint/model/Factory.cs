using PowerPoint.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

        // create the corresponding Shape, like Line or Rectangle
        public static Shape CreateShape(string shapeName, params int[] position)
        {
            switch (shapeName)
            {
                case LINE:
                    return new Line(position[ZERO], position[ONE], position[TWO], position[THREE]);
                case RECTANGLE:
                    return new Rectangle(position[ZERO], position[ONE], position[TWO], position[THREE]);
                case CIRCLE:
                    return new Rectangle(position[ZERO], position[ONE], position[TWO], position[THREE]);
            }
            return null;
        }
    }
}
