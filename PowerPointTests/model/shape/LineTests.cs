using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void get_set()
        {
            Shape shapeRandom = _factory.CreateShape("Line");
            if (shapeRandom is Line line)
            {

                line.DrawPoint1Record = new PointF(1, 1);
                line.DrawPoint2Record = new PointF(2, 2);
                Assert.AreEqual(new PointF(1, 1), line.DrawPoint1Record);
                Assert.AreEqual(new PointF(2, 2), line.DrawPoint2Record);
            }
        }

        [TestMethod]
        public void create_line_by_random_point()
        {
            Shape shapeRandom = _factory.CreateShape("Line");

            PointF drawPoint1 = new PointF();
            PointF drawPoint2 = new PointF();
            if (shapeRandom is Line line)
            {
                drawPoint1 = line.DrawPoint1;
                drawPoint2 = line.DrawPoint2;
            }

            Assert.AreEqual("Line", shapeRandom.Name);
            Assert.AreEqual("線", shapeRandom.ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shapeRandom.Information);

            PointF point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
            PointF point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
            Assert.AreEqual(point1, shapeRandom.Point1);
            Assert.AreEqual(point2, shapeRandom.Point2);
        }

        [TestMethod]
        public void create_line()
        {
            PointF drawPoint1 = new PointF(0, 0);
            PointF drawPoint2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.AreEqual("Line", shape.Name);
            Assert.AreEqual("線", shape.ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);

            PointF point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
            PointF point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
            Assert.AreEqual(point1, shape.Point1);
            Assert.AreEqual(point2, shape.Point2);
        }

        [TestMethod]
        public void create_line_reverse()
        {
            PointF drawPoint1 = new PointF(0, 100);
            PointF drawPoint2 = new PointF(100, 0);
            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.AreEqual("Line", shape.Name);
            Assert.AreEqual("線", shape.ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);

            PointF point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
            PointF point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
            Assert.AreEqual(point1, shape.Point1);
            Assert.AreEqual(point2, shape.Point2);
        }

        [TestMethod]
        public void check_if_the_line_contains_point()
        {
            PointF drawPoint1 = new PointF(0, 0);
            PointF drawPoint2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.IsTrue(shape.Contains(new PointF(50, 50)));
            Assert.IsTrue(shape.Contains(new PointF(0, 0)));
            Assert.IsTrue(shape.Contains(new PointF(0, 100)));
            Assert.IsTrue(shape.Contains(new PointF(100, 0)));
            Assert.IsTrue(shape.Contains(new PointF(100, 100)));

            Assert.IsFalse(shape.Contains(new PointF(50, -1)));
            Assert.IsFalse(shape.Contains(new PointF(50, 101)));
            Assert.IsFalse(shape.Contains(new PointF(-1, 50)));
            Assert.IsFalse(shape.Contains(new PointF(101, 50)));
            Assert.IsFalse(shape.Contains(new PointF(101, 101)));
            Assert.IsFalse(shape.Contains(new PointF(-1, -1)));
        }

        [TestMethod]
        public void check_if_the_line_contains_point_reverse()
        {
            PointF drawPoint1 = new PointF(0, 100);
            PointF drawPoint2 = new PointF(100, 0);
            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.IsTrue(shape.Contains(new PointF(50, 50)));
            Assert.IsTrue(shape.Contains(new PointF(0, 0)));
            Assert.IsTrue(shape.Contains(new PointF(0, 100)));
            Assert.IsTrue(shape.Contains(new PointF(100, 0)));
            Assert.IsTrue(shape.Contains(new PointF(100, 100)));

            Assert.IsFalse(shape.Contains(new PointF(50, -1)));
            Assert.IsFalse(shape.Contains(new PointF(50, 101)));
            Assert.IsFalse(shape.Contains(new PointF(-1, 50)));
            Assert.IsFalse(shape.Contains(new PointF(101, 50)));
            Assert.IsFalse(shape.Contains(new PointF(101, 101)));
            Assert.IsFalse(shape.Contains(new PointF(-1, -1)));
        }

        [TestMethod]
        public void move_line()
        {
            PointF drawPoint1 = new PointF(0, 0);
            PointF drawPoint2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);

            PointF firstPoint = new PointF(50, 50);
            PointF secondPoint = new PointF(150, 150);
            drawPoint1 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            drawPoint2 += new SizeF(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            shape.Move(firstPoint, secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);
        }

        [TestMethod]
        public void zoom_line_to_right_down()
        {
            PointF drawPoint1 = new PointF(0, 0);
            PointF drawPoint2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);

            PointF secondPoint = new PointF(150, 150);
            drawPoint2 = new PointF(secondPoint.X, secondPoint.Y);
            shape.Zoom(secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);
        }

        [TestMethod]
        public void zoom_line_to_left_up()
        {
            PointF drawPoint1 = new PointF(50, 50);
            PointF drawPoint2 = new PointF(100, 100);
            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);

            PointF secondPoint = new PointF(25, 25);
            drawPoint2 = new PointF(secondPoint.X, secondPoint.Y);
            shape.Zoom(secondPoint);

            Assert.AreEqual(string.Format(TEMPLATE, (int)drawPoint1.X, (int)drawPoint1.Y) + COMMA + string.Format(TEMPLATE, (int)drawPoint2.X, (int)drawPoint2.Y), shape.Information);
        }

        // the horizontal line
        [TestMethod]
        public void zoom_horizontal_line_with_left_right()
        {
            PointF drawPoint1 = new PointF(100, 100);
            PointF drawPoint2 = new PointF(200, 150);
            PointF point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
            PointF point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));

            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);



            if (shape is Line line)
            {
                Assert.AreEqual(drawPoint1, line.DrawPoint1);
                Assert.AreEqual(drawPoint2, line.DrawPoint2);
                Assert.AreEqual(point1, shape.Point1);
                Assert.AreEqual(point2, shape.Point2);

                // zoom
                PointF secondPoint = new PointF(200, 100);
                drawPoint2 = secondPoint;
                point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
                point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
                shape.Zoom(secondPoint);

                Assert.AreEqual(drawPoint1, line.DrawPoint1);
                Assert.AreEqual(drawPoint2, line.DrawPoint2);
                Assert.AreEqual(point1, shape.Point1);
                Assert.AreEqual(point2, shape.Point2);

                secondPoint = new PointF(200, 50);
                drawPoint2 = secondPoint;
                point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
                point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
                shape.Zoom(secondPoint);
                shape.UpdatePoint();

                Assert.AreEqual(drawPoint1, line.DrawPoint1);
                Assert.AreEqual(drawPoint2, line.DrawPoint2);
                Assert.AreEqual(point1, shape.Point1);
                Assert.AreEqual(point2, shape.Point2);
            }
        }

        [TestMethod]
        public void zoom_vertical_with_left_up_and_right_down() {
            PointF drawPoint1 = new PointF(100, 100);
            PointF drawPoint2 = new PointF(150, 200);
            PointF point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
            PointF point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));

            Shape shape = _factory.CreateShape("Line", drawPoint1, drawPoint2);

            if (shape is Line line)
            {
                Assert.AreEqual(drawPoint1, line.DrawPoint1);
                Assert.AreEqual(drawPoint2, line.DrawPoint2);
                Assert.AreEqual(point1, shape.Point1);
                Assert.AreEqual(point2, shape.Point2);

                // zoom
                PointF secondPoint = new PointF(50, 200);
                drawPoint1 = secondPoint;
                point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
                point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
                shape.Zoom(secondPoint);

                Assert.AreEqual(drawPoint1, line.DrawPoint1);
                Assert.AreEqual(drawPoint2, line.DrawPoint2);
                Assert.AreEqual(point1, shape.Point1);
                Assert.AreEqual(point2, shape.Point2);

                secondPoint = new PointF(200, 200);
                drawPoint2 = secondPoint;
                point1 = new PointF(Math.Min(drawPoint1.X, drawPoint2.X), Math.Min(drawPoint1.Y, drawPoint2.Y));
                point2 = new PointF(Math.Max(drawPoint1.X, drawPoint2.X), Math.Max(drawPoint1.Y, drawPoint2.Y));
                shape.Zoom(secondPoint);
                shape.UpdatePoint();

                Assert.AreEqual(drawPoint1, line.DrawPoint1);
                Assert.AreEqual(drawPoint2, line.DrawPoint2);
                Assert.AreEqual(point1, shape.Point1);
                Assert.AreEqual(point2, shape.Point2);
            }   
        
        }

        [TestMethod]
        public void zoom_line_with_left_up_and_left_down() { }

        [TestMethod]
        public void zoom_line_with_right_up_and_right_down() { }

        [TestMethod]
        public void zoom_line_with_right_up_and_left_down() { }
    }
}