using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System;

namespace PowerPoint.model.shape.test {
    [TestClass]
    public class RectangleTests {
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        Factory _factory;

        [TestInitialize]
        public void Initialize() {
            _factory = new Factory();
        }

        [TestMethod]
        public void make_sure_constructor_work() {
        }

        [TestMethod]
        public void create_rectangle_by_random_point() {
            Shape shapeRandom = _factory.CreateShape("Rectangle");

            PointF point1 = new PointF();
            PointF point2 = new PointF();
            if (shapeRandom is Rectangle rectangle) {
                point1 = rectangle.Point1;
                point2 = rectangle.Point2;
            }

            Assert.AreEqual("Rectangle", shapeRandom.Name);
            Assert.AreEqual("矩形", shapeRandom.ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shapeRandom.Information);

            PointF point1_ = new PointF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            PointF point2_ = new PointF(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            Assert.AreEqual(point1_, shapeRandom.Point1);
            Assert.AreEqual(point2_, shapeRandom.Point2);
        }

        [TestMethod]
        public void create_rectangle() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Rectangle", point1, point2);

            Assert.AreEqual("Rectangle", shape.Name);
            Assert.AreEqual("矩形", shape.ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);

            PointF point1_ = new PointF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            PointF point2_ = new PointF(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            Assert.AreEqual(point1_, shape.Point1);
            Assert.AreEqual(point2_, shape.Point2);
        }

        [TestMethod]
        public void check_if_the_rectangle_contains_point() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Rectangle", point1, point2);

            Assert.IsTrue(shape.Contains(new PointF(50, 50)));
            Assert.IsTrue(shape.Contains(new PointF(0, 0)));
            Assert.IsTrue(shape.Contains(new PointF(100, 100)));

            Assert.IsFalse(shape.Contains(new PointF(50, -1)));
            Assert.IsFalse(shape.Contains(new PointF(50, 101)));
            Assert.IsFalse(shape.Contains(new PointF(-1, 50)));
            Assert.IsFalse(shape.Contains(new PointF(101, 50)));
            Assert.IsFalse(shape.Contains(new PointF(101, 101)));
            Assert.IsFalse(shape.Contains(new PointF(-1, -1)));
        }

        [TestMethod]
        public void move_rectangle() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Rectangle", point1, point2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);

            PointF firstPoint = new PointF(50, 50);
            PointF secondPoint = new PointF(150, 150);
            point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            shape.Move(firstPoint, secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);
        }

        [TestMethod]
        public void zoom_rectangle_to_right_down() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Rectangle", point1, point2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);

            PointF secondPoint = new PointF(150, 150);
            point2 = new PointF(secondPoint.X, secondPoint.Y);
            shape.Zoom(secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);
        }

        [TestMethod]
        public void zoom_rectangle_to_left_high() {
            PointF point1 = new PointF(50, 50);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Rectangle", point1, point2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);

            PointF secondPoint = new PointF(0, 0);
            point2 = new PointF(secondPoint.X, secondPoint.Y);
            shape.Zoom(secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);
        }
    }
}