using System.ComponentModel;
using System.Drawing;
using PowerPoint.model.shape;

namespace PowerPoint.model {
    public class Shapes {
        private BindingList<Shape> _shapes;
        private Shape _hint;

        public Shapes() {
            _shapes = new BindingList<Shape>();
        }

        public void Add(string shapeName, PointF pointA, PointF pointB) {
            Shape shape = Factory.CreateShape(shapeName, pointA, pointB);
            _shapes.Add(shape);
        }

        public void Add(string shapeName) {
            Shape shape = Factory.CreateShape(shapeName);
            _shapes.Add(shape);
        }

        public void Add(Shape shape) {
            _shapes.Add(shape);
        }

        public Shape GetShapeByIndex(int index) {
            if (index != -1) {
                return _shapes[index];
            }
            else {
                return null;
            }
        }

        public void SetHint(string shapeName, PointF firstPoint, PointF secondPoint) {
            _hint = Factory.CreateShape(shapeName, firstPoint, secondPoint);
        }

        public int GetLength() {
            return _shapes.Count;
        }

        public Shape GetHint() {
            return _hint;
        }

        public void AddHint() {
            _shapes.Add(_hint);
        }

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

        public void Clear() {
            _shapes.Clear();
        }

        public BindingList<Shape> GetListOfShape() {
            return _shapes;
        }
    }
}