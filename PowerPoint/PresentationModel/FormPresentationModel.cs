using System.Windows.Forms;

namespace PowerPoint.model
{
    public class FormPresentationModel
    {
        private Model _model;

        public FormPresentationModel(Model model, Control canvas)
        {
            this._model = model;
        }

        // draw all the shape
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new FormGraphicsAdaptor(graphics));
        }
    }
}
