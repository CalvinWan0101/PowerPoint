using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model;
using PowerPoint.model.shape;
using PowerPoint.model.state;
using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.presentation_model.test
{
    [TestClass]
    public class FormPresentationModelTests
    {
        private Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        [TestMethod]
        public void draw_shape_by_using_mouse()
        {
            Model _model = new Model();
            DrawingState _drawingState = new DrawingState(_model);
            PointState _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);

            _drawingState.SetShapeName("Circle");
            PointF temp1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF temp2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF startPoint = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            PointF endPoint = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));

            _drawingState.MousePress(startPoint);
            Assert.IsTrue(_drawingState.MouseIsPressed);

            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseIsPressed = false;
            _drawingState.MouseMove(new PointF(_random.Next(X_MAX), _random.Next(Y_MAX)));
            _drawingState.MouseIsPressed = true;

            _drawingState.MouseRelease(endPoint);
            Assert.IsFalse(_drawingState.MouseIsPressed);

            _drawingState.MouseIsPressed = false;
            _drawingState.SetShapeName("Rectangle");
            _drawingState.MouseRelease(endPoint);

            _drawingState.MouseIsPressed = true;
            _drawingState.SetShapeName(null);
            _drawingState.MouseRelease(endPoint);

            Assert.IsFalse(_drawingState.MouseIsPressed);

            BindingList<Shape> shapes = _model.GetListOfShape();

            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual(startPoint, shapes[0].GetPoint1());
            Assert.AreEqual(endPoint, shapes[0].GetPoint2());
        }
    }
}