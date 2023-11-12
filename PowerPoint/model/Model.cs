using PowerPoint.model.shape;
using PowerPoint.model.state;
using PowerPoint.presentation_model;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private Shapes _shapes;
        private DrawingState _drawingState;
        private PointState _pointState;

        public Model()
        {
            _shapes = new Shapes();
            _drawingState = new DrawingState(this);
            _pointState = new PointState(this);
        }

        // this function is to add the Shape into Shapes (with concrete number)
        public void Add(string shapeName, params PointF[] position)
        {
            _shapes.Add(shapeName, position);
            NotifyModelChanged();
        }

        // this function is to add the Shape into Shapes (with random number)
        public void Add(string shapeName)
        {
            _shapes.Add(shapeName);
            NotifyModelChanged();
        }

        // this function is to remove the Shape into Shapes
        public void Remove(int targetIndex)
        {
            _shapes.Remove(targetIndex);
            NotifyModelChanged();
        }

        // clear all the shape
        public void Clear()
        {
            _drawingState.Clear();
        }

        // set shape name
        public void SetShapeName(string shapeName)
        {
            _drawingState.SetShapeName(shapeName);
        }

        // mouse press
        public void MousePress(PointF point)
        {
            _drawingState.MousePress(point);
        }

        // mouse move
        public void MouseMove(PointF point)
        {
            _drawingState.MouseMove(point);
        }

        // mouse release
        public void MouseRelease(PointF point)
        {
            _drawingState.MouseRelease(point);
        }

        // get list of shape
        public BindingList<Shape> GetListOfShape()
        {
            return _shapes.GetListOfShape();
        }

        // get shapes
        public Shapes GetShapes()
        {
            return _shapes;
        }

        // draw all the shape
        public void Draw(IGraphics graphics)
        {
            _drawingState.Draw(graphics);
        }

        // notify model changed
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
