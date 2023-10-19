using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.model
{
    class Translator
    {
        // function to translate the English name into Chinese name
        public static string Translate(string shapeName)
        {
            switch (shapeName)
            {
                case DELETE:
                    return DELETE_CHINESE;
                case LINE:
                    return LINE_CHINESE;
                case RECTANGLE:
                    return RECTANGLE_CHINESE;
                case CIRCLE:
                    return CIRCLE_CHINESE;
            }
            return "";
        }

        const string DELETE = "Delete";
        const string DELETE_CHINESE = "刪除";

        const string LINE = "Line";
        const string LINE_CHINESE = "線";

        const string RECTANGLE = "Rectangle";
        const string RECTANGLE_CHINESE = "矩形";

        const string CIRCLE = "Circle";
        const string CIRCLE_CHINESE = "圓形";
    }
}
