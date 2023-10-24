using PowerPoint.Properties;
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
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new FormGraphicsAdaptor(graphics), _isPressed, _hint);
        }

        private string _selectedShape;

        // line button click
        public void ClickLineButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton)
        {
            lineButton.Checked = !lineButton.Checked;
            if (lineButton.Checked)
            {
                _selectedShape = LINE;
                rectangleButton.Checked = false;
                circleButton.Checked = false;
            }
            else
            {
                _selectedShape = null;
            }
        }

        // rectangle button click
        public void ClickRectangleButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton)
        {
            rectangleButton.Checked = !rectangleButton.Checked;
            if (rectangleButton.Checked)
            {
                _selectedShape = RECTANGLE;
                lineButton.Checked = false;
                circleButton.Checked = false;
            }
            else
            {
                _selectedShape = null;
            }
        }

        // circle button click
        public void ClickCircleButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton)
        {
            circleButton.Checked = !circleButton.Checked;
            if (circleButton.Checked)
            {
                _selectedShape = CIRCLE;
                lineButton.Checked = false;
                rectangleButton.Checked = false;
            }
            else
            {
                _selectedShape = null;
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
        public Shape ReleasePointer(float pointX, float pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (_hint != null)
                {
                    _hint = _factory.CreateShape(_selectedShape, _firstPoint, new PointF(pointX, pointY));
                    _model.Add(_hint);
                    _model.NotifyModelChanged();
                }
                return _hint;
            }
            return null;
        }

        // clear all the shape
        public void Clear()
        {
            _isPressed = false;
            _model.Clear();
        }
    }
}
