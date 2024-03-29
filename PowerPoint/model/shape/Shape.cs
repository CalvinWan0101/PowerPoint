using System;
using System.ComponentModel;
using System.Drawing;
using PowerPoint.presentation_model;

namespace PowerPoint.model.shape {
    public abstract class Shape : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected string _id = Guid.NewGuid().ToString();
        protected PointF _point1;
        protected PointF _point2;
        private string _name;

        public Shape(PointF point1, PointF point2, string name) {
            _point1 = point1;
            _point2 = point2;
            _name = name;
            UpdatePoint();
        }

        public Shape() {
        }

        public string Id {
            get { return _id; }
        }

        public PointF Point1 {
            get { return _point1; }
            set {
                _point1 = value;
                NotifyPropertyChanged(nameof(Information));
            }
        }

        public PointF Point2 {
            get { return _point2; }
            set {
                _point2 = value;
                NotifyPropertyChanged(nameof(Information));
            }
        }

        public string Name {
            get { return _name; }
            set {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public virtual string Information {
            get {
                return string.Format("({0:D3}, {1:D3})", (int)Point1.X, (int)Point1.Y) + ", " +
                       string.Format("({0:D3}, {1:D3})", (int)Point2.X, (int)Point2.Y);
            }
        }

        public virtual void AdjustPoint(float ratio) {
            Point1 = new PointF(Point1.X * ratio, Point1.Y * ratio);
            Point2 = new PointF(Point2.X * ratio, Point2.Y * ratio);
        }

        public virtual void UpdatePoint() {
            PointF temp1 = Point1;
            PointF temp2 = Point2;

            Point1 = new PointF(Math.Min(temp1.X, temp2.X), Math.Min(temp1.Y, temp2.Y));
            Point2 = new PointF(Math.Max(temp1.X, temp2.X), Math.Max(temp1.Y, temp2.Y));
        }

        public bool Contains(PointF point) {
            return Point1.X <= point.X && point.X <= Point2.X && Point1.Y <= point.Y && point.Y <= Point2.Y;
        }

        public abstract void Move(PointF firstPoint, PointF secondPoint);

        public abstract void Zoom(PointF secondPoint);

        public abstract void Draw(IGraphics graphics);

        public abstract void DrawSelected(IGraphics graphics);
    }
}