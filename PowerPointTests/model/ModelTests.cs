using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model.shape;
using System.ComponentModel;

namespace PowerPoint.model.test {
    [TestClass]
    public class ModelTests {

        [TestMethod]
        public void add_shape_with_only_name() {
            Model _model = new Model();
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");

            BindingList<Shape> shapes = _model.GetListOfShape();
            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual("Line", shapes[1].GetShapeName());
            Assert.AreEqual("Rectangle", shapes[2].GetShapeName());
        }

        [TestMethod]
        public void add_shape_with_name_and_position() {
            Model _model = new Model();
            _model.Add("Circle", new System.Drawing.PointF(100, 200), new System.Drawing.PointF(200, 100));
            _model.Add("Line", new System.Drawing.PointF(100, 100), new System.Drawing.PointF(200, 200));
            _model.Add("Rectangle", new System.Drawing.PointF(200, 10), new System.Drawing.PointF(11, 200));

            BindingList<Shape> shapes = _model.GetListOfShape();
            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual(new System.Drawing.PointF(100, 100), shapes[0].GetPoint1());
            Assert.AreEqual(new System.Drawing.PointF(200, 200), shapes[0].GetPoint2());

            Assert.AreEqual("Line", shapes[1].GetShapeName());
            Assert.AreEqual(new System.Drawing.PointF(100, 100), shapes[1].GetPoint1());
            Assert.AreEqual(new System.Drawing.PointF(200, 200), shapes[1].GetPoint2());

            Assert.AreEqual("Rectangle", shapes[2].GetShapeName());
            Assert.AreEqual(new System.Drawing.PointF(11, 10), shapes[2].GetPoint1());
            Assert.AreEqual(new System.Drawing.PointF(200, 200), shapes[2].GetPoint2());
        }

        [TestMethod]
        public void remove_and_clear_shape() {
            Model _model = new Model();
            _model.Add("Circle");
            _model.Add("Line");
            _model.Add("Rectangle");

            BindingList<Shape> shapes = _model.GetListOfShape();
            Assert.AreEqual(3, shapes.Count);

            _model.Remove(1);
            shapes = _model.GetListOfShape();
            Assert.AreEqual(2, shapes.Count);
            Assert.AreEqual("Circle", shapes[0].GetShapeName());
            Assert.AreEqual("Rectangle", shapes[1].GetShapeName());

            _model.Clear();
            shapes = _model.GetListOfShape();
            Assert.AreEqual(0, shapes.Count);
        }
    }
}