using PowerPoint.model;
using PowerPoint.model.shape;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.presentation_model
{
    public class FormPresentationModel
    {
        private Model _model;

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
            _model.Draw(new FormGraphicsAdaptor(graphics));
        }

        // copy the panel to slide
        public void CopyPanelToSlide(DoubleBufferedPanel panel, System.Windows.Forms.Button slide)
        {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));
            Graphics graphics = slide.CreateGraphics();
            graphics.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, slide.Width, slide.Height));
        }

        // line button click
        public void ClickLineButton()
        {
            _lineButtonChecked = !_lineButtonChecked;
            if (_lineButtonChecked)
            {
                _model.SetShapeName(LINE);
                _rectangleButtonChecked = _circleButtonChecked = _mouseButtonChecked = false;
            }
            else
            {
                _model.SetShapeName(null);
                _mouseButtonChecked = true;
            }
        }

        // rectangle button click
        public void ClickRectangleButton()
        {
            _rectangleButtonChecked = !_rectangleButtonChecked;
            if (_rectangleButtonChecked)
            {
                _model.SetShapeName(RECTANGLE);
                _lineButtonChecked = _circleButtonChecked = _mouseButtonChecked = false;
            }
            else
            {
                _model.SetShapeName(null);
                _mouseButtonChecked = true;
            }
        }

        // circle button click
        public void ClickCircleButton()
        {
            _circleButtonChecked = !_circleButtonChecked;
            if (_circleButtonChecked)
            {
                _model.SetShapeName(CIRCLE);
                _lineButtonChecked = _rectangleButtonChecked = _mouseButtonChecked = false;
            }
            else
            {
                _model.SetShapeName(null);
                _mouseButtonChecked = true;
            }
        }

        // click buutton mouse
        public void ClickMouseButton()
        {
            _mouseButtonChecked = !_mouseButtonChecked;
            if (_mouseButtonChecked)
            {
                //_selectedShape = null;
                _model.SetShapeName(null);
                _lineButtonChecked = _rectangleButtonChecked = _circleButtonChecked = false;
            }
        }

        // press the mouse
        public void PressPointer(float pointX, float pointY)
        {
            _model.MousePress(new PointF(pointX, pointY));
        }

        // move the mouse
        public void MovePointer(float pointX, float pointY)
        {
            _model.MouseMove(new PointF(pointX, pointY));
        }

        // release the mouse
        public void ReleasePointer(PointF point)
        {
            _model.MouseRelease(point);
            _lineButtonChecked = _rectangleButtonChecked = _circleButtonChecked = false;
            _mouseButtonChecked = true;
        }

        // clear all the shape
        public void Clear()
        {
            _model.Clear();
        }
    }
}
