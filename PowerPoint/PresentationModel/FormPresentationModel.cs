using System.Windows.Forms;

namespace PowerPoint.model
{
    public class FormPresentationModel
    {
        private Model _model;

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";

        public FormPresentationModel(Model model, Control canvas)
        {
            this._model = model;
        }

        // draw all the shape
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new FormGraphicsAdaptor(graphics));
        }

        private string _selectedShape = "";

        // line button click
        public void ClickLineButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton)
        {
            lineButton.Checked = !lineButton.Checked;
            if (lineButton.Checked)
            {
                _selectedShape = LINE;
                rectangleButton.Checked = false;
                circleButton.Checked = false;
            }
        }

        // rectangle button click
        public void ClickRectangleButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton)
        {
            rectangleButton.Checked = !rectangleButton.Checked;
            if (rectangleButton.Checked)
            {
                _selectedShape = RECTANGLE;
                lineButton.Checked = false;
                circleButton.Checked = false;
            }
        }

        // circle button click
        public void ClickCircleButton(ref ToolStripButton lineButton, ref ToolStripButton rectangleButton, ref ToolStripButton circleButton)
        {
            circleButton.Checked = circleButton.Checked;
            if (circleButton.Checked)
            {
                _selectedShape = CIRCLE;
                lineButton.Checked = false;
                rectangleButton.Checked = false;
            }
        }
    }
}
