using PowerPoint.model;
using PowerPoint.model.shape;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.presentation_model
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        private Model _model;
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // button checked
        private bool _lineButtonChecked = false;
        private bool _rectangleButtonChecked = false;
        private bool _circleButtonChecked = false;
        private bool _mouseButtonChecked = true;


        // the getter and setter of line button checked
        public bool LineButtonChecked
        {
            get { return _lineButtonChecked; }
            set
            {
                _lineButtonChecked = value;
                if (PropertyChanged != null)
                {
                    NotifyPropertyChanged("LineButtonChecked");
                }
            }
        }

        // the getter and setter of rectangle button checked
        public bool RectangleButtonChecked
        {
            get { return _rectangleButtonChecked; }
            set
            {
                _rectangleButtonChecked = value;
                if (PropertyChanged != null)
                {
                    NotifyPropertyChanged("RectangleButtonChecked");
                }
            }
        }

        // the getter and setter of circle button checked
        public bool CircleButtonChecked
        {
            get { return _circleButtonChecked; }
            set
            {
                _circleButtonChecked = value;
                if (PropertyChanged != null)
                {
                    NotifyPropertyChanged("CircleButtonChecked");
                }
            }
        }

        // the getter and setter of mouse button checked
        public bool MouseButtonChecked
        {
            get { return _mouseButtonChecked; }
            set
            {
                _mouseButtonChecked = value;
                if (PropertyChanged != null)
                {
                    NotifyPropertyChanged("MouseButtonChecked");
                }
            }
        }

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";

        public FormPresentationModel(Model model, Control canvas)
        {
            _model = model;
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
        public void CopyPanelToSlide(DoubleBufferedPanel panel, Button slide)
        {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));
            Graphics graphics = slide.CreateGraphics();
            graphics.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, slide.Width, slide.Height));
        }

        // line button click
        public void ClickLineButton()
        {
            LineButtonChecked = !LineButtonChecked;

            if (LineButtonChecked)
            {
                _model.SetShapeName(LINE);
                RectangleButtonChecked = CircleButtonChecked = MouseButtonChecked = false;
            }
            else
            {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        // rectangle button click
        public void ClickRectangleButton()
        {
            RectangleButtonChecked = !RectangleButtonChecked;
            if (RectangleButtonChecked)
            {
                _model.SetShapeName(RECTANGLE);
                LineButtonChecked = CircleButtonChecked = MouseButtonChecked = false;
            }
            else
            {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        // circle button click
        public void ClickCircleButton()
        {
            CircleButtonChecked = !CircleButtonChecked;
            if (_circleButtonChecked)
            {
                _model.SetShapeName(CIRCLE);
                LineButtonChecked = RectangleButtonChecked = MouseButtonChecked = false;
            }
            else
            {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        // click buutton mouse
        public void ClickMouseButton()
        {
            MouseButtonChecked = !MouseButtonChecked;
            if (MouseButtonChecked)
            {
                _model.SetShapeName(null);
                LineButtonChecked = RectangleButtonChecked = CircleButtonChecked = false;
            }
        }

        // press the mouse
        public void MousePress(float pointX, float pointY)
        {
            _model.MousePress(MouseButtonChecked, new PointF(pointX, pointY));
        }

        // move the mouse
        public void MouseMove(float pointX, float pointY)
        {
            _model.MouseMove(MouseButtonChecked, new PointF(pointX, pointY));
        }

        // release the mouse
        public void MouseRelease(PointF point)
        {
            _model.MouseRelease(MouseButtonChecked, point);
            LineButtonChecked = RectangleButtonChecked = CircleButtonChecked = false;
            MouseButtonChecked = true;
        }

        // clear all the shape
        public void Clear()
        {
            _model.Clear();
        }
    }
}
