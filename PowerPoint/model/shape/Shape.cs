using PowerPoint.presentation_model;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model.shape
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // notify property change
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // get point 1
        public abstract PointF GetPoint1();

        // get point 2
        public abstract PointF GetPoint2();

        private string _name;
        private string _chineseName;
        private string _information;

        public string Name
        {
            get 
            { 
                return _name; 
            }
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string ChineseName
        {
            get 
            { 
                return _chineseName; 
            }
            set
            {
                _chineseName = value;
                NotifyPropertyChanged(nameof(ChineseName));
            }
        }

        public string Information
        {
            get 
            { 
                return _information; 
            }
            set
            {
                _information = value;
                NotifyPropertyChanged(nameof(Information));
            }
        }

        // make sure the point
        public abstract void UpdatePoint();

        // function to get the name of the shape
        public abstract string GetShapeName();

        // function to get the chinese name of the shape
        public abstract string GetShapeChineseName();

        // function to get the information of the shape
        public abstract string GetInformation();

        // function to check if the shape contains the point
        public abstract bool Contains(PointF point);

        // function to move the shape
        public abstract void Move(PointF firstPoint, PointF secondPoint);

        // function to zoom the shape
        public abstract void Zoom(PointF firstPoint, PointF secondPoint);

        // function to draw the shape
        public abstract void Draw(IGraphics graphics);

        // function to draw the selected shape
        public abstract void DrawSelected(IGraphics graphics);
    }
}
