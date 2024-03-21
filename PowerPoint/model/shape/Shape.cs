using System;
using System.ComponentModel;
using System.Drawing;
using PowerPoint.presentation_model;

namespace PowerPoint.model.shape {
    public abstract class Shape : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        // notify property change
        protected virtual void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected string _id = Guid.NewGuid().ToString();
        protected PointF _point1;
        protected PointF _point2;
        private string _name;
        private string _information;

        public string Id {
            get { return _id; }
        }

        public PointF Point1 {
            get { return _point1; }
            set { _point1 = value; }
        }

        public PointF Point2 {
            get { return _point2; }
            set { _point2 = value; }
        }

        public string Name {
            get { return _name; }
            set {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string Information {
            get { return _information; }
            set {
                _information = value;
                NotifyPropertyChanged(nameof(Information));
            }
        }

        // adjust point
        public virtual void AdjustPoint(float ratio) {
            Point1 = new PointF(Point1.X * ratio, Point1.Y * ratio);
            Point2 = new PointF(Point2.X * ratio, Point2.Y * ratio);
        }

        // make sure the point
        public abstract void UpdatePoint();

        // function to check if the shape contains the point
        public bool Contains(PointF point) {
            return Point1.X <= point.X && point.X <= Point2.X && Point1.Y <= point.Y && point.Y <= Point2.Y;
        }

        // function to move the shape
        public abstract void Move(PointF firstPoint, PointF secondPoint);

        // function to zoom the shape
        public abstract void Zoom(PointF secondPoint);

        // function to draw the shape
        public abstract void Draw(IGraphics graphics);

        // function to draw the selected shape
        public abstract void DrawSelected(IGraphics graphics);
    }
}