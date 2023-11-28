using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model.state.test
{
    [TestClass]
    public class PointStateTests
    {
        Model _model;
        DrawingState _drawingState;
        PointState _pointState;

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
        }

        [TestCleanup]
        public void CleanUp()
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
        public void get_and_set()
        {
            _pointState.MouseIsPressed = true;
            Assert.IsTrue(_pointState.MouseIsPressed);

            _pointState.TargetIndex = 87;
            Assert.AreEqual(87, _pointState.TargetIndex);

            _pointState.IsZoom = true;
            Assert.IsTrue(_pointState.IsZoom);
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
            Assert.IsTrue(_pointState.IsClickTheRightBottomCorner(answer));

            Assert.IsTrue(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius + 100)));
            Assert.IsTrue(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius - 100)));

            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius + 100)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius - 100)));

            Assert.IsTrue(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius + 100)));
            Assert.IsTrue(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius - 100)));

            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius + 100)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius - 100)));

            // shape not found
            _pointState.TargetIndex = -1;
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer));

            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, radius + 100)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius, -radius - 100)));

            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, radius + 100)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(radius + 100, -radius - 100)));

            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, radius + 100)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius, -radius - 100)));

            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, radius + 100)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius)));
            Assert.IsFalse(_pointState.IsClickTheRightBottomCorner(answer + new SizeF(-radius - 100, -radius - 100)));
        }

        [TestMethod]
        public void click_delete_button()
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
            _pointState.ClickDeleteButton();

            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Rectangle", shapes[1].Name);

            _pointState.TargetIndex = -1;
            _pointState.ClickDeleteButton();

            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].Name);
            Assert.AreEqual("Rectangle", shapes[1].Name);
        }

        [TestMethod]
        public void zoom_a_shape()
        {
            _model.Add("Rectangle", new PointF(100, 100), new PointF(200, 200));

            _pointState.MousePress(new PointF(200, 200));
            _pointState.MouseMove(new PointF(300, 300));
            _pointState.MouseRelease(new PointF(300, 300));

            Assert.AreEqual(new PointF(100, 100), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(new PointF(300, 300), _model.GetListOfShape()[0].Point2);
        }

        [TestMethod]
        public void zoom_a_shape_but_didnt_select_any_shape_when_move()
        {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].Point1;
            PointF temp2 = _model.GetListOfShape()[0].Point2;


            _pointState.MousePress(temp2);
            temp2 += new SizeF(1, 1);


            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.TargetIndex = -1;
            _pointState.MouseMove(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.TargetIndex = 0;
            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2);

            Assert.AreEqual(temp2, _model.GetListOfShape()[0].Point2);

            // move the shape to left up
            _pointState.MousePress(temp2);
            temp2 = temp1 - new SizeF(1, 1);

            _pointState.MouseMove(temp2 - new SizeF(1, 1));

            _pointState.TargetIndex = -1;
            _pointState.MouseMove(temp2 - new SizeF(2, 2));
            _pointState.MouseRelease(temp2 + new SizeF(2, 2));

            _pointState.TargetIndex = 0;
            _pointState.MouseIsPressed = true;
            _pointState.MouseRelease(temp2);

            Assert.AreEqual(temp1, _model.GetListOfShape()[0].Point2);
        }

        // zoom a shape but move with mouse not pressed
        [TestMethod]
        public void zoom_a_shape_but_move_with_mouse_not_pressed()
        {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].Point1;
            PointF temp2 = _model.GetListOfShape()[0].Point2;

            _pointState.MousePress(temp2);
            temp2 += new SizeF(100, 100);

            _pointState.MouseMove(temp2 + new SizeF(100, 100));
            Assert.AreEqual(temp2 + new SizeF(100, 100), _model.GetListOfShape()[0].Point2);

            _pointState.MouseIsPressed = false;
            _pointState.MouseMove(temp2 + new SizeF(200, 200));
            Assert.AreEqual(temp2 + new SizeF(100, 100), _model.GetListOfShape()[0].Point2);

            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2);
            Assert.AreEqual(temp2, _model.GetListOfShape()[0].Point2);

            _pointState.MousePress(temp2);
            temp2 = temp1 - new SizeF(100, 100);

            _pointState.MouseMove(temp2 - new SizeF(100, 100));

            _pointState.MouseIsPressed = false;
            _pointState.MouseMove(temp2 - new SizeF(200, 200));

            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2);
            Assert.AreEqual(temp1, _model.GetListOfShape()[0].Point2);
        }

        // move a shape
        [TestMethod]
        public void move_a_shape()
        {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].Point1;
            PointF temp2 = _model.GetListOfShape()[0].Point2;

            _pointState.MousePress(temp2);

            _pointState.IsZoom = false;

            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp1 + new SizeF(2, 2), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(2, 2), _model.GetListOfShape()[0].Point2);
        }

        // move a shape but didn't select any shape when move or release
        [TestMethod]
        public void move_a_shape_but_didnt_select_any_shape_when_move_or_release()
        {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].Point1;
            PointF temp2 = _model.GetListOfShape()[0].Point2;

            _pointState.MousePress(temp2);

            _pointState.IsZoom = false;

            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.TargetIndex = -1;
            _pointState.MouseMove(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.MouseRelease(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.TargetIndex = 0;
            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp1 + new SizeF(2, 2), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(2, 2), _model.GetListOfShape()[0].Point2);
        }

        // move a shape but move with mouse not pressed
        [TestMethod]
        public void move_a_shape_but_move_with_mouse_not_pressed()
        {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].Point1;
            PointF temp2 = _model.GetListOfShape()[0].Point2;

            _pointState.MousePress(temp2);

            _pointState.IsZoom = false;

            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.MouseIsPressed = false;

            _pointState.MouseMove(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.MouseRelease(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].Point2);

            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp1 + new SizeF(2, 2), _model.GetListOfShape()[0].Point1);
            Assert.AreEqual(temp2 + new SizeF(2, 2), _model.GetListOfShape()[0].Point2);
        }
    }
}