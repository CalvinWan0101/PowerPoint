using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using PowerPoint.model.state;
using PowerPointTests.model.shape;
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
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
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
            _model.SetShapeName("Circle");
            Assert.AreEqual("Circle", _drawingState.ShapeName);
        }

        [TestMethod]
        public void create_shape_with_mouse()
        {
            _model.SetShapeName("Rectangle");
            _model.MousePress(false, new PointF(100, 200));
            _model.MouseMove(false, new PointF(200, 100));
            _model.MouseRelease(false, new PointF(200, 100));

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Rectangle", shapes[0].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[0].Point1);
            Assert.AreEqual(new PointF(200, 200), shapes[0].Point2);
        }

        [TestMethod]
        public void zoom_shape()
        {
            _model.Add("Rectangle", new PointF(100, 200), new PointF(200, 100));
            _model.MousePress(true, new PointF(200, 200));
            _model.MouseMove(true, new PointF(300, 300));
            _model.MouseRelease(true, new PointF(300, 300));

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Rectangle", shapes[0].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[0].Point1);
            Assert.AreEqual(new PointF(300, 300), shapes[0].Point2);
        }

        [TestMethod]
        public void find_target_index()
        {
            _model.Add("Rectangle", new PointF(100, 200), new PointF(200, 100));
            _model.Add("Circle", new PointF(200, 300), new PointF(300, 200));
            _model.Add("Line", new PointF(300, 400), new PointF(400, 300));

            Assert.AreEqual(0, _model.FindTargetIndex(new PointF(150, 150)));
            Assert.AreEqual(1, _model.FindTargetIndex(new PointF(250, 250)));
            Assert.AreEqual(2, _model.FindTargetIndex(new PointF(350, 350)));
            Assert.AreEqual(-1, _model.FindTargetIndex(new PointF(99, 99)));
        }

        [TestMethod]
        public void draw()
        {
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            _model.Add("Circle");
            _model.Add("Line");
            _model.GetShapes().SetHint("Rectangle", new PointF(100, 200), new PointF(200, 100));
            _model.GetShapes().AddHint();

            _pointState.TargetIndex = 1;
            _model.Draw(graphic);

            Assert.IsTrue(graphic.IsClearAll);
            Assert.IsTrue(graphic.IsLine);
            Assert.IsTrue(graphic.IsRectangle);
            Assert.IsTrue(graphic.IsCircle);
            Assert.IsTrue(graphic.IsSelectedShape);
        }

    }
}