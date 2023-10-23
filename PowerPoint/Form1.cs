using PowerPoint.model;
using PowerPoint.Properties;
using System;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        const int LINE_NUMBER = 0;
        const int RECTANGLE_NUMBER = 1;
        const int CIRCLE_NUMBER = 2;
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";
        const string DELETE = "刪除";

        private Model _model;
        private FormPresentationModel _presentationModel;
        //private FormGraphicsAdaptor _formGraphicsAdaptor;

        public Form1(Model model, FormPresentationModel presentationModel)
        {
            InitializeComponent();
            _model = model;
            _presentationModel = presentationModel;

        }

        // function for create
        private void CreateNewShapeButtonClick(object sender, EventArgs e)
        {
            string name = "";
            switch (_addNewShapeSelector.SelectedIndex)
            {
                case LINE_NUMBER:
                    name = LINE;
                    break;
                case RECTANGLE_NUMBER:
                    name = RECTANGLE;
                    break;
                case CIRCLE_NUMBER:
                    name = CIRCLE;
                    break;
            }
            if (name != "")
            {
                Shape shapeTemp = _model.Add(name);
                //shapeTemp.Draw(this._panel);
                _shapesDataGridView.Rows.Add(DELETE, shapeTemp.GetShapeChineseName(), shapeTemp.GetInformation());
            }
        }

        // delete shpae
        private void DeleteShapeButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            _model.Remove(selectedRowIndex);
            _shapesDataGridView.Rows.RemoveAt(selectedRowIndex);
        }

        // line button click
        private void LineButtonClick(object sender, EventArgs e)
        {
            _lineButton.Checked = !_lineButton.Checked;
            if (_lineButton.Checked)
            {
                _rectangleButton.Checked = false;
                _circleButton.Checked = false;
            }
        }

        // rectangle button click
        private void RectangleButtonClick(object sender, EventArgs e)
        {
            _rectangleButton.Checked = !_rectangleButton.Checked;
            if (_rectangleButton.Checked)
            {
                _lineButton.Checked = false;
                _circleButton.Checked = false;
            }
        }

        // circle button click
        private void CircleButtonClick(object sender, EventArgs e)
        {
            _circleButton.Checked = !_circleButton.Checked;
            if (_circleButton.Checked)
            {
                _lineButton.Checked = false;
                _rectangleButton.Checked = false;
            }
        }

        // mouse pressed
        private void HandleMousePressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerPressed(e.X, e.Y);
        }

        // mouse moved
        public void HandleMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerMoved(e.X, e.Y);
        }

        // mouse released
        public void HandleMouseReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerReleased(e.X, e.Y);
        }
    }
}