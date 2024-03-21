using System.Drawing;

namespace PowerPoint.model.state {
    public interface IState {
        // mouse press
        void MousePress(PointF point);

        // mouse move
        void MouseMove(PointF point);

        // mouse release
        void MouseRelease(PointF point);
    }
}