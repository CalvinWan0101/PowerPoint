using PowerPoint.model.command;
using PowerPoint.model.shape;
using PowerPoint.model.state;
using PowerPoint.presentation_model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();


        private Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        private Shapes _shapes;
        private IState _state;
        private DrawingState _drawingState;
        private PointState _pointState;
        private CommandManager _commandManager;

        private bool _mouseButtonChecked = true;

        public Model()
        {
            _shapes = new Shapes();
            _drawingState = new DrawingState(this);
            _pointState = new PointState(this);
            _commandManager = new CommandManager(this);
            _state = _drawingState;
            _mouseButtonChecked = false;
        }

        // mouse button checked
        public bool MouseButtonChecked
        {
            get 
            {
                return _mouseButtonChecked;
            }
            set 
            {
                _mouseButtonChecked = value;
                if (_mouseButtonChecked)
                {
                    _state = _pointState;
                }
                else
                {
                    _state = _drawingState;
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
            //_shapes.Add(shapeName, position);
            //NotifyModelChanged();
            _commandManager.ExecuteCommand(new AddCommand(this, shapeName, position));
        }

        // this function is to add the Shape into Shapes (with random number)
        public void Add(string shapeName)
        {
            PointF point1 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF point2 = new PointF(_random.Next(X_MAX), _random.Next(Y_MAX));
            PointF[] position = new PointF[] { point1, point2 };
            //_shapes.Add(shapeName, position);
            //NotifyModelChanged();

            _commandManager.ExecuteCommand(new AddCommand(this, shapeName, position));
        }

        // this function is to remove the Shape into Shapes
        public void Remove(int targetIndex)
        {
            //_shapes.Remove(targetIndex);
            //NotifyModelChanged();
            _commandManager.ExecuteCommand(new DeleteCommand(this, targetIndex));
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
            _state.MousePress(point);
        }

        // mouse move
        public virtual void MouseMove(PointF point)
        {
            _state.MouseMove(point);
        }

        // mouse release
        public virtual void MouseRelease(PointF point)
        {
            _state.MouseRelease(point);
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

        // undo
        public void Undo()
        {
            _commandManager.UndoCommand();
        }

        // redo
        public void Redo()
        {
            _commandManager.RedoCommand();
        }

        // move command
        public void MoveCommand(int targetIndex, PointF point1, PointF point2)
        {
            _commandManager.ExecuteCommand(new MoveCommand(this, targetIndex, point1, point2));
        }

    }
}
