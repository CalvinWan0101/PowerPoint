using PowerPoint.model;
using System.Windows.Forms;

namespace PowerPoint.Properties
{
    public abstract class Shape
    {
        protected string _name;
        protected string _chineseName;

        // function to get the name of the shape
        public abstract string GetShapeName();

        // function to get the chinese name of the shape
        public abstract string GetShapeChineseName();

        // function to get the information of the shape
        public abstract string GetInformation();

        // function to draw the shape
        public abstract void Draw(IGraphics graphics);
    }
}
