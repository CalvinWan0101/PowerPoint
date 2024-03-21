using System;
using System.Drawing;
using PowerPoint.presentation_model;

namespace PowerPoint.model.shape {
    public class Line : Shape {
        const string LINE = "Line";
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        private bool _lineReverse;
        private PointF _drawPoint1;
        private PointF _drawPoint2;

        public bool LineReverse {
            get { return _lineReverse; }
            set { _lineReverse = value; }
        }

        public PointF DrawPoint1 {
            get { return _drawPoint1; }
            set { _drawPoint1 = value; }
        }

        public PointF DrawPoint2 {
            get { return _drawPoint2; }
            set { _drawPoint2 = value; }
        }

        public Line(PointF point1, PointF point2) {
            _lineReverse = false;
            DrawPoint1 = point1;
            DrawPoint2 = point2;
            UpdatePoint();
            CheckReverse();
            Name = LINE;
            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA +
                          string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
        }

        // check the line is reverse or not;
        public void CheckReverse() {
            if (DrawPoint1 == Point2 || DrawPoint2 == Point2) {
                LineReverse = false;
            }
            else {
                LineReverse = true;
            }
        }

        // adjust point
        public override void AdjustPoint(float ratio) {
            base.AdjustPoint(ratio);
            DrawPoint1 = new PointF(DrawPoint1.X * ratio, DrawPoint1.Y * ratio);
            DrawPoint2 = new PointF(DrawPoint2.X * ratio, DrawPoint2.Y * ratio);
        }

        // make sure the point
        public override void UpdatePoint() {
            Point1 = new PointF(Math.Min(DrawPoint1.X, DrawPoint2.X), Math.Min(DrawPoint1.Y, DrawPoint2.Y));
            Point2 = new PointF(Math.Max(DrawPoint1.X, DrawPoint2.X), Math.Max(DrawPoint1.Y, DrawPoint2.Y));
        }

        // function to move the line
        public override void Move(PointF firstPoint, PointF secondPoint) {
            Point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            DrawPoint1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            DrawPoint2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA +
                          string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
        }

        // function to zoom the line
        public override void Zoom(PointF secondPoint) {
            Point2 = secondPoint;
            if (LineReverse) {
                ReverseZoom();
            }
            else {
                ReverseNotZoom();
            }

            Information = string.Format(TEMPLATE, (int)DrawPoint1.X, (int)DrawPoint1.Y) + COMMA +
                          string.Format(TEMPLATE, (int)DrawPoint2.X, (int)DrawPoint2.Y);
        }

        // zoom a reverse line
        private void ReverseZoom() {
            if (DrawPoint1.X > DrawPoint2.X) {
                DrawPoint1 = new PointF(Point2.X, Point1.Y);
                DrawPoint2 = new PointF(Point1.X, Point2.Y);
            }
            else {
                DrawPoint2 = new PointF(Point2.X, Point1.Y);
                DrawPoint1 = new PointF(Point1.X, Point2.Y);
            }
        }

        // zoom a not reverse line
        private void ReverseNotZoom() {
            if (DrawPoint1.X > DrawPoint2.X) {
                _drawPoint1 = _point2;
                _drawPoint2 = _point1;
            }
            else {
                _drawPoint2 = _point2;
                _drawPoint1 = _point1;
            }
        }

        // function to draw the line
        public override void Draw(IGraphics graphics) {
            graphics.DrawLine(DrawPoint1, DrawPoint2);
        }

        // function to draw the selected line
        public override void DrawSelected(IGraphics graphics) {
            graphics.DrawSelectedShape(Point1, Point2);
        }
    }
}