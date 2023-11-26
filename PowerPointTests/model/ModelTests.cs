using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using PowerPoint.model.state;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model.test
{
    [TestClass]
    public class ModelTests
    {
        DrawingState _drawingState;
        PointState _pointState;
        Model _model;

        [TestInitialize]
        public void init()
        {
            _model = new Model();
            _model.SetState(_drawingState, _pointState);
        }

        [TestMethod]
        public void make_sure_constructor_work()
        {
        }

        [TestMethod]
        public void add_shape_with_only_name()
        {
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Line", shapes[1].Name);
            Assert.AreEqual("Rectangle", shapes[2].Name);
        }

        [TestMethod]
        public void add_shape_with_name_and_position()
        {
            _model.Add("Circle", new PointF(100, 200), new PointF(200, 100));
            _model.Add("Line", new PointF(200, 100), new PointF(100, 200));
            _model.Add("Rectangle", new PointF(100, 200), new PointF(200, 100));

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(3, shapes.Count);

            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[0].Point1);
            Assert.AreEqual(new PointF(200, 200), shapes[0].Point2);

            Assert.AreEqual("Line", shapes[1].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[1].Point1);
            Assert.AreEqual(new PointF(200, 200), shapes[1].Point2);

            Assert.AreEqual("Rectangle", shapes[2].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[2].Point1);
            Assert.AreEqual(new PointF(200, 200), shapes[2].Point2);
        }

        [TestMethod]
        public void remove_and_clear_shape()
        {
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(3, shapes.Count);

            _model.Remove(1);
            shapes = _model.GetListOfShape();
            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Rectangle", shapes[1].Name);

            _model.Clear();
            Assert.AreEqual(0, _model.GetListOfShape().Count);
        }

        [TestMethod]
        public void set_shape_name()
        {
        }
    }
}