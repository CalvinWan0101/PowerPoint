namespace PowerPoint.model.state
{
    public interface IState
    {
        // this function is to handle mouse pressed
        void MouseDown();

        // this function is to handle mouse released
        void MouseMove();
    }
}
