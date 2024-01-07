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

        public event PropertyChangedEventHandler _redoUndoChanged;
        public delegate void PropertyChangedEventHandler();

        private Random _random = new Random();
        const int X_MAX = 640;
        const int Y_MAX = 360;

        //private Shapes _shapes;
        private List<Shapes> _slides;
        private IState _state;
        private DrawingState _drawingState;
        private PointState _pointState;
        private CommandManager _commandManager;

        private bool _mouseButtonChecked = true;

        public Model()
        {
            //_shapes = new Shapes();
            _slides = new List<Shapes>();
            _slides.Add(new Shapes());
            _drawingState = new DrawingState(this);
            _pointState = new PointState(this);
            _commandManager = new CommandManager(this);
            _state = _drawingState;
            _mouseButtonChecked = false;
            _slideIndex = 0;
        }

        // notify property changed
        public void NotifyRedoUndoChanged()
        {
            if (_redoUndoChanged != null)
            {
                _redoUndoChanged();
            }
        }

        // redo undo button enabled
        private bool _redoButtonEnabled = false;
        private bool _undoButtonEnabled = false;

        // the getter and setter of redo button enabled
        public bool RedoButtonEnabled
        {
            get
            {
                return _redoButtonEnabled;
            }
            set
            {
                _redoButtonEnabled = value;
                NotifyRedoUndoChanged();
            }
        }

        // the getter and setter of undo button enabled
        public bool UndoButtonEnabled
        {
            get
            {
                return _undoButtonEnabled;
            }
            set
            {
                _undoButtonEnabled = value;
                NotifyRedoUndoChanged();
            }
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

        private int _slideIndex = -1;

        public int SlideIndex
        {
            get
            {
                return _slideIndex;
            }
            set
            {
                _slideIndex = value;
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
            //_shapes.Clear();
            _slides[SlideIndex].Clear();
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
            if (TargetIndex != -1)
            {
                _pointState.PointRecord1 = GetShapeByIndex(TargetIndex).Point1;
                _pointState.PointRecord2 = GetShapeByIndex(TargetIndex).Point2;
                if (GetShapeByIndex(TargetIndex) is Line)
                {
                    Line line = (Line)GetShapeByIndex(TargetIndex);
                    _pointState.DrawPointRecord1 = line.DrawPoint1;
                    _pointState.DrawPointRecord2 = line.DrawPoint2;
                }
            }
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

        private int _targetIndex = -1;

        public int TargetIndex
        {
            get
            {
                return _targetIndex;
            }
            set
            {
                _targetIndex = value;
                _pointState.TargetIndex = value;
            }
        }

        // find target index
        public int FindTargetIndex(PointF point)
        {
            for (int i = GetListOfShape().Count - 1; i >= 0; i--)
            {
                if (GetListOfShape()[i].Contains(point))
                {
                    _targetIndex = i;
                    return i;
                }
            }
            _targetIndex = -1;
            return -1;
        }

        // get list of shape
        public BindingList<Shape> GetListOfShape()
        {
            return _slides[SlideIndex].GetListOfShape();
        }

        // get list of shape by index
        public BindingList<Shape> GetListOfShapeByIndex(int index)
        {
            return _slides[index].GetListOfShape();
        }

        // get shapes
        public Shapes GetShapes()
        {
            return _slides[SlideIndex];
        }

        // get shapes
        public Shapes GetShapes(int slideIndex)
        {
            return _slides[slideIndex];
        }

        // remove shapes
        public void RemoveShapes(int target)
        {
            _slides.RemoveAt(target);
        }

        // get last shape
        public Shape GetLastShape()
        {
            return GetShapeByIndex(_slides[SlideIndex].GetLength() - 1);
        }

        // get last shape
        public Shape GetLastShape(int slideIndex)
        {
            return _slides[slideIndex].GetShapeByIndex(_slides[slideIndex].GetLength() - 1);
        }

        // get shape by index
        public Shape GetShapeByIndex(int index)
        {
            return _slides[SlideIndex].GetShapeByIndex(index);
        }

        // get shape by slide and index
        public Shape GetShapeByIndex(int slide, int index)
        {
            return _slides[slide].GetShapeByIndex(index);
        }

        // remove shape by index
        public void RemoveShapeByIndex(int index)
        {
            _slides[SlideIndex].Remove(index);
        }

        // remove shape by slide and index
        public void RemoveShapeByIndex(int silde, int index)
        {
            _slides[silde].Remove(index);
        }

        // remove shape by id
        public void RemoveShapeById(int slideIndex, string id)
        {
            for (int i = 0; i < GetListOfShapeByIndex(slideIndex).Count; i++)
            {
                if (GetShapeByIndex(slideIndex, i).Id == id)
                {
                    RemoveShapeByIndex(slideIndex, i);
                    break;
                }
            }
            NotifyModelChanged();
        }

        // draw all the shape
        public virtual void Draw(IGraphics graphics, int slideIndex)
        {
            graphics.ClearAll();
            for (int i = 0; i < GetListOfShapeByIndex(slideIndex).Count; i++)
            {
                if (i == _pointState.TargetIndex)
                {
                    if (GetListOfShapeByIndex(slideIndex)[i] != null && slideIndex == SlideIndex)
                    {
                        GetListOfShapeByIndex(slideIndex)[i].DrawSelected(graphics);
                    }
                    GetListOfShapeByIndex(slideIndex)[i].Draw(graphics);
                }
                else
                {
                    GetListOfShapeByIndex(slideIndex)[i].Draw(graphics);
                }
            }

            if (_drawingState.IsMousePressed && GetShapes().GetHint() != null && slideIndex == SlideIndex)
            {
                GetShapes().GetHint().Draw(graphics);
            }
        }

        // update all the shape
        public void Update(float ratio)
        {
            foreach (Shape shape in GetListOfShape())
            {
                shape.AdjustPoint(ratio);
            }
            NotifyModelChanged();
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
            _commandManager.ExecuteCommand(new MoveCommand(this, targetIndex, point1, point2, _pointState.PointRecord1, _pointState.PointRecord2, _pointState.DrawPointRecord1, _pointState.DrawPointRecord2));
        }

        // zoom command
        public void ZoomCommand(int targetIndex, PointF endPoint)
        {
            _commandManager.ExecuteCommand(new ZoomCommand(this, targetIndex, endPoint, _pointState.PointRecord1, _pointState.PointRecord2, _pointState.DrawPointRecord1, _pointState.DrawPointRecord2));
        }

        // add slide command
        public void AddSlideCommand()
        {
            _commandManager.ExecuteCommand(new AddSlideCommand(this));
        }

        // add shapes
        public void AddShapes()
        {
            _slides.Add(new Shapes());
        }
    }
}
