using PowerPoint.model;
using PowerPoint.presentation_model;
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
        const string SHAPE = "形狀";
        const string INFORMATION = "資訊";

        private Model _model;
        private FormPresentationModel _presentationModel;

        public Form1(Model model)
        {
            InitializeComponent();

            _model = model;
            _presentationModel = new FormPresentationModel(model, _panel);

            // data grid view
            _shapesDataGridView.AutoGenerateColumns = false;
            _shapesDataGridView.DataSource = _model.GetListOfShape();

            // add button column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = DELETE;
            buttonColumn.Text = DELETE;
            buttonColumn.Width = 50;
            buttonColumn.UseColumnTextForButtonValue = true;
            _shapesDataGridView.Columns.Insert(0, buttonColumn);

            // add shape column
            DataGridViewTextBoxColumn chineseNameColumn = new DataGridViewTextBoxColumn();
            chineseNameColumn.HeaderText = SHAPE;
            chineseNameColumn.Width = 60;
            chineseNameColumn.DataPropertyName = "_chineseName";
            _shapesDataGridView.Columns.Insert(1, chineseNameColumn);

            // add information column
            DataGridViewTextBoxColumn informationColumn = new DataGridViewTextBoxColumn();
            informationColumn.HeaderText = INFORMATION;
            informationColumn.Width = 190;
            informationColumn.DataPropertyName = "_information";
            _shapesDataGridView.Columns.Insert(2, informationColumn);

            // handle event
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
            _model.Add(name);
        }

        // delete shpae
        private void DeleteShapeButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            _model.Remove(selectedRowIndex);
        }

        // update button click status
        private void UpdateButtonStatus()
        {
            _lineButton.Checked = _presentationModel.IsLineButtonChecked();
            _rectangleButton.Checked = _presentationModel.IsRectangleButtonChecked();
            _circleButton.Checked = _presentationModel.IsCircleButtonChecked();
            _mouseButton.Checked = _presentationModel.IsMouseButtonChecked();
        }

        // line button click
        private void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickLineButton();
            UpdateButtonStatus();
        }

        // rectangle button click
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickRectangleButton();
            UpdateButtonStatus();
        }

        // circle button click
        private void ClickCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickCircleButton();
            UpdateButtonStatus();
        }

        // mouse buttton click
        private void ClickMouseButton(object sender, EventArgs e)
        {
            _presentationModel.ClickMouseButton();
            UpdateButtonStatus();
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
            _presentationModel.ReleasePointer(new PointF(e.X, e.Y));
            UpdateButtonStatus();
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
            _presentationModel.CopyPanelToSlide(_panel, _slide1);
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