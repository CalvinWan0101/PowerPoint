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

        private int _modelChangedCount = 0;

        private void TestModelChanged()
        {
            _modelChangedCount++;
        }

        [TestInitialize]
        public void initialize()
        {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
            _model._modelChanged += TestModelChanged;
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
            _model.MouseButtonChecked = false;
            _model.SetShapeName("Rectangle");
            _model.MousePress(new PointF(100, 200));
            _model.MouseMove(new PointF(200, 100));
            _model.MouseRelease(new PointF(200, 100));

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.IsFalse(_model.MouseButtonChecked);
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Rectangle", shapes[0].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[0].Point1);
            Assert.AreEqual(new PointF(200, 200), shapes[0].Point2);
        }

        [TestMethod]
        public void zoom_shape()
        {
            _model.MouseButtonChecked = true;
            _model.Add("Rectangle", new PointF(100, 200), new PointF(200, 100));
            _model.MousePress(new PointF(200, 200));
            _model.MouseMove(new PointF(300, 300));
            _model.MouseRelease(new PointF(300, 300));

            Assert.AreEqual(1, _model.GetListOfShape().Count);

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
            _model.Add("Line");
            _model.Add("Line");
            _model.GetShapes().SetHint("Rectangle", new PointF(100, 200), new PointF(200, 100));
            _model.GetShapes().AddHint();

            _pointState.TargetIndex = 1;
            _model.Draw(graphic);

            Assert.AreEqual(1, graphic.IsClearAll);
            Assert.AreEqual(3, graphic.IsLine);
            Assert.AreEqual(1, graphic.IsRectangle);
            Assert.AreEqual(1, graphic.IsCircle);
            Assert.AreEqual(1, graphic.IsSelectedShape);
        }

        [TestMethod]
        public void draw_while_mouse_moving()
        {
            _model.MouseButtonChecked = false;
            FakeGraphicsAdaptor graphic = new FakeGraphicsAdaptor();
            _model.SetShapeName("Rectangle");
            _model.MousePress(new PointF(100, 200));
            _model.MouseMove(new PointF(200, 100));
            _pointState.TargetIndex = -1;
            _model.Draw(graphic);

            Assert.AreEqual(1, graphic.IsClearAll);
            Assert.AreEqual(0, graphic.IsLine);
            Assert.AreEqual(1, graphic.IsRectangle);
            Assert.AreEqual(0, graphic.IsCircle);
            Assert.AreEqual(0, graphic.IsSelectedShape);
        }

        [TestMethod]
        public void press_dlete_key()
        {
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");

            BindingList<Shape> shapes = _model.GetListOfShape();
            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Line", shapes[1].Name);
            Assert.AreEqual("Rectangle", shapes[2].Name);

            _pointState.TargetIndex = 1;
            _model.PressDeleteKey();

            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Rectangle", shapes[1].Name);

            _pointState.TargetIndex = -1;
            _model.PressDeleteKey();

            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Rectangle", shapes[1].Name);
        }

        [TestMethod]
        public void is_click_the_right_button_corner()
        {
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");
            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Line", shapes[1].Name);
            Assert.AreEqual("Rectangle", shapes[2].Name);

            _pointState.TargetIndex = 1;

            PointF answer = shapes[_pointState.TargetIndex].Point2;

            int radius = 10;

            // shape found
            Assert.IsTrue(_model.IsClickTheRightBottomCorner(answer));

            Assert.IsTrue(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius + 100)));
            Assert.IsTrue(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius - 100)));

            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius + 100)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius - 100)));

            Assert.IsTrue(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius + 100)));
            Assert.IsTrue(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius - 100)));

            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius + 100)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius - 100)));

            // shape not found
            _pointState.TargetIndex = -1;
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer));

            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius + 100)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius - 100)));

            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius + 100)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius - 100)));

            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius + 100)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius - 100)));

            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius + 100)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius)));
            Assert.IsFalse(_model.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius - 100)));
        }

        [TestMethod]
        public void notify_model_changed()
        {
            _model.NotifyModelChanged();
            _model.NotifyModelChanged();
            Assert.AreEqual(2, _modelChangedCount);
        }
    }
}