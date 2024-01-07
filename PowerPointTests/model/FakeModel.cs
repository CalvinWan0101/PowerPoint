using PowerPoint.model;
using PowerPoint.presentation_model;
using System.Drawing;

namespace PowerPointTests.model
{
    public class FakeModel : Model
    {
        string _shapeName;
        int _drawUsed;
        int _setShapeNameUsed;
        int _mousePressUsed;
        int _mouseMoveUsed;
        int _mouseReleaseUsed;
        int _clearUsed;

        public string ShapeName
        {
            get
            {
                return _shapeName;
            }
            set
            {
                _shapeName = value;
            }
        }

        public int DrawUsed
        {
            get
            {
                return _drawUsed;
            }
            set
            {
                _drawUsed = value;
            }
        }

        public int SetShapeNameUsed
        {
            get
            {
                return _setShapeNameUsed;
            }
            set
            {
                _setShapeNameUsed = value;
            }
        }

        public int MousePressUsed
        {
            get
            {
                return _mousePressUsed;
            }
            set
            {
                _mousePressUsed = value;
            }
        }

        public int MouseMoveUsed
        {
            get
            {
                return _mouseMoveUsed;
            }
            set
            {
                _mouseMoveUsed = value;
            }
        }

        public int MouseReleaseUsed
        {
            get
            {
                return _mouseReleaseUsed;
            }
            set
            {
                _mouseReleaseUsed = value;
            }
        }

        public int ClearUsed
        {
            get
            {
                return _clearUsed;
            }
            set
            {
                _clearUsed = value;
            }
        }

        public FakeModel()
        {
            _drawUsed = 0;
            _setShapeNameUsed = 0;
            _mousePressUsed = 0;
            _mouseMoveUsed = 0;
            _mouseReleaseUsed = 0;
            _clearUsed = 0;
        }

        // draw all the shape
        public override void Draw(IGraphics graphics, int slideIndex)
        {
            DrawUsed++;
        }

        // set shape name
        public override void SetShapeName(string shapeName)
        {
            SetShapeNameUsed++;
            ShapeName = shapeName;
        }

        // mouse press
        public override void MousePress(PointF point)
        {
            MousePressUsed++;
        }

        // mouse move
        public override void MouseMove(PointF point)
        {
            MouseMoveUsed++;
        }

        // mouse release
        public override void MouseRelease(PointF point)
        {
            MouseReleaseUsed++;
        }

        // clear all the shape
        public override void Clear()
        {
            ClearUsed++;
        }
    }
}
