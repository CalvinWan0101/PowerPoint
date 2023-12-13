using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System;
using System.Reflection;
using PowerPointTests.model.shape;

namespace PowerPoint.model.shape.test
{
    [TestClass]
    public class RectangleTests
    {
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        Factory _factory;

        [TestInitialize]
        public void Initialize()
        {
            _factory = new Factory();
        }

        [TestMethod]
        public void make_sure_constructor_work()
        {
        }

        [TestMethod]
        public void create_rectangle()
        {
            Rectangle rectangle = new Rectangle(new PointF(0,0), new PointF(100,100));
            Assert.AreEqual("Rectangle", rectangle.Name);
            Assert.AreEqual("矩形", rectangle.ChineseName);
            Assert.AreEqual("(000, 000), (100, 100)", rectangle.Information);
            Assert.AreEqual(new PointF(0, 0), rectangle.Point1);
            Assert.AreEqual(new PointF(100, 100), rectangle.Point2);
        }

        [TestMethod]
        public void adjust_rectangle()
        {
            Rectangle rectangle = new Rectangle(new PointF(0, 0), new PointF(100, 100));
            Assert.AreEqual(new PointF(0, 0), rectangle.Point1);
            Assert.AreEqual(new PointF(100, 100), rectangle.Point2);

            rectangle.AdjustPoint(2);

            Assert.AreEqual(new PointF(0, 0), rectangle.Point1);
            Assert.AreEqual(new PointF(200, 200), rectangle.Point2);
        }

        [TestMethod]
        public void check_if_the_rectangle_contains_point()
        {
            Rectangle rectangle = new Rectangle(new PointF(0, 0), new PointF(100, 100));

            Assert.IsTrue(rectangle.Contains(new PointF(50, 50)));
            Assert.IsTrue(rectangle.Contains(new PointF(0, 0)));
            Assert.IsTrue(rectangle.Contains(new PointF(100, 100)));
            Assert.IsFalse(rectangle.Contains(new PointF(50, -1)));
            Assert.IsFalse(rectangle.Contains(new PointF(50, 101)));
            Assert.IsFalse(rectangle.Contains(new PointF(-1, 50)));
            Assert.IsFalse(rectangle.Contains(new PointF(101, 50)));
            Assert.IsFalse(rectangle.Contains(new PointF(101, 101)));
            Assert.IsFalse(rectangle.Contains(new PointF(-1, -1)));
        }

        [TestMethod]
        public void move_rectangle()
        {
            Rectangle rectangle = new Rectangle(new PointF(0, 0), new PointF(100, 100));
            Assert.AreEqual(new PointF(0, 0), rectangle.Point1);
            Assert.AreEqual(new PointF(100, 100), rectangle.Point2);

            rectangle.Move(new PointF(50, 50), new PointF(150, 150));

            Assert.AreEqual(new PointF(100, 100), rectangle.Point1);
            Assert.AreEqual(new PointF(200, 200), rectangle.Point2);
        }

        [TestMethod]
        public void zoom_rectangle_to_right_down()
        {
            Rectangle rectangle = new Rectangle(new PointF(0, 0), new PointF(100, 100));
            Assert.AreEqual(new PointF(0, 0), rectangle.Point1);
            Assert.AreEqual(new PointF(100, 100), rectangle.Point2);

            rectangle.Zoom(new PointF(150, 150));

            Assert.AreEqual(new PointF(0, 0), rectangle.Point1);
            Assert.AreEqual(new PointF(150, 150), rectangle.Point2);
        }

        [TestMethod]
        public void zoom_rectangle_to_left_high()
        {
            Rectangle rectangle = new Rectangle(new PointF(50, 50), new PointF(100, 100));
            Assert.AreEqual(new PointF(50, 50), rectangle.Point1);
            Assert.AreEqual(new PointF(100, 100), rectangle.Point2);

            rectangle.Zoom(new PointF(0, 0));

            Assert.AreEqual(new PointF(50, 50), rectangle.Point1);
            Assert.AreEqual(new PointF(0, 0), rectangle.Point2);
        }

        [TestMethod]
        public void draw_rectangle()
        {
            Rectangle rectangle = new Rectangle(new PointF(0, 0), new PointF(100, 100));
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            rectangle.Draw(graphic);

            Assert.AreEqual(0, graphic.IsLine);
            Assert.AreEqual(0, graphic.IsCircle);
            Assert.AreEqual(1, graphic.IsRectangle);
            Assert.AreEqual(0, graphic.IsClearAll);
            Assert.AreEqual(0, graphic.IsSelectedShape);
        }

        [TestMethod]
        public void draw_selected_rectangle()
        {
            Rectangle rectangle = new Rectangle(new PointF(0, 0), new PointF(100, 100));
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            rectangle.DrawSelected(graphic);

            Assert.AreEqual(0, graphic.IsLine);
            Assert.AreEqual(0, graphic.IsCircle);
            Assert.AreEqual(1, graphic.IsRectangle);
            Assert.AreEqual(0, graphic.IsClearAll);
            Assert.AreEqual(1, graphic.IsSelectedShape);
        }
    }
}