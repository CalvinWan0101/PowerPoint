using PowerPoint.presentation_model;
using System.Drawing;


namespace PowerPointTests.model.shape
{
    public class FakeGraphicsAdaptor : IGraphics
    {
        private bool _isClearAll;
        private bool _IsCircle;
        private bool _IsLine;
        private bool _IsRectangle;
        private bool _IsSelectedShape;

        public bool IsClearAll { get => _isClearAll; set => _isClearAll = value; }
        public bool IsCircle { get => _IsCircle; set => _IsCircle = value; }
        public bool IsLine { get => _IsLine; set => _IsLine = value; }
        public bool IsRectangle { get => _IsRectangle; set => _IsRectangle = value; }
        public bool IsSelectedShape { get => _IsSelectedShape; set => _IsSelectedShape = value; }

        public FakeGraphicsAdaptor()
        {
            IsCircle = false;
            IsLine = false;
            IsRectangle = false;
            IsSelectedShape = false;
        }

        public void ClearAll()
        {
            IsClearAll = true;
        }

        public void DrawCircle(PointF point1, PointF point2)
        {
            IsCircle = true;
        }

        public void DrawLine(PointF point1, PointF point2)
        {
            IsLine = true;
        }

        public void DrawRectangle(PointF point1, PointF point2)
        {
            IsRectangle = true;
        }

        public void DrawSelectedShape(PointF point1, PointF point2)
        {
            IsSelectedShape = true;
        }
    }
}
