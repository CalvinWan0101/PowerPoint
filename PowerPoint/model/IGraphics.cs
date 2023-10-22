﻿using System.Drawing;

namespace PowerPoint.model
{
    interface IGraphics
    {
        // clear all the paint
        void ClearAll();

        // draw a line
        void DrawLine(PointF point1, PointF point2);

        // draw a rectangle
        void DrawRectangle(PointF point1, PointF point2);

        // draw a circle
        void DrawCircle(PointF point1, PointF point2);
    }
}