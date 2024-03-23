using System.Drawing;

namespace PowerPoint.model.state {
    public interface IState {
        void MousePress(PointF point);

        void MouseMove(PointF point);

        void MouseRelease(PointF point);
    }
}