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

        // for the test
        public void SetState(DrawingState drawingState, PointState pointState)
        {
            _drawingState = drawingState;
            _pointState = pointState;
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
        public void MousePress(bool mouseButtonChecked, PointF point)
        {
            if (mouseButtonChecked)
            {
                _pointState.MousePress(point);

            } else
            {
                _drawingState.MousePress(point);
            }
        }

        // mouse move
        public void MouseMove(bool mouseButtonChecked, PointF point)
        {
            if (mouseButtonChecked)
            {
                _pointState.MouseMove(point);
            } else
            {
                _drawingState.MouseMove(point);
            }
        }

        // mouse release
        public void MouseRelease(bool mouseButtonChecked, PointF point)
        {
            if (mouseButtonChecked)
            {
                _pointState.MouseRelease(point);
                if (FindTargetIndex(point) == -1)
                {
                    NotifyModelChanged();
                }
            } else
            {
                _drawingState.MouseRelease(point);
            }
        }

        // find target index
        public int FindTargetIndex(PointF point)
        {
            for (int i = GetListOfShape().Count - 1; i >= 0; i--)
            {
                if (GetListOfShape()[i].Contains(point))
                {
                    return i;
                }
            }
            return -1;
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
            graphics.ClearAll();
            for (int i = 0; i < GetListOfShape().Count; i++)
            {
                if (i == _pointState.GetTargetIndex())
                {
                    GetListOfShape()[i].DrawSelected(graphics);
                } else
                {
                    GetListOfShape()[i].Draw(graphics);
                }
            }

            if (_drawingState.MouseIsPressed && GetShapes().GetHint() != null)
                GetShapes().GetHint().Draw(graphics);
        }

        // notify model changed
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // press delete key
        public void PressDeleteKey()
        {
            _pointState.ClickDeleteButton();
        }
    }
}
