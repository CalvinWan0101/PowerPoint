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
        private FormGraphicsAdaptor _formGraphicsAdaptor;

        private string _selectedShape = "";

        public Form1(Model model)
        {
            InitializeComponent();
            _model = model;
            _presentationModel = new FormPresentationModel(_model, _panel);
            _model._modelChanged += HandleModelChanged;

            _panel.MouseDown += HandleMousePressed;
            _panel.MouseUp += HandleMouseReleased;
            _panel.MouseMove += HandleMouseMoved;
            _panel.Paint += HandleMousePaint;
            Controls.Add(_panel);
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
            if (selectedRowIndex == -1)
            {
                _model.Clear();
                _shapesDataGridView.Rows.Clear();
            }
            else
            {
                _model.Remove(selectedRowIndex);
                _shapesDataGridView.Rows.RemoveAt(selectedRowIndex);
            }
        }

        // line button click
        private void LineButtonClick(object sender, EventArgs e)
        {
            _lineButton.Checked = !_lineButton.Checked;
            if (_lineButton.Checked)
            {
                _selectedShape = "Line";
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
                _selectedShape = "Rectangle";
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
                _selectedShape = "Circle";
                _lineButton.Checked = false;
                _rectangleButton.Checked = false;
            }
        }

        // mouse pressed
        private void HandleMousePressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }

        // mouse moved
        public void HandleMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerMoved(_selectedShape, e.X, e.Y);
        }

        // mouse released
        public void HandleMouseReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Shape shapeTemp = _model.PointerReleased(_selectedShape, e.X, e.Y);
            if (shapeTemp != null)
            {
                _shapesDataGridView.Rows.Add(DELETE, shapeTemp.GetShapeChineseName(), shapeTemp.GetInformation());
            }
        }

        // function to handle paint
        public void HandleMousePaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // function to handle the change of model
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}