﻿using System;
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
            _graphics.DrawLine(Pens.Purple, (float)point1.X, (float)point1.Y, (float)point2.X, (float)point2.Y);
        }

        // draw a rectangle
        public void DrawRectangle(PointF point1, PointF point2)
        {
            float width = Math.Abs(point2.X - point1.X);
            float height = Math.Abs(point2.Y - point1.Y);

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)Math.Min(point1.X, point2.X), (int)Math.Min(point1.Y, point2.Y), (int)width, (int)height);
            _graphics.DrawRectangle(Pens.Purple, rectangle);
        }

        // draw a circle
        public void DrawCircle(PointF point1, PointF point2)
        {
            float width = Math.Abs(point1.X - point2.X);
            float height = Math.Abs(point1.Y - point2.Y);
            _graphics.DrawEllipse(Pens.Purple, Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y), width, height);
        }
    }
}