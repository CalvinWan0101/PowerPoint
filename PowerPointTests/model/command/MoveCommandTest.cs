using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.state;
using PowerPoint.model;
using PowerPoint.model.shape;
using System.ComponentModel;
using System.Drawing;

namespace PowerPointTests.model.command
{
    [TestClass]
    public class MoveCommandTest
    {
        DrawingState _drawingState;
        PointState _pointState;
        Model _model;

        [TestInitialize]
        public void initialize()
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
        public void execute_move_command()
        {
            _model.MouseButtonChecked = true;
            _model.Add("Rectangle", new PointF(100, 200), new PointF(200, 100));
            _model.MousePress(new PointF(200, 100));
            _model.MouseMove(new PointF(300, 300));
            _model.MouseRelease(new PointF(300, 300));

            Assert.AreEqual(1, _model.GetListOfShape().Count);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Rectangle", shapes[0].Name);
            Assert.AreEqual(new PointF(200, 300), shapes[0].Point1);
            Assert.AreEqual(new PointF(300, 400), shapes[0].Point2);
        }

        [TestMethod]
        public void execute_move_command_with_line()
        {
            _model.MouseButtonChecked = true;
            _model.Add("Line", new PointF(100, 200), new PointF(200, 100));
            _model.MousePress(new PointF(200, 100));
            _model.MouseMove(new PointF(300, 300));
            _model.MouseRelease(new PointF(300, 300));

            Assert.AreEqual(1, _model.GetListOfShape().Count);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Line", shapes[0].Name);
            Assert.AreEqual(new PointF(200, 300), shapes[0].Point1);
            Assert.AreEqual(new PointF(300, 400), shapes[0].Point2);
            Assert.AreEqual(new PointF(200, 400), ((Line)shapes[0]).DrawPoint1);
            Assert.AreEqual(new PointF(300, 300), ((Line)shapes[0]).DrawPoint2);
        }

        [TestMethod]
        public void undo_move_command()
        {
            _model.MouseButtonChecked = true;
            _model.Add("Rectangle", new PointF(100, 200), new PointF(200, 100));
            _model.MousePress(new PointF(200, 100));
            _model.MouseMove(new PointF(300, 300));
            _model.MouseRelease(new PointF(300, 300));

            Assert.AreEqual(1, _model.GetListOfShape().Count);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Rectangle", shapes[0].Name);
            Assert.AreEqual(new PointF(200, 300), shapes[0].Point1);
            Assert.AreEqual(new PointF(300, 400), shapes[0].Point2);

            _model.Undo();

            Assert.AreEqual(1, _model.GetListOfShape().Count);

            shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Rectangle", shapes[0].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[0].Point1);
            Assert.AreEqual(new PointF(200, 200), shapes[0].Point2);
        }

        [TestMethod]
        public void undo_move_command_with_line()
        {
            _model.MouseButtonChecked = true;
            _model.Add("Line", new PointF(100, 200), new PointF(200, 100));
            _model.MousePress(new PointF(200, 100));
            _model.MouseMove(new PointF(300, 300));
            _model.MouseRelease(new PointF(300, 300));

            Assert.AreEqual(1, _model.GetListOfShape().Count);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Line", shapes[0].Name);
            Assert.AreEqual(new PointF(200, 300), shapes[0].Point1);
            Assert.AreEqual(new PointF(300, 400), shapes[0].Point2);
            Assert.AreEqual(new PointF(200, 400), ((Line)shapes[0]).DrawPoint1);
            Assert.AreEqual(new PointF(300, 300), ((Line)shapes[0]).DrawPoint2);

            _model.Undo();

            Assert.AreEqual(1, _model.GetListOfShape().Count);

            shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Line", shapes[0].Name);
            Assert.AreEqual(new PointF(100, 100), shapes[0].Point1);
            Assert.AreEqual(new PointF(200, 200), shapes[0].Point2);
            Assert.AreEqual(new PointF(100, 200), ((Line)shapes[0]).DrawPoint1);
            Assert.AreEqual(new PointF(200, 100), ((Line)shapes[0]).DrawPoint2);
        }
    }
}
