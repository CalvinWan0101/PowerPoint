using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests.model.shape;
using System;
using System.Drawing;

namespace PowerPoint.model.shape.test
{
    [TestClass]
    public class LineTests
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
        public void create_line()
        {
            Line line = new Line(new PointF(1, 1), new PointF(2, 2));

            Assert.AreEqual("Line", line.Name);
            Assert.AreEqual("線", line.ChineseName);
            Assert.AreEqual("(001, 001), (002, 002)", line.Information);

            Assert.AreEqual(new PointF(1, 1), line.DrawPoint1);
            Assert.AreEqual(new PointF(2, 2), line.DrawPoint2);
            Assert.AreEqual(new PointF(1, 1), line.Point1);
            Assert.AreEqual(new PointF(2, 2), line.Point2);

            line.DrawPoint1 = new PointF(3, 3);
            line.DrawPoint2 = new PointF(4, 4);
            line.UpdatePoint();
            Assert.AreEqual(new PointF(3, 3), line.DrawPoint1);
            Assert.AreEqual(new PointF(4, 4), line.DrawPoint2);
            Assert.AreEqual(new PointF(3, 3), line.Point1);
            Assert.AreEqual(new PointF(4, 4), line.Point2);
        }

        [TestMethod]
        public void create_line_reverse()
        {
            Line line = new Line(new PointF(0, 100), new PointF(100, 0));

            Assert.AreEqual("Line", line.Name);
            Assert.AreEqual("線", line.ChineseName);
            Assert.AreEqual("(000, 100), (100, 000)", line.Information);
            Assert.AreEqual(new PointF(0, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 0), line.DrawPoint2);
            Assert.AreEqual(new PointF(0, 0), line.Point1);
            Assert.AreEqual(new PointF(100, 100), line.Point2);
        }

        [TestMethod]
        public void check_if_the_line_contains_point()
        {
            Line line = new Line(new PointF(0, 0), new PointF(100, 100));

            Assert.IsTrue(line.Contains(new PointF(50, 50)));
            Assert.IsTrue(line.Contains(new PointF(0, 0)));
            Assert.IsTrue(line.Contains(new PointF(0, 100)));
            Assert.IsTrue(line.Contains(new PointF(100, 0)));
            Assert.IsTrue(line.Contains(new PointF(100, 100)));
            Assert.IsFalse(line.Contains(new PointF(50, -1)));
            Assert.IsFalse(line.Contains(new PointF(50, 101)));
            Assert.IsFalse(line.Contains(new PointF(-1, 50)));
            Assert.IsFalse(line.Contains(new PointF(101, 50)));
            Assert.IsFalse(line.Contains(new PointF(101, 101)));
            Assert.IsFalse(line.Contains(new PointF(-1, -1)));
        }

        [TestMethod]
        public void check_if_the_line_contains_point_reverse()
        {
            Line line = new Line(new PointF(0, 100), new PointF(100, 0));

            Assert.IsTrue(line.Contains(new PointF(50, 50)));
            Assert.IsTrue(line.Contains(new PointF(0, 0)));
            Assert.IsTrue(line.Contains(new PointF(0, 100)));
            Assert.IsTrue(line.Contains(new PointF(100, 0)));
            Assert.IsTrue(line.Contains(new PointF(100, 100)));
            Assert.IsFalse(line.Contains(new PointF(50, -1)));
            Assert.IsFalse(line.Contains(new PointF(50, 101)));
            Assert.IsFalse(line.Contains(new PointF(-1, 50)));
            Assert.IsFalse(line.Contains(new PointF(101, 50)));
            Assert.IsFalse(line.Contains(new PointF(101, 101)));
            Assert.IsFalse(line.Contains(new PointF(-1, -1)));
        }

        [TestMethod]
        public void move_line()
        {
            Line line = new Line(new PointF(0, 100), new PointF(100, 0));

            Assert.AreEqual(new PointF(0, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 0), line.DrawPoint2);
            Assert.AreEqual(new PointF(0, 0), line.Point1);
            Assert.AreEqual(new PointF(100, 100), line.Point2);

            line.Move(new PointF(0, 100), new PointF(0, 200));

            Assert.AreEqual(new PointF(0, 200), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(0, 100), line.Point1);
            Assert.AreEqual(new PointF(100, 200), line.Point2);
        }

        [TestMethod]
        public void zoom_up()
        {
            Line line = new Line(new PointF(100, 100), new PointF(200, 150));

            Assert.AreEqual(new PointF(100, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 150), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(200, 50));

            Assert.AreEqual(new PointF(100, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 50), line.DrawPoint2);
            //Assert.AreEqual(new PointF(100, 50), line.Point1);
            //Assert.AreEqual(new PointF(200, 100), line.Point2);
        }

        [TestMethod] public void zoom_up_switch() 
        {
            Line line = new Line(new PointF(200, 150), new PointF(100, 100));

            Assert.AreEqual(new PointF(200, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(200, 50));

            Assert.AreEqual(new PointF(200, 50), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_up_reverse()
        {
            Line line = new Line(new PointF(100, 150), new PointF(200, 100));

            Assert.AreEqual(new PointF(100, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(200, 50));

            Assert.AreEqual(new PointF(100, 50), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 100), line.DrawPoint2);
            //Assert.AreEqual(new PointF(100, 50), line.Point1);
            //Assert.AreEqual(new PointF(200, 100), line.Point2);
        }

        [TestMethod]
        public void zoom_up_reverse_switch()
        {
            Line line = new Line(new PointF(200, 100), new PointF(100, 150));

            Assert.AreEqual(new PointF(200, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 150), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(200, 50));

            Assert.AreEqual(new PointF(200, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 50), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_down()
        {
            Line line = new Line(new PointF(100, 100), new PointF(200, 50));

            Assert.AreEqual(new PointF(100, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 50), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 50), line.Point1);
            Assert.AreEqual(new PointF(200, 100), line.Point2);

            line.Zoom(new PointF(200, 150));

            Assert.AreEqual(new PointF(100, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 50), line.DrawPoint2);
        }


        [TestMethod]
        public void zoom_down_switch()
        {
            Line line = new Line(new PointF(200, 50), new PointF(100, 100));

            Assert.AreEqual(new PointF(200, 50), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 50), line.Point1);
            Assert.AreEqual(new PointF(200, 100), line.Point2);

            line.Zoom(new PointF(200, 150));

            Assert.AreEqual(new PointF(200, 50), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 150), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_down_reverse()
        {
            Line line = new Line(new PointF(100, 50), new PointF(200, 100));

            Assert.AreEqual(new PointF(100, 50), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 50), line.Point1);
            Assert.AreEqual(new PointF(200, 100), line.Point2);

            line.Zoom(new PointF(200, 150));

            Assert.AreEqual(new PointF(100, 50), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 150), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_down_reverse_switch()
        {
            Line line = new Line(new PointF(200, 100), new PointF(100, 50));

            Assert.AreEqual(new PointF(200, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 50), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 50), line.Point1);
            Assert.AreEqual(new PointF(200, 100), line.Point2);

            line.Zoom(new PointF(200, 150));

            Assert.AreEqual(new PointF(200, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 50), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_left()
        {
            Line line = new Line(new PointF(100, 100), new PointF(200, 150));

            Assert.AreEqual(new PointF(100, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 150), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(0, 150));

            Assert.AreEqual(new PointF(100, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(0, 150), line.DrawPoint2);
            //Assert.AreEqual(new PointF(0, 100), line.Point1);
            //Assert.AreEqual(new PointF(100, 150), line.Point2);
        }

        [TestMethod] public void zoom_left_switch()
        {
            Line line = new Line(new PointF(200, 150), new PointF(100, 100));

            Assert.AreEqual(new PointF(200, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(0, 150));

            Assert.AreEqual(new PointF(0, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
        }   

        [TestMethod]
        public void zoom_left_reverse()
        {
            Line line = new Line(new PointF(100, 150), new PointF(200, 100));

            Assert.AreEqual(new PointF(100, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(0, 150));

            Assert.AreEqual(new PointF(100, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(0, 100), line.DrawPoint2);
            //Assert.AreEqual(new PointF(0, 100), line.Point1);
            //Assert.AreEqual(new PointF(100, 150), line.Point2);
        }

        [TestMethod]
        public void zoom_left_reverse_switch() 
        { 
            Line line = new Line(new PointF(200, 100), new PointF(100, 150));

            Assert.AreEqual(new PointF(200, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 150), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(0, 150));

            Assert.AreEqual(new PointF(0, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 150), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_right()
        {
            Line line = new Line(new PointF(100, 100), new PointF(200, 150));

            Assert.AreEqual(new PointF(100, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 150), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(300, 150));

            Assert.AreEqual(new PointF(100, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(300, 150), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_right_switch() 
        {
            Line line = new Line(new PointF(200, 150), new PointF(100, 100));

            Assert.AreEqual(new PointF(200, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(300, 150));

            Assert.AreEqual(new PointF(300, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 100), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_right_reverse()
        {
            Line line = new Line(new PointF(100, 150), new PointF(200, 100));

            Assert.AreEqual(new PointF(100, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(200, 100), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(300, 150));

            Assert.AreEqual(new PointF(100, 150), line.DrawPoint1);
            Assert.AreEqual(new PointF(300, 100), line.DrawPoint2);
        }

        [TestMethod]
        public void zoom_right_reverse_switch()
        {
            Line line = new Line(new PointF(200, 100), new PointF(100, 150));

            Assert.AreEqual(new PointF(200, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 150), line.DrawPoint2);
            Assert.AreEqual(new PointF(100, 100), line.Point1);
            Assert.AreEqual(new PointF(200, 150), line.Point2);

            line.Zoom(new PointF(300, 150));

            Assert.AreEqual(new PointF(300, 100), line.DrawPoint1);
            Assert.AreEqual(new PointF(100, 150), line.DrawPoint2);
        }   

        [TestMethod]
        public void draw_line()
        {
            Line line = new Line(new PointF(0, 0), new PointF(100, 100));
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            line.Draw(graphic);

            Assert.IsTrue(graphic.IsLine);
        }

        [TestMethod]
        public void draw_selected_line()
        {
            Line line = new Line(new PointF(0, 0), new PointF(100, 100));
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            line.DrawSelected(graphic);

            Assert.IsTrue(graphic.IsSelectedShape);
        }
    }
}