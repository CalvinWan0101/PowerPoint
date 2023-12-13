using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using System;
using System.Drawing;

namespace PowerPoint.model.test {
    [TestClass]
    public class ShapesTests {
        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        Shapes _shapes;

        [TestInitialize]
        public void Initialize() {
            _shapes = new Shapes();
        }

        [TestMethod]
        public void make_sure_constructor_work() {
        }

        [TestMethod]
        public void create_and_add_shape_by_name() {
            _shapes.Add("Line");
            _shapes.Add("Rectangle");
            _shapes.Add("Circle");

            Assert.AreEqual(3, _shapes.GetListOfShape().Count);

            Assert.AreEqual("Line", _shapes.GetListOfShape()[0].Name);
            Assert.AreEqual("線", _shapes.GetListOfShape()[0].ChineseName);


            Assert.AreEqual("Rectangle", _shapes.GetListOfShape()[1].Name);
            Assert.AreEqual("矩形", _shapes.GetListOfShape()[1].ChineseName);

            Assert.AreEqual("Circle", _shapes.GetListOfShape()[2].Name);
            Assert.AreEqual("圓", _shapes.GetListOfShape()[2].ChineseName);
        }

        [TestMethod]
        public void create_and_add_shape_by_name_point() {
            PointF point1 = new PointF(0, 100);
            PointF point2 = new PointF(100, 0);

            PointF point1_ = new PointF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            PointF point2_ = new PointF(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));

            _shapes.Add("Line", point1, point2);
            _shapes.Add("Rectangle", point1, point2);
            _shapes.Add("Circle", point1, point2);


            Assert.AreEqual(3, _shapes.GetListOfShape().Count);

            Assert.AreEqual("Line", _shapes.GetListOfShape()[0].Name);
            Assert.AreEqual("線", _shapes.GetListOfShape()[0].ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)point1.X, (int)point1.Y) + COMMA + string.Format(TEMPLATE, (int)point2.X, (int)point2.Y), _shapes.GetListOfShape()[0].Information);
            Assert.AreEqual(point1_, _shapes.GetListOfShape()[0].Point1);
            Assert.AreEqual(point2_, _shapes.GetListOfShape()[0].Point2);

            Assert.AreEqual("Rectangle", _shapes.GetListOfShape()[1].Name);
            Assert.AreEqual("矩形", _shapes.GetListOfShape()[1].ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)point1_.X, (int)point1_.Y) + COMMA + string.Format(TEMPLATE, (int)point2_.X, (int)point2_.Y), _shapes.GetListOfShape()[1].Information);

            Assert.AreEqual(point1_, _shapes.GetListOfShape()[1].Point1);
            Assert.AreEqual(point2_, _shapes.GetListOfShape()[1].Point2);

            Assert.AreEqual("Circle", _shapes.GetListOfShape()[2].Name);
            Assert.AreEqual("圓", _shapes.GetListOfShape()[2].ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, (int)point1_.X, (int)point1_.Y) + COMMA + string.Format(TEMPLATE, (int)point2_.X, (int)point2_.Y), _shapes.GetListOfShape()[2].Information);

            Assert.AreEqual(point1_, _shapes.GetListOfShape()[2].Point1);
            Assert.AreEqual(point2_, _shapes.GetListOfShape()[2].Point2);
        }

        [TestMethod]
        public void add_exist_shape() 
        {
            Shape shape = new Line(new PointF(0, 0), new PointF(100, 100));
            _shapes.Add(shape);

            Assert.AreEqual(1, _shapes.GetListOfShape().Count);

            Assert.AreEqual("Line", _shapes.GetListOfShape()[0].Name);
            Assert.AreEqual("線", _shapes.GetListOfShape()[0].ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, 0, 0) + COMMA + string.Format(TEMPLATE, 100, 100), _shapes.GetListOfShape()[0].Information);
            Assert.AreEqual(new PointF(0, 0), _shapes.GetListOfShape()[0].Point1);
            Assert.AreEqual(new PointF(100, 100), _shapes.GetListOfShape()[0].Point2);
        }

        [TestMethod]
        public void clear_list_of_shape() {
            _shapes.Add("Line");
            _shapes.Add("Rectangle");
            _shapes.Add("Circle");

            Assert.AreEqual(3, _shapes.GetListOfShape().Count);

            _shapes.Clear();

            Assert.AreEqual(0, _shapes.GetListOfShape().Count);
        }

        [TestMethod]
        public void remove_shape_by_index() {
            _shapes.Add("Line");
            _shapes.Add("Rectangle");
            _shapes.Add("Circle");

            Assert.AreEqual(3, _shapes.GetListOfShape().Count);

            _shapes.Remove(1);

            Assert.AreEqual(2, _shapes.GetListOfShape().Count);

            Assert.AreEqual("Line", _shapes.GetListOfShape()[0].Name);
            Assert.AreEqual("線", _shapes.GetListOfShape()[0].ChineseName);

            Assert.AreEqual("Circle", _shapes.GetListOfShape()[1].Name);
            Assert.AreEqual("圓", _shapes.GetListOfShape()[1].ChineseName);

            _shapes.Remove(0);
            _shapes.Remove(0);

            Assert.AreEqual(0, _shapes.GetListOfShape().Count);
        }

        [TestMethod]
        public void set_and_get_hint() {
            _shapes.SetHint("Line", new PointF(0, 0), new PointF(100, 100));

            Assert.AreEqual("Line", _shapes.GetHint().Name);
            Assert.AreEqual("線", _shapes.GetHint().ChineseName);
            Assert.AreEqual(string.Format(TEMPLATE, 0, 0) + COMMA + string.Format(TEMPLATE, 100, 100), _shapes.GetHint().Information);
            Assert.AreEqual(new PointF(0, 0), _shapes.GetHint().Point1);
            Assert.AreEqual(new PointF(100, 100), _shapes.GetHint().Point2);
        }

        [TestMethod]
        public void add_hint_into_list() {
            _shapes.SetHint("Line", new PointF(0, 0), new PointF(100, 100));
            _shapes.AddHint();
            _shapes.Add("Rectangle");
            _shapes.Add("Circle");

            Assert.AreEqual(3, _shapes.GetListOfShape().Count);
            Assert.AreEqual("Line", _shapes.GetListOfShape()[0].Name);
            Assert.AreEqual("Rectangle", _shapes.GetListOfShape()[1].Name);
            Assert.AreEqual("Circle", _shapes.GetListOfShape()[2].Name);
        }   
    }
}