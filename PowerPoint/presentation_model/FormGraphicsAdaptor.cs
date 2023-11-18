using System;
using System.Drawing;

namespace PowerPoint.presentation_model
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
        }

        // draw a line
        public void DrawLine(PointF point1, PointF point2)
        {
            PointF temp1 = point1;
            PointF temp2 = point2;

            point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _graphics.DrawLine(Pens.Black, (float)point1.X, (float)point1.Y, (float)point2.X, (float)point2.Y);
        }

        // draw a rectangle
        public void DrawRectangle(PointF point1, PointF point2)
        {
            PointF temp1 = point1;
            PointF temp2 = point2;

            point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            float width = Math.Abs(point2.X - point1.X);
            float height = Math.Abs(point2.Y - point1.Y);

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)point1.X, (int)point1.Y, (int)width, (int)height);
            _graphics.DrawRectangle(Pens.Black, rectangle);
        }

        // draw a circle
        public void DrawCircle(PointF point1, PointF point2)
        {
            PointF temp1 = point1;
            PointF temp2 = point2;

            point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            float width = Math.Abs(point1.X - point2.X);
            float height = Math.Abs(point1.Y - point2.Y);

            _graphics.DrawEllipse(Pens.Black, Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y), width, height);
        }

        const int FIVE = 5;
        const int TWO = 2;
        const int TEN = 10;

        // draw the selected shape
        public void DrawSelectedShape(PointF point1, PointF point2)
        {
            PointF temp1 = point1;
            PointF temp2 = point2;

            point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            // draw a rectangle
            float width = Math.Abs(point2.X - point1.X);
            float height = Math.Abs(point2.Y - point1.Y);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)Math.Min(point1.X, point2.X), (int)Math.Min(point1.Y, point2.Y), (int)width, (int)height);
            _graphics.DrawRectangle(Pens.Red, rectangle);

            // draw eight circles on the rectangle
            _graphics.DrawEllipse(Pens.Gray, rectangle.X - FIVE, rectangle.Y - FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Gray, rectangle.X + rectangle.Width / TWO - FIVE, rectangle.Y - FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Gray, rectangle.X + rectangle.Width - FIVE, rectangle.Y - FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Gray, rectangle.X - FIVE, rectangle.Y + rectangle.Height / TWO - FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Gray, rectangle.X + rectangle.Width - FIVE, rectangle.Y + rectangle.Height / TWO - FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Gray, rectangle.X - FIVE, rectangle.Y + rectangle.Height - FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Gray, rectangle.X + rectangle.Width / TWO - FIVE, rectangle.Y + rectangle.Height - FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Gray, rectangle.X + rectangle.Width - FIVE, rectangle.Y + rectangle.Height - FIVE, TEN, TEN);
        }
    }
}
