using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Security.Cryptography;

namespace PowerPoint.model.shape.test {
    [TestClass]
    public class CircleTests {
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        Factory _factory;

        [TestInitialize]
        public void Initialize() {
            _factory = new Factory();
        }

        // make sure constructor work
        [TestMethod]
        public void make_sure_constructor_work() {
        }

        [TestMethod]
        public void create_circle_by_random_point() {
            Shape shapeRandom = _factory.CreateShape("Circle");
            PointF point1 = shapeRandom.Point1;
            PointF point2 = shapeRandom.Point2;

            Console.WriteLine(point1);
            Console.WriteLine(point2);

            Assert.AreEqual("Circle", shapeRandom.Name);
            Assert.AreEqual("圓", shapeRandom.ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shapeRandom.Information);
        }

        [TestMethod]
        public void create_circle() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Circle", point1, point2);

            Assert.AreEqual("Circle", shape.Name);
            Assert.AreEqual("圓", shape.ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);
        }

        [TestMethod]
        public void check_if_the_circle_constains_point() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Circle", point1, point2);

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
        public void move_circle() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Circle", point1, point2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);

            PointF firstPoint = new PointF(50, 50);
            PointF secondPoint = new PointF(150, 150);
            point1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            shape.Move(firstPoint, secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);
        }

        [TestMethod]
        public void zoom_circle_to_right_down() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Circle", point1, point2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);

            PointF firstPoint = new PointF(50, 50);
            PointF secondPoint = new PointF(150, 150);
            point2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            shape.Zoom(firstPoint, secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);
        }
    }
}