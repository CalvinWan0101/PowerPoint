using System.ComponentModel;
using System.Drawing;
using PowerPoint.model.shape;

namespace PowerPoint.model {
    public class Shapes {
        private Factory _factory;
        private BindingList<Shape> _shapes;
        private Shape _hint;

        public Shapes() {
            _factory = new Factory();
            _shapes = new BindingList<Shape>();
        }

        // add a new shape to the end of the list (with concrete number)
        public void Add(string shapeName, PointF pointA, PointF pointB) {
            Shape shape = _factory.CreateShape(shapeName, pointA, pointB);
            _shapes.Add(shape);
        }

        // add a new shape to the end of the list (with random number)
        public void Add(string shapeName) {
            Shape shape = _factory.CreateShape(shapeName);
            _shapes.Add(shape);
        }

        // add a new shape by existing shape
        public void Add(Shape shape) {
            _shapes.Add(shape);
        }

        // get shape by index
        public Shape GetShapeByIndex(int index) {
            if (index != -1) {
                return _shapes[index];
            }
            else {
                return null;
            }
        }

        // update hint
        public void SetHint(string shapeName, PointF firstPoint, PointF secondPoint) {
            _hint = _factory.CreateShape(shapeName, firstPoint, secondPoint);
        }

        // length
        public int GetLength() {
            return _shapes.Count;
        }

        // get hint
        public Shape GetHint() {
            return _hint;
        }

        // add hint into the list
        public void AddHint() {
            _shapes.Add(_hint);
        }

        // remove the shape depend on its index
        public void Remove(int targetIndex) {
            int count = 0;
            foreach (Shape shape in _shapes) {
                if (count == targetIndex) {
                    _shapes.Remove(shape);
                    break;
                }

                count++;
            }
        }

        // clear all the shape
        public void Clear() {
            _shapes.Clear();
        }

        // get shapes
        public BindingList<Shape> GetListOfShape() {
            return _shapes;
        }
    }
}