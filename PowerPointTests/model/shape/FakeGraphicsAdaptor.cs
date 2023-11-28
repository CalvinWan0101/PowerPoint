using PowerPoint.presentation_model;
using System.Drawing;

namespace PowerPointTests.model.shape
{
    public class FakeGraphicsAdaptor : IGraphics
    {
        private int _isClearAll;
        private int _isCircle;
        private int _isLine;
        private int _isRectangle;
        private int _isSelectedShape;

        public int IsClearAll
        {
            get
            {
                return _isClearAll;
            }
            set
            {
                _isClearAll = value;
            }
        }
        public int IsCircle
        {
            get
            {
                return _isCircle;
            }
            set
            {
                _isCircle = value;
            }
        }

        public int IsLine
        {
            get
            {
                return _isLine;
            }
            set
            {
                _isLine = value;
            }
        }

        public int IsRectangle
        {
            get
            {
                return _isRectangle;
            }
            set
            {
                _isRectangle = value;
            }
        }

        public int IsSelectedShape
        {
            get
            {
                return _isSelectedShape;
            }
            set
            {
                _isSelectedShape = value;
            }
        }

        public FakeGraphicsAdaptor()
        {
            IsClearAll = 0;
            IsCircle = 0;
            IsLine = 0;
            IsRectangle = 0;
            IsSelectedShape = 0;
        }

        // clear all
        public void ClearAll()
        {
            IsClearAll++;
        }

        // draw circle
        public void DrawCircle(PointF point1, PointF point2)
        {
            IsCircle++;
        }

        // draw line
        public void DrawLine(PointF point1, PointF point2)
        {
            IsLine++;
        }

        // draw rectangle
        public void DrawRectangle(PointF point1, PointF point2)
        {
            IsRectangle++;
        }

        // draw selected shape
        public void DrawSelectedShape(PointF point1, PointF point2)
        {
            IsSelectedShape++;
        }
    }
}
