using PowerPoint.presentation_model;
using System.Drawing;


namespace PowerPointTests.model.shape
{
    public class FakeGraphicsAdaptor : IGraphics
    {
        private int _isClearAll;
        private int _IsCircle;
        private int _IsLine;
        private int _IsRectangle;
        private int _IsSelectedShape;

        public int IsClearAll { get => _isClearAll; set => _isClearAll = value; }
        public int IsCircle { get => _IsCircle; set => _IsCircle = value; }
        public int IsLine { get => _IsLine; set => _IsLine = value; }
        public int IsRectangle { get => _IsRectangle; set => _IsRectangle = value; }
        public int IsSelectedShape { get => _IsSelectedShape; set => _IsSelectedShape = value; }

        public FakeGraphicsAdaptor()
        {
            IsClearAll = 0;
            IsCircle = 0;
            IsLine = 0;
            IsRectangle = 0;
            IsSelectedShape = 0;
        }

        public void ClearAll()
        {
            IsClearAll++;
        }

        public void DrawCircle(PointF point1, PointF point2)
        {
            IsCircle++;
        }

        public void DrawLine(PointF point1, PointF point2)
        {
            IsLine++;
        }

        public void DrawRectangle(PointF point1, PointF point2)
        {
            IsRectangle++;
        }

        public void DrawSelectedShape(PointF point1, PointF point2)
        {
            IsSelectedShape++;
        }
    }
}
