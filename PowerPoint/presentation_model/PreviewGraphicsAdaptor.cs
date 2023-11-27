using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace PowerPoint.presentation_model
{
    public class PreviewGraphicsAdaptor : IGraphics
    {
        const float SetStoryboardSpeedRatio = 0.25f;

        private float _ratio = SetStoryboardSpeedRatio;
        Graphics _graphics;

        public PreviewGraphicsAdaptor(Graphics graphics)
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
            point1 = new PointF(point1.X * _ratio, point1.Y * _ratio);
            point2 = new PointF(point2.X * _ratio, point2.Y * _ratio);

            _graphics.DrawLine(Pens.Black, (float)point1.X, (float)point1.Y, (float)point2.X, (float)point2.Y);
        }

        // draw a rectangle
        public void DrawRectangle(PointF point1, PointF point2)
        {
            point1 = new PointF(point1.X * _ratio, point1.Y * _ratio);
            point2 = new PointF(point2.X * _ratio, point2.Y * _ratio);

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
            point1 = new PointF(point1.X * _ratio, point1.Y * _ratio);
            point2 = new PointF(point2.X * _ratio, point2.Y * _ratio);

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
            point1 = new PointF(point1.X * _ratio, point1.Y * _ratio);
            point2 = new PointF(point2.X * _ratio, point2.Y * _ratio);

            PointF temp1 = point1;
            PointF temp2 = point2;
            point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));
            float width = Math.Abs(point2.X - point1.X);
            float height = Math.Abs(point2.Y - point1.Y);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)Math.Min(point1.X, point2.X), (int)Math.Min(point1.Y, point2.Y), (int)width, (int)height);
            _graphics.DrawRectangle(Pens.Red, rectangle);
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
