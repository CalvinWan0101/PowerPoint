using PowerPoint.presentation_model;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.model.shape
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected string _name
        {
            get;
            set;
        }

        public string _chineseName
        {
            get;
            protected set;
        }

        public string _information
        {
            get;
            protected set;
        }

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

        // function to draw the shape
        public abstract void Draw(IGraphics graphics);

        // function to draw the selected shape
        public abstract void DrawSelected(IGraphics graphics);
    }
}
