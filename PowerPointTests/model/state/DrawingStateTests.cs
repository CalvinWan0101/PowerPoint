﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model.state.test
{
    [TestClass]
    public class DrawingStateTests
    {
        private Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        Model _model;
        DrawingState _drawingState;
        PointState _pointState;

        // initialize the test
        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
        }

        // reset the _model, _drawingState and _pointState after each test method
        [TestCleanup]
        public void CleanUp()
        {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
        }

        // make sure constructor work
        [TestMethod]
        public void make_sure_constructor_work()
        {
        }

        // get and set MouseIsPressed
        [TestMethod]
        public void get_and_set_mouse_is_pressed()
        {
            _drawingState.MouseIsPressed = true;
            Assert.IsTrue(_drawingState.MouseIsPressed);
            _drawingState.MouseIsPressed = false;
            Assert.IsFalse(_drawingState.MouseIsPressed);
        }

        // get and set shape name
        [TestMethod]
        public void get_and_set_shape_name()
        {
            _drawingState.ShapeName = "Circle";
            Assert.AreEqual("Circle", _drawingState.ShapeName);
        }

        // draw single shape by using mouse
        [TestMethod]
        public void draw_single_shape_by_using_mouse()
        {
            PointF temp1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF temp2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF startPoint = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            PointF endPoint = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _drawingState.ShapeName = "Circle";
            Assert.AreEqual("Circle", _drawingState.ShapeName);

            _drawingState.MousePress(startPoint);
            Assert.IsTrue(_drawingState.MouseIsPressed);

            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            Assert.IsTrue(_drawingState.MouseIsPressed);

            _drawingState.MouseRelease(endPoint);
            Assert.IsFalse(_drawingState.MouseIsPressed);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual(startPoint, shapes[0].GetPoint1());
            Assert.AreEqual(endPoint, shapes[0].GetPoint2());
        }

        // draw many shapes by using mouse
        [TestMethod]
        public void draw_many_shapes_by_using_mouse()
        {
            PointF temp1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF temp2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF startPoint = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            PointF endPoint = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _drawingState.ShapeName = "Circle";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);

            _drawingState.ShapeName = "Line";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);

            _drawingState.ShapeName = "Rectangle";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);


            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(3, shapes.Count);

            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual(startPoint, shapes[0].GetPoint1());
            Assert.AreEqual(endPoint, shapes[0].GetPoint2());

            Assert.AreEqual("Line", shapes[1].GetShapeName());
            Assert.AreEqual(startPoint, shapes[1].GetPoint1());
            Assert.AreEqual(endPoint, shapes[1].GetPoint2()); 

            Assert.AreEqual("Rectangle", shapes[2].GetShapeName());
            Assert.AreEqual(startPoint, shapes[2].GetPoint1());
            Assert.AreEqual(endPoint, shapes[2].GetPoint2());
        }

        // draw many shapes by using mouse and clear
        [TestMethod]
        public void draw_many_shapes_by_using_mouse_and_clear()
        {
            PointF temp1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF temp2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF startPoint = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            PointF endPoint = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _drawingState.ShapeName = "Circle";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);

            _drawingState.ShapeName = "Line";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);

            _drawingState.ShapeName = "Rectangle";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);


            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(3, shapes.Count);

            _drawingState.Clear();
            Assert.AreEqual(0, shapes.Count);
        }
    
        // draw a shape with mouse unpressed move
        [TestMethod]
        public void draw_a_shape_with_mouse_unpressed_move()
        {
            PointF temp1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF temp2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF startPoint = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            PointF endPoint = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _drawingState.ShapeName = "Circle";
            Assert.AreEqual("Circle", _drawingState.ShapeName);

            _drawingState.MousePress(startPoint);
            Assert.IsTrue(_drawingState.MouseIsPressed);

            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            Assert.IsTrue(_drawingState.MouseIsPressed);

            _drawingState.MouseIsPressed = false;
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            Assert.IsFalse(_drawingState.MouseIsPressed);

            _drawingState.MouseIsPressed = true;
            _drawingState.MouseRelease(endPoint);
            Assert.IsFalse(_drawingState.MouseIsPressed);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual(startPoint, shapes[0].GetPoint1());
            Assert.AreEqual(endPoint, shapes[0].GetPoint2());
        }

        // draw a shape with mouse unpressed release
        [TestMethod]
        public void draw_a_shape_with_mouse_unpressed_release()
        {
            PointF temp1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF temp2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF startPoint = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            PointF endPoint = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _drawingState.ShapeName = "Circle";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseIsPressed = false;
            _drawingState.MouseRelease(endPoint);

            _drawingState.ShapeName = "Line";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);

            _drawingState.ShapeName = "Rectangle";
            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseIsPressed = false;
            _drawingState.MouseRelease(endPoint);


            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);

            Assert.AreEqual("Line", shapes[0].GetShapeName());
            Assert.AreEqual(startPoint, shapes[0].GetPoint1());
            Assert.AreEqual(endPoint, shapes[0].GetPoint2());
        }

        // draw single shape by using mouse with null name
        [TestMethod]
        public void draw_single_shape_by_using_mouse_with_null_name()
        {
            PointF temp1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF temp2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF startPoint = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            PointF endPoint = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _drawingState.ShapeName = null;

            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);

            _drawingState.ShapeName = "Circle";

            _drawingState.MousePress(startPoint);
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseRelease(endPoint);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual(startPoint, shapes[0].GetPoint1());
            Assert.AreEqual(endPoint, shapes[0].GetPoint2());
        }

        //
    }
}