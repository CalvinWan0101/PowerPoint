using PowerPoint.presentation_model;
using System;
using System.Drawing;

namespace PowerPoint.model.shape {
    class Rectangle : Shape {
        private PointF _point1;
        private PointF _point2;
        const string RECTANGLE = "Rectangle";
        const string RECTANGLE_CHINESE = "矩形";
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        public Rectangle(PointF point1, PointF point2) {
            _point1 = point1;
            _point2 = point2;
            UpdatePoint();
            Name = RECTANGLE;
            ChineseName = RECTANGLE_CHINESE;
            Information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // get point 1
        public override PointF GetPoint1() {
            return _point1;
        }

        // get point 2
        public override PointF GetPoint2() {
            return _point2;
        }

        // get the name of rectangle
        public override string GetShapeName() {
            return Name;
        }

        // get the chinese name of rectangle
        public override string GetShapeChineseName() {
            return ChineseName;
        }

        // get the position of rectangle
        public override string GetInformation() {
            return Information;
        }

        // make sure the point
        public override void UpdatePoint() {
            PointF temp1 = _point1;
            PointF temp2 = _point2;

            _point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            _point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));
        }

        // function to check if the rectangle contains the point
        public override bool Contains(PointF point) {
            return _point1.X <= point.X && point.X <= _point2.X && _point1.Y <= point.Y && point.Y <= _point2.Y;
        }

        // function to move the rectangle
        public override void Move(PointF firstPoint, PointF secondPoint) {
            _point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            _point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // function to zoom the rectangle
        public override void Zoom(PointF firstPoint, PointF secondPoint) {
            _point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Information = string.Format(TEMPLATE, (int)_point1.X, (int)_point1.Y) + COMMA + string.Format(TEMPLATE, (int)_point2.X, (int)_point2.Y);
        }

        // function to draw the rectangle
        public override void Draw(IGraphics graphics) {
            graphics.DrawRectangle(_point1, _point2);
        }

        // function to draw the selected rectangle
        public override void DrawSelected(IGraphics graphics) {
            graphics.DrawRectangle(_point1, _point2);
            graphics.DrawSelectedShape(_point1, _point2);
        }
    }
}