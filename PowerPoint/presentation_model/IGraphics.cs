using System.Drawing;

namespace PowerPoint.presentation_model {
    public interface IGraphics {
        // clear all the paint
        void ClearAll();

        // draw a line
        void DrawLine(PointF point1, PointF point2);

        // draw a rectangle
        void DrawRectangle(PointF point1, PointF point2);

        // draw a circle
        void DrawCircle(PointF point1, PointF point2);

        // draw selected shape
        void DrawSelectedShape(PointF point1, PointF point2);
    }
}