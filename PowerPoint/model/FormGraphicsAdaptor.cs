using System;
using System.Drawing;

namespace PowerPoint.model
{
    class FormGraphicsAdaptor : IGraphics
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
            throw new NotImplementedException();
        }

        // draw a circle
        public void DrawCircle(PointF point1, PointF point2)
        {
            throw new NotImplementedException();
        }
    }
}
