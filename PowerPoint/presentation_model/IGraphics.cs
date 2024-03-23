using System.Drawing;

namespace PowerPoint.presentation_model {
    public interface IGraphics {
        void ClearAll();

        void DrawLine(PointF point1, PointF point2);

        void DrawRectangle(PointF point1, PointF point2);

        void DrawCircle(PointF point1, PointF point2);

        void DrawSelectedShape(PointF point1, PointF point2);
    }
}