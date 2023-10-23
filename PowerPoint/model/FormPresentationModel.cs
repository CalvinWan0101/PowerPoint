using PowerPoint.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.model
{
    public class FormPresentationModel
    {
        public Model _model;
        private PointF _point1;
        private PointF _point2;
        private bool _isPressed;

        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        public FormPresentationModel(Model model)
        {
            this._model = model;
            _isPressed = false;
        }

        // if mouse being pressed
        public void PointerPressed(float x, float y)
        {
            if (x > 0 && y > 0)
            {
                _point1 = new PointF(x, y);
                _isPressed = true;
            }
        }

        // when mouse move
        public void PointerMoved(float x, float y)
        {
            if (_isPressed)
            {
                _point2 = new PointF(x, y);
            }
        }

        // when mouse release
        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                //Shape hint = new Shape();
                //_lines.Add(hint);
                //NotifyModelChanged();
            }
        }

        // clear
        public void Clear()
        {
            _isPressed = false;
            //_lines.Clear();
        }

        // draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape shape in _model.Shapes())
                shape.Draw(graphics);
            //if (_isPressed)
            //    shape.Draw(graphics);
        }

        // notify
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
