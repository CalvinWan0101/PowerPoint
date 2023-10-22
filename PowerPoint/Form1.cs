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
        const int RANDOM_NUMBER_MAX = 511;

        private Model _model;
        private FormPresentationModel _presentationModel;
        private Random _random = new Random();

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
                Shape shapeTemp = _model.Add(name, _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX));
                shapeTemp.Draw(this._panel);
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

        private bool _lineButtonIsClick = false;
        private bool _RectangleButtonIsClick = false;
        private bool _CircleButtonIsClick = false;

        // line button click
        private void LineButtonClick(object sender, EventArgs e)
        {
            _lineButtonIsClick = true;
        }

        // rectangle button click
        private void RectangleButtonClick(object sender, EventArgs e)
        {
            _RectangleButtonIsClick = true;
        }

        // circle button click
        private void CircleButtonClick(object sender, EventArgs e)
        {
            _CircleButtonIsClick = true;
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