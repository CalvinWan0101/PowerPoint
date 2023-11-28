using PowerPoint.model.shape;
using PowerPoint.model.state;
using PowerPoint.presentation_model;
using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private Shapes _shapes;
        private IState _istate;
        private DrawingState _drawingState;
        private PointState _pointState;

        private bool _mouseButtonChecked = true;

        public Model()
        {
            _shapes = new Shapes();
            _drawingState = new DrawingState(this);
            _pointState = new PointState(this);
            _istate = _drawingState;
            _mouseButtonChecked = false;
        }

        // mouse button checked
        public bool MouseButtonChecked
        {
            get => _mouseButtonChecked;
            set 
            {
                _mouseButtonChecked = value;
                if (_mouseButtonChecked)
                {
                    _istate = _pointState;
                }
                else
                {
                    _istate = _drawingState;
                }
            } 
        }

        // for the test
        public bool IsClickTheRightBottomCorner(PointF point)
        {
            return _pointState.IsClickTheRightBottomCorner(point);
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
        public virtual void Clear()
        {
            _shapes.Clear();
            NotifyModelChanged();
        }

        // set shape name
        public virtual void SetShapeName(string shapeName)
        {
            _drawingState.ShapeName = shapeName;
        }

        // mouse press
        public virtual void MousePress(PointF point)
        {
            _istate.MousePress(point);
        }

        // mouse move
        public virtual void MouseMove(PointF point)
        {
            _istate.MouseMove(point);
        }

        // mouse release
        public virtual void MouseRelease(PointF point)
        {
            _istate.MouseRelease(point);
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
        public virtual void Draw(IGraphics graphics)
        {
            Console.WriteLine("In the real model.");

            graphics.ClearAll();
            for (int i = 0; i < GetListOfShape().Count; i++)
            {
                if (i == _pointState.TargetIndex)
                {
                    GetListOfShape()[i].DrawSelected(graphics);
                }
                else
                {
                    GetListOfShape()[i].Draw(graphics);
                }
            }

            if (_drawingState.IsMousePressed && GetShapes().GetHint() != null)
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
