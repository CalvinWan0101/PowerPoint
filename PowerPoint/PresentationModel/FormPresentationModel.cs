using PowerPoint.Properties;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;

namespace PowerPoint.model
{
    public class FormPresentationModel
    {
        private Model _model;
        private Factory _factory;
        private PointF _firstPoint;
        private bool _isPressed = false;
        private Shape _hint;

        // button checked
        private bool _lineButtonChecked = false;
        private bool _rectangleButtonChecked = false;
        private bool _circleButtonChecked = false;
        private bool _mouseButtonChecked = true;

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";

        public FormPresentationModel(Model model, Control canvas)
        {
            this._model = model;
            _factory = new Factory();
        }

        // line button checked
        public bool IsLineButtonChecked()
        {
            return _lineButtonChecked;
        }

        // rectangle button checked
        public bool IsRectangleButtonChecked()
        {
            return _rectangleButtonChecked;
        }

        // circle button checked
        public bool IsCircleButtonChecked()
        {
            return _circleButtonChecked;
        }

        // mouse button checked
        public bool IsMouseButtonChecked()
        {
            return _mouseButtonChecked;
        }

        // draw all the shape
        public void Draw(Graphics graphics)
        {
            _model.Draw(new FormGraphicsAdaptor(graphics), _isPressed, _hint);
        }

        // copy the panel to slide
        public void CopyPanelToSlide(DoubleBufferedPanel panel, System.Windows.Forms.Button slide)
        {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));
            Graphics graphics = slide.CreateGraphics();
            graphics.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, slide.Width, slide.Height));
        }

        private string _selectedShape;

        // line button click
        public void ClickLineButton()
        {
            _lineButtonChecked = !_lineButtonChecked;
            if (_lineButtonChecked)
            {
                _selectedShape = LINE;
                _rectangleButtonChecked = false;
                _circleButtonChecked = false;
                _mouseButtonChecked = false;
            }
            else
            {
                _selectedShape = null;
                _mouseButtonChecked = true;
            }
        }

        // rectangle button click
        public void ClickRectangleButton()
        {
            _rectangleButtonChecked = !_rectangleButtonChecked;
            if (_rectangleButtonChecked)
            {
                _selectedShape = RECTANGLE;
                _lineButtonChecked = false;
                _circleButtonChecked = false;
                _mouseButtonChecked = false;
            }
            else
            {
                _selectedShape = null;
                _mouseButtonChecked = true;
            }
        }

        // circle button click
        public void ClickCircleButton()
        {
            _circleButtonChecked = !_circleButtonChecked;
            if (_circleButtonChecked)
            {
                _selectedShape = CIRCLE;
                _lineButtonChecked = false;
                _rectangleButtonChecked = false;
                _mouseButtonChecked = false;
            }
            else
            {
                _selectedShape = null;
                _mouseButtonChecked = true;
            }

        }

        // click buutton mouse
        public void ClickMouseButton()
        {
            _mouseButtonChecked = !_mouseButtonChecked;
            if (_mouseButtonChecked)
            {
                _selectedShape = null;
                _lineButtonChecked = false;
                _rectangleButtonChecked = false;
                _circleButtonChecked = false;
            }
        }

        // press the mouse
        public void PressPointer(float pointX, float pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _firstPoint = new PointF(pointX, pointY);
                _isPressed = true;
            }
        }

        // move the mouse
        public void MovePointer(float pointX, float pointY)
        {
            if (_isPressed)
            {
                _hint = _factory.CreateShape(_selectedShape, _firstPoint, new PointF(pointX, pointY));
                _model.NotifyModelChanged();
            }
        }

        // release the mouse
        public void ReleasePointer(PointF point)
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (_selectedShape != null)
                {
                    _lineButtonChecked = _rectangleButtonChecked = _circleButtonChecked = false;
                    _mouseButtonChecked = true;
                    _model.Add(_factory.CreateShape(_selectedShape, _firstPoint, point));
                    _selectedShape = null;
                    _model.NotifyModelChanged();
                }
            }
        }

        // clear all the shape
        public void Clear()
        {
            _isPressed = false;
            _model.Clear();
        }
    }
}
