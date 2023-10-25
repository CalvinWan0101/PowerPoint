using PowerPoint.model;
using PowerPoint.Properties;
using System;
using System.Drawing;
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

        public Form1(Model model)
        {
            InitializeComponent();

            _model = model;
            _presentationModel = new FormPresentationModel(model, _panel);

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
            string name;
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
                default:
                    return;
            }
            Shape shapeTemp = _model.Add(name);
            _shapesDataGridView.Rows.Add(DELETE, shapeTemp.GetShapeChineseName(), shapeTemp.GetInformation());
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
        private void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickLineButton(ref _lineButton, ref _rectangleButton, ref _circleButton);
        }

        // rectangle button click
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickRectangleButton(ref _lineButton, ref _rectangleButton, ref _circleButton);
        }

        // circle button click
        private void ClickCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickCircleButton(ref _lineButton, ref _rectangleButton, ref _circleButton);
        }

        // mouse pressed
        private void HandleMousePressed(object sender, MouseEventArgs e)
        {
            _presentationModel.PressPointer(e.X, e.Y);
        }

        // mouse moved
        public void HandleMouseMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.MovePointer(e.X, e.Y);
        }

        // mouse released
        public void HandleMouseReleased(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            Shape shape = _presentationModel.ReleasePointer(new PointF(e.X, e.Y), ref _lineButton, ref _rectangleButton, ref _circleButton);
            if (shape != null)
            {
                _shapesDataGridView.Rows.Add(DELETE, shape.GetShapeChineseName(), shape.GetInformation());
            }
        }

        // function to handle paint
        public void HandleMousePaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // function to handle the change of model
        public void HandleModelChanged()
        {
            _panel.Invalidate(true);
        }

        // when mouse enter the panel
        private void PanelMouseEnter(object sender, EventArgs e)
        {
            if (_lineButton.Checked || _rectangleButton.Checked || _circleButton.Checked)
            {
                Cursor = Cursors.Cross;
            }
        }

        // when mouse leave the panel
        private void PanelMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}