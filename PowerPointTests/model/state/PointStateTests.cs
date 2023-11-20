//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PowerPoint.model.shape;
//using System;
//using System.ComponentModel;
//using System.Drawing;

//namespace PowerPoint.model.state.test {
//    [TestClass]
//    public class PointStateTests {

//        [TestMethod]
//        public void draw_shape_by_using_mouse()
//        {
//            Model _model = new Model();
//            DrawingState _drawingState = new DrawingState(_model);
//            PointState _pointState = new PointState(_model);
//            _model.SetState(_drawingState, _pointState);

//            _model.Add("Circle", new PointF(0,0), new PointF(200, 200));

//            _pointState.MousePress(new PointF(100, 100));
//            Assert.AreEqual(0, _pointState.GetTargetIndex());
//        }
//    }
//}