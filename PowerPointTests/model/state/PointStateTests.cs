using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model.state.test {
    [TestClass]
    public class PointStateTests {
        private Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        Model _model;
        DrawingState _drawingState;
        PointState _pointState;

        // initialize the test
        [TestInitialize]
        public void Initialize() {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
        }

        // reset the _model, _drawingState and _pointState after each test method
        [TestCleanup]
        public void CleanUp() {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
        }

        // make sure constructor work
        [TestMethod]
        public void make_sure_constructor_work() {
        }

        // get and set
        [TestMethod]
        public void get_and_set() {
            _pointState.MouseIsPressed = true;
            Assert.IsTrue(_pointState.MouseIsPressed);

            _pointState.TargetIndex = 87;
            Assert.AreEqual(87, _pointState.TargetIndex);

            _pointState.IsZoom = true;
            Assert.IsTrue(_pointState.IsZoom);
        }

        // is click the right button corner
        [TestMethod]
        public void is_click_the_right_button_corner() {
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");

            BindingList<Shape> shapes = _model.GetListOfShape();
            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual("Line", shapes[1].GetShapeName());
            Assert.AreEqual("Rectangle", shapes[2].GetShapeName());

            _pointState.TargetIndex = 1;

            PointF answer = shapes[_pointState.TargetIndex].GetPoint2();
            int radius = 50;

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

        // click delete button
        [TestMethod]
        public void click_delete_button() {
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");

            BindingList<Shape> shapes = _model.GetListOfShape();
            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual("Line", shapes[1].GetShapeName());
            Assert.AreEqual("Rectangle", shapes[2].GetShapeName());

            _pointState.TargetIndex = 1;
            _pointState.ClickDeleteButton();

            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual("Rectangle", shapes[1].GetShapeName());

            _pointState.TargetIndex = -1;
            _pointState.ClickDeleteButton();

            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual("Rectangle", shapes[1].GetShapeName());
        }

        // zoom a shape
        [TestMethod]
        public void zoom_a_shape() {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].GetPoint1();
            PointF temp2 = _model.GetListOfShape()[0].GetPoint2();

            _pointState.MousePress(temp2);
            temp2 += new SizeF(100, 100);

            _pointState.MouseMove(temp2 + new SizeF(100, 100));
            Assert.AreEqual(temp2 + new SizeF(100, 100), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseRelease(temp2);
            Assert.AreEqual(temp2, _model.GetListOfShape()[0].GetPoint2());

            _pointState.MousePress(temp2);
            temp2 = temp1 - new SizeF(100, 100);

            _pointState.MouseMove(temp2 - new SizeF(100, 100));
            Assert.AreEqual(temp2 - new SizeF(100, 100), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseRelease(temp2);
            Assert.AreEqual(temp1, _model.GetListOfShape()[0].GetPoint2());
        }

        // zoom a shape but didn't select any shape when move or release
        [TestMethod]
        public void zoom_a_shape_but_didnt_select_any_shape_when_move() {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].GetPoint1();
            PointF temp2 = _model.GetListOfShape()[0].GetPoint2();


            // move the shape to right buttom
            _pointState.MousePress(temp2);
            temp2 += new SizeF(1, 1);


            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.TargetIndex = -1;
            _pointState.MouseMove(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.TargetIndex = 0;
            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2);

            Assert.AreEqual(temp2, _model.GetListOfShape()[0].GetPoint2());

            // move the shape to left up
            _pointState.MousePress(temp2);
            temp2 = temp1 - new SizeF(1, 1);

            _pointState.MouseMove(temp2 - new SizeF(1, 1));
            Assert.AreEqual(temp2 - new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.TargetIndex = -1;
            _pointState.MouseMove(temp2 - new SizeF(2, 2));
            Assert.AreEqual(temp2 - new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp2 - new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.TargetIndex = 0;
            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2);
            Assert.AreEqual(temp1, _model.GetListOfShape()[0].GetPoint2());
        }

        // zoom a shape but move with mouse not pressed
        [TestMethod]
        public void zoom_a_shape_but_move_with_mouse_not_pressed() {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].GetPoint1();
            PointF temp2 = _model.GetListOfShape()[0].GetPoint2();

            _pointState.MousePress(temp2);
            temp2 += new SizeF(100, 100);

            _pointState.MouseMove(temp2 + new SizeF(100, 100));
            Assert.AreEqual(temp2 + new SizeF(100, 100), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseIsPressed = false;
            _pointState.MouseMove(temp2 + new SizeF(200, 200));
            Assert.AreEqual(temp2 + new SizeF(100, 100), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2);
            Assert.AreEqual(temp2, _model.GetListOfShape()[0].GetPoint2());

            _pointState.MousePress(temp2);
            temp2 = temp1 - new SizeF(100, 100);

            _pointState.MouseMove(temp2 - new SizeF(100, 100));
            Assert.AreEqual(temp2 - new SizeF(100, 100), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseIsPressed = false;
            _pointState.MouseMove(temp2 - new SizeF(200, 200));
            Assert.AreEqual(temp2 - new SizeF(100, 100), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2);
            Assert.AreEqual(temp1, _model.GetListOfShape()[0].GetPoint2());
        }

        // move a shape
        [TestMethod]
        public void move_a_shape() {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].GetPoint1();
            PointF temp2 = _model.GetListOfShape()[0].GetPoint2();

            _pointState.MousePress(temp2);

            _pointState.IsZoom = false;

            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp1 + new SizeF(2, 2), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(2, 2), _model.GetListOfShape()[0].GetPoint2());
        }

        // move a shape but didn't select any shape when move or release
        [TestMethod]
        public void move_a_shape_but_didnt_select_any_shape_when_move_or_release() {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].GetPoint1();
            PointF temp2 = _model.GetListOfShape()[0].GetPoint2();

            _pointState.MousePress(temp2);

            _pointState.IsZoom = false;

            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.TargetIndex = -1;
            _pointState.MouseMove(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseRelease(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.TargetIndex = 0;
            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp1 + new SizeF(2, 2), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(2, 2), _model.GetListOfShape()[0].GetPoint2());
        }

        // move a shape but move with mouse not pressed
        [TestMethod]
        public void move_a_shape_but_move_with_mouse_not_pressed() {
            _model.Add("Rectangle");

            PointF temp1 = _model.GetListOfShape()[0].GetPoint1();
            PointF temp2 = _model.GetListOfShape()[0].GetPoint2();

            _pointState.MousePress(temp2);

            _pointState.IsZoom = false;

            _pointState.MouseMove(temp2 + new SizeF(1, 1));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseIsPressed = false;

            _pointState.MouseMove(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseRelease(temp2 + new SizeF(3, 3));
            Assert.AreEqual(temp1 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(1, 1), _model.GetListOfShape()[0].GetPoint2());

            _pointState.MouseIsPressed = true;

            _pointState.MouseRelease(temp2 + new SizeF(2, 2));
            Assert.AreEqual(temp1 + new SizeF(2, 2), _model.GetListOfShape()[0].GetPoint1());
            Assert.AreEqual(temp2 + new SizeF(2, 2), _model.GetListOfShape()[0].GetPoint2());
        }
    }
}