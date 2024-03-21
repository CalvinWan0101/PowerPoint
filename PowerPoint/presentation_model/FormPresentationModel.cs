using System.Drawing;
using PowerPoint.model;

namespace PowerPoint.presentation_model {
    public class FormPresentationModel {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler();

        private Model _model;

        public FormPresentationModel(Model model) {
            _model = model;
        }

        // notify property changed
        public void NotifyPropertyChanged() {
            if (PropertyChanged != null) {
                PropertyChanged();
            }
        }

        // button checked
        private bool _lineButtonChecked = false;
        private bool _rectangleButtonChecked = false;
        private bool _circleButtonChecked = false;
        private bool _mouseButtonChecked = true;

        // the getter and setter of line button checked
        public bool LineButtonChecked {
            get { return _lineButtonChecked; }
            set {
                _lineButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

        // the getter and setter of rectangle button checked
        public bool RectangleButtonChecked {
            get { return _rectangleButtonChecked; }
            set {
                _rectangleButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

        // the getter and setter of circle button checked
        public bool CircleButtonChecked {
            get { return _circleButtonChecked; }
            set {
                _circleButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

        // the getter and setter of mouse button checked
        public bool MouseButtonChecked {
            get { return _mouseButtonChecked; }
            set {
                _mouseButtonChecked = value;
                _model.MouseButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";

        const float FIRST_RATIO = 1.0f;
        const float DRAW_RATIO = 0.25f;

        private float _drawRatio = FIRST_RATIO;
        private float _previewDrawRatio = DRAW_RATIO;

        public float DrawRatio {
            get { return _drawRatio; }
            set {
                _drawRatio = value;
                _model.Update(_drawRatio);
                _model.NotifyModelChanged();
            }
        }

        public float PreviewDrawRatio {
            get { return _previewDrawRatio; }
            set { _previewDrawRatio = value; }
        }

        // draw all the shape
        public void Draw(Graphics graphics) {
            _model.Draw(new FormGraphicsAdaptor(graphics), _model.SlideIndex);
        }

        // preview draw
        public void PreviewDraw(Graphics graphics, int slideIndex) {
            _model.Draw(new PreviewGraphicsAdaptor(graphics, PreviewDrawRatio), slideIndex);
        }

        // line button click
        public void ClickLineButton() {
            LineButtonChecked = !LineButtonChecked;

            if (LineButtonChecked) {
                _model.SetShapeName(LINE);
                RectangleButtonChecked = CircleButtonChecked = MouseButtonChecked = false;
            }
            else {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        // rectangle button click
        public void ClickRectangleButton() {
            RectangleButtonChecked = !RectangleButtonChecked;
            if (RectangleButtonChecked) {
                _model.SetShapeName(RECTANGLE);
                LineButtonChecked = CircleButtonChecked = MouseButtonChecked = false;
            }
            else {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        // circle button click
        public void ClickCircleButton() {
            CircleButtonChecked = !CircleButtonChecked;
            if (_circleButtonChecked) {
                _model.SetShapeName(CIRCLE);
                LineButtonChecked = RectangleButtonChecked = MouseButtonChecked = false;
            }
            else {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        // click buutton mouse
        public void ClickMouseButton() {
            MouseButtonChecked = !MouseButtonChecked;
            if (MouseButtonChecked) {
                _model.SetShapeName(null);
                LineButtonChecked = RectangleButtonChecked = CircleButtonChecked = false;
            }
        }

        // press the mouse
        public void MousePress(PointF point) {
            _model.MousePress(point);
        }

        // move the mouse
        public void MouseMove(PointF point) {
            _model.MouseMove(point);
        }

        // release the mouse
        public void MouseRelease(PointF point) {
            _model.MouseRelease(point);
            LineButtonChecked = RectangleButtonChecked = CircleButtonChecked = false;
            MouseButtonChecked = true;
        }

        // clear all the shape
        public void Clear() {
            _model.Clear();
        }

        private int _width = -1;
        private int _height = -1;

        // auto size of the panel
        //public List<int> AutoSize(int panelWidth, int panelHeight)
        //{
        //}
    }
}