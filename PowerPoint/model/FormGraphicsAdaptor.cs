using System;
using System.Drawing;
using System.Windows.Controls;

namespace PowerPoint.model
{
    public class FormGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        public FormGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // clear all the paint
        public void ClearAll()
        {
            throw new NotImplementedException();
        }

        // draw a line
        public void DrawLine(PointF point1, PointF point2)
        {
            _graphics.DrawLine(Pens.Black, (float)point1.X, (float)point1.Y, (float)point2.X, (float)point2.Y);
        }

        // draw a rectangle
        public void DrawRectangle(PointF point1, PointF point2)
        {
            float width = Math.Abs(point2.X - point1.X);
            float height = Math.Abs(point2.Y - point1.Y);

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)Math.Min(point1.X, point2.X), (int)Math.Min(point1.Y, point2.Y), (int)width, (int)height);
            _graphics.DrawRectangle(Pens.Black, rectangle);
        }

        // draw a circle
        public void DrawCircle(PointF point1, PointF point2)
        {
            const int TWO = 2;
            float centerX = (point1.X + point2.X) / TWO;
            float centerY = (point1.Y + point2.Y) / TWO;
            float radius = (float)Math.Sqrt(Math.Pow(point2.X - point1.X, TWO) + Math.Pow(point2.Y - point1.Y, TWO)) / TWO;
            RectangleF rectangle = new RectangleF(centerX - radius, centerY - radius, TWO * radius, TWO * radius);
            _graphics.DrawEllipse(Pens.Black, rectangle);
        }
    }
}
