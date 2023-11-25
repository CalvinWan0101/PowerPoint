using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests.model.shape;
using System.Drawing;

namespace PowerPoint.model.shape.test
{
    [TestClass]
    public class CircleTests
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
        public void create_circle()
        {
            Circle circle = new Circle(new PointF(0, 0), new PointF(100, 100));

            Assert.AreEqual("Circle", circle.Name);
            Assert.AreEqual("圓", circle.ChineseName);
            Assert.AreEqual("(000, 000), (100, 100)", circle.Information);
            Assert.AreEqual(new PointF(0, 0), circle.Point1);
            Assert.AreEqual(new PointF(100, 100), circle.Point2);
        }

        [TestMethod]
        public void check_if_the_circle_contains_point()
        {
            Circle circle = new Circle(new PointF(0, 0), new PointF(100, 100));

            Assert.IsTrue(circle.Contains(new PointF(50, 50)));
            Assert.IsTrue(circle.Contains(new PointF(0, 0)));
            Assert.IsTrue(circle.Contains(new PointF(100, 100)));
            Assert.IsFalse(circle.Contains(new PointF(50, -1)));
            Assert.IsFalse(circle.Contains(new PointF(50, 101)));
            Assert.IsFalse(circle.Contains(new PointF(-1, 50)));
            Assert.IsFalse(circle.Contains(new PointF(101, 50)));
            Assert.IsFalse(circle.Contains(new PointF(101, 101)));
            Assert.IsFalse(circle.Contains(new PointF(-1, -1)));
        }

        [TestMethod]
        public void move_circle()
        {
            Circle circle = new Circle(new PointF(0, 0), new PointF(100, 100));
            Assert.AreEqual(new PointF(0, 0), circle.Point1);
            Assert.AreEqual(new PointF(100, 100), circle.Point2);

            circle.Move(new PointF(50, 50), new PointF(150, 150));

            Assert.AreEqual(new PointF(100, 100), circle.Point1);
            Assert.AreEqual(new PointF(200, 200), circle.Point2);
        }

        [TestMethod]
        public void zoom_circle_to_right_down()
        {
            Circle circle = new Circle(new PointF(0, 0), new PointF(100, 100));
            Assert.AreEqual(new PointF(0, 0), circle.Point1);
            Assert.AreEqual(new PointF(100, 100), circle.Point2);

            circle.Zoom(new PointF(150, 150));

            Assert.AreEqual(new PointF(0, 0), circle.Point1);
            Assert.AreEqual(new PointF(150, 150), circle.Point2);
        }

        [TestMethod]
        public void zoom_circle_to_left_high()
        {
            Circle circle = new Circle(new PointF(50, 50), new PointF(100, 100));
            Assert.AreEqual(new PointF(50, 50), circle.Point1);
            Assert.AreEqual(new PointF(100, 100), circle.Point2);

            circle.Zoom(new PointF(0, 0));

            Assert.AreEqual(new PointF(0, 0), circle.Point1);
            Assert.AreEqual(new PointF(50, 50), circle.Point2);
        }

        [TestMethod]
        public void draw_circle()
        {
            Circle circle = new Circle(new PointF(0, 0), new PointF(100, 100));
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            circle.Draw(graphic);

            Assert.IsTrue(graphic.IsCircle);
        }

        [TestMethod]
        public void draw_selected_circle()
        {
            Circle circle = new Circle(new PointF(0, 0), new PointF(100, 100));
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            circle.DrawSelected(graphic);

            Assert.IsTrue(graphic.IsCircle);
        }
    }
}