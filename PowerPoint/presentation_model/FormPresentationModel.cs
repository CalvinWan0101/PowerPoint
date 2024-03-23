using System.Drawing;
using PowerPoint.model;
using PowerPoint.model.shape;
using Rectangle = PowerPoint.model.shape.Rectangle;

namespace PowerPoint.presentation_model {
    public class FormPresentationModel {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler();

        private Model _model;

        public FormPresentationModel(Model model) {
            _model = model;
        }

        public void NotifyPropertyChanged() {
            if (PropertyChanged != null) {
                PropertyChanged();
            }
        }

        private bool _lineButtonChecked = false;
        private bool _rectangleButtonChecked = false;
        private bool _circleButtonChecked = false;
        private bool _mouseButtonChecked = true;

        public bool LineButtonChecked {
            get { return _lineButtonChecked; }
            set {
                _lineButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool RectangleButtonChecked {
            get { return _rectangleButtonChecked; }
            set {
                _rectangleButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool CircleButtonChecked {
            get { return _circleButtonChecked; }
            set {
                _circleButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool MouseButtonChecked {
            get { return _mouseButtonChecked; }
            set {
                _mouseButtonChecked = value;
                _model.MouseButtonChecked = value;
                NotifyPropertyChanged();
            }
        }

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

        public void Draw(Graphics graphics) {
            _model.Draw(new FormGraphicsAdaptor(graphics), _model.SlideIndex);
        }

        public void PreviewDraw(Graphics graphics, int slideIndex) {
            _model.Draw(new PreviewGraphicsAdaptor(graphics, PreviewDrawRatio), slideIndex);
        }

        public void ClickLineButton() {
            LineButtonChecked = !LineButtonChecked;

            if (LineButtonChecked) {
                _model.SetShapeName(Line.NAME);
                RectangleButtonChecked = CircleButtonChecked = MouseButtonChecked = false;
            }
            else {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        public void ClickRectangleButton() {
            RectangleButtonChecked = !RectangleButtonChecked;
            if (RectangleButtonChecked) {
                _model.SetShapeName(Rectangle.NAME);
                LineButtonChecked = CircleButtonChecked = MouseButtonChecked = false;
            }
            else {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        public void ClickCircleButton() {
            CircleButtonChecked = !CircleButtonChecked;
            if (_circleButtonChecked) {
                _model.SetShapeName(Circle.NAME);
                LineButtonChecked = RectangleButtonChecked = MouseButtonChecked = false;
            }
            else {
                _model.SetShapeName(null);
                MouseButtonChecked = true;
            }
        }

        public void ClickMouseButton() {
            MouseButtonChecked = !MouseButtonChecked;
            if (MouseButtonChecked) {
                _model.SetShapeName(null);
                LineButtonChecked = RectangleButtonChecked = CircleButtonChecked = false;
            }
        }

        public void MousePress(PointF point) {
            _model.MousePress(point);
        }

        public void MouseMove(PointF point) {
            _model.MouseMove(point);
        }

        public void MouseRelease(PointF point) {
            _model.MouseRelease(point);
            LineButtonChecked = RectangleButtonChecked = CircleButtonChecked = false;
            MouseButtonChecked = true;
        }

        public void Clear() {
            _model.Clear();
        }

        private int _width = -1;
        private int _height = -1;
    }
}