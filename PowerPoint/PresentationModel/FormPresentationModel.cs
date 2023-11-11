using PowerPoint.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.model
{
    public class FormPresentationModel
    {
        private Model _model;
        private Factory _factory;
        private PointF _firstPoint;
        private bool _isPressed = false;
        private Shape _hint;

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";

        public FormPresentationModel(Model model, Control canvas)
        {
            this._model = model;
            _factory = new Factory();
        }

        // draw all the shape
        public void Draw(Graphics graphics)
        {
            _model.Draw(new FormGraphicsAdaptor(graphics), _isPressed, _hint);
        }

        private string _selectedShape;

        // line button click
        public void ClickLineButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton, ref ToolStripButton mouseButton)
        {
            lineButton.Checked = !lineButton.Checked;
            if (lineButton.Checked)
            {
                _selectedShape = LINE;
                rectangleButton.Checked = false;
                circleButton.Checked = false;
                mouseButton.Checked = false;
            }
            else
            {
                _selectedShape = null;
                mouseButton.Checked = true;
            }
        }

        // rectangle button click
        public void ClickRectangleButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton, ref ToolStripButton mouseButton)
        {
            rectangleButton.Checked = !rectangleButton.Checked;
            if (rectangleButton.Checked)
            {
                _selectedShape = RECTANGLE;
                lineButton.Checked = false;
                circleButton.Checked = false;
                mouseButton.Checked = false;
            }
            else
            {
                _selectedShape = null;
                mouseButton.Checked = true;
            }
        }

        // circle button click
        public void ClickCircleButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton, ref ToolStripButton mouseButton)
        {
            circleButton.Checked = !circleButton.Checked;
            if (circleButton.Checked)
            {
                _selectedShape = CIRCLE;
                lineButton.Checked = false;
                rectangleButton.Checked = false;
                mouseButton.Checked = false;

            }
            else
            {
                _selectedShape = null;
                mouseButton.Checked = true;
            }
        }

        // click buutton mouse
        public void ClickMouseButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton, ref ToolStripButton mouseButton)
        {
            mouseButton.Checked = !mouseButton.Checked;
            if (mouseButton.Checked)
            {
                _selectedShape = null;
                lineButton.Checked = false;
                rectangleButton.Checked = false;
                circleButton.Checked = false;
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
        public void ReleasePointer(PointF point, ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton, ref ToolStripButton mouseButton)
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (_selectedShape != null)
                {
                    lineButton.Checked = rectangleButton.Checked = circleButton.Checked = false;
                    mouseButton.Checked = true;
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
