using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using Rectangle = PowerPoint.model.shape.Rectangle;

namespace PowerPoint.model.test {
    [TestClass]
    public class FactoryTests {
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        [TestMethod]
        public void create_line_by_random_point() {
            Line shapeRandom = (Line)Factory.CreateShape("Line");

            PointF drawPoint1 = new PointF();
            PointF drawPoint2 = new PointF();
            drawPoint1 = shapeRandom.DrawPoint1;
            drawPoint2 = shapeRandom.DrawPoint2;

            Assert.AreEqual("Line", shapeRandom.Name);
            Assert.AreEqual(
                string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA +
                string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shapeRandom.Information);

            PointF point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
            PointF point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));

            Assert.AreEqual(point1, shapeRandom.Point1);
            Assert.AreEqual(point2, shapeRandom.Point2);
        }

        [TestMethod]
        public void create_rectangle_by_random_point() {
            Rectangle shapeRandom = (Rectangle)Factory.CreateShape("Rectangle");
            PointF point1 = shapeRandom.Point1;
            PointF point2 = shapeRandom.Point2;

            Assert.AreEqual("Rectangle", shapeRandom.Name);
            Assert.AreEqual(
                string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA +
                string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shapeRandom.Information);

            PointF point1_ = new PointF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            PointF point2_ = new PointF(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            Assert.AreEqual(point1_, shapeRandom.Point1);
            Assert.AreEqual(point2_, shapeRandom.Point2);
        }

        [TestMethod]
        public void create_circle_by_random_point() {
            Shape shapeRandom = Factory.CreateShape("Circle");
            PointF point1 = shapeRandom.Point1;
            PointF point2 = shapeRandom.Point2;

            Assert.AreEqual("Circle", shapeRandom.Name);
            Assert.AreEqual(
                string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA +
                string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shapeRandom.Information);
        }

        [TestMethod]
        public void create_shape_by_random_point_with_invalid_name() {
            Shape shapeRandom = Factory.CreateShape("Invalid");

            Assert.IsNull(shapeRandom);
        }

        [TestMethod]
        public void create_line() {
            PointF drawPoint1 = new PointF(0, 0);
            PointF drawPoint2 = new PointF(100, 100);
            Shape shape = Factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.AreEqual("Line", shape.Name);
            Assert.AreEqual(
                string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA +
                string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);

            PointF point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
            PointF point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
            Assert.AreEqual(point1, shape.Point1);
            Assert.AreEqual(point2, shape.Point2);
        }

        [TestMethod]
        public void create_rectangle() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = Factory.CreateShape("Rectangle", point1, point2);

            Assert.AreEqual("Rectangle", shape.Name);
            Assert.AreEqual(
                string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA +
                string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);

            PointF point1_ = new PointF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            PointF point2_ = new PointF(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            Assert.AreEqual(point1_, shape.Point1);
            Assert.AreEqual(point2_, shape.Point2);
        }

        [TestMethod]
        public void create_circle() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shape = Factory.CreateShape("Circle", point1, point2);

            Assert.AreEqual("Circle", shape.Name);
            Assert.AreEqual(
                string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA +
                string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), shape.Information);
        }

        [TestMethod]
        public void create_shape_with_invalid_name() {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(100, 100);
            Shape shapeRandom = Factory.CreateShape("Invalid", point1, point2);

            Assert.IsNull(shapeRandom);
        }
    }
}