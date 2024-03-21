using System;
using System.Drawing;
using System.Windows.Forms;
using PowerPoint.model;
using PowerPoint.presentation_model;

namespace PowerPoint {
    public partial class Form1 : Form {
        const int LINE_NUMBER = 0;
        const int RECTANGLE_NUMBER = 1;
        const int CIRCLE_NUMBER = 2;
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";
        const string DELETE = "Delete";
        const string SHAPE = "Shape";
        const string INFORMATION = "Information";

        private Model _model;
        private FormPresentationModel _presentationModel;
        private int _slideIndex;

        public Form1(Model model) {
            InitializeComponent();

            _model = model;
            _presentationModel = new FormPresentationModel(model);

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
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = SHAPE;
            nameColumn.Width = 60;
            nameColumn.DataPropertyName = "Name";
            _shapesDataGridView.Columns.Insert(1, nameColumn);

            // add information column
            DataGridViewTextBoxColumn informationColumn = new DataGridViewTextBoxColumn();
            informationColumn.HeaderText = INFORMATION;
            informationColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            informationColumn.DataPropertyName = "Information";
            _shapesDataGridView.Columns.Insert(2, informationColumn);

            // handle event
            _model._modelChanged += HandleModelChanged;
            _panel.MouseDown += HandleMousePressed;
            _panel.MouseUp += HandleMouseReleased;
            _panel.MouseMove += HandleMouseMoved;
            _panel.MouseMove += MouseZoom;
            _panel.Paint += HandleMousePaint;
            _slide1.Paint += HandleSlidePaint;
            this.SizeChanged += UpdateAutoSize;
            _slide1.SizeChanged += PreviewSlideAutoSize;
            _splitContainer1.SplitterMoved += UpdateAutoSize;
            _splitContainer1.SplitterMoved += PreviewSlideAutoSize;
            _splitContainer2.SplitterMoved += UpdateAutoSize;
            _splitContainer2.SplitterMoved += PreviewSlideAutoSize;

            _slide1.SizeChanged += HandleModelChangedDraw;
            _panel.SizeChanged += HandleModelChangedDraw;

            _slide1.MouseClick += PreviewSlideClick;

            // button click
            _presentationModel.PropertyChanged += UpdateButtonStatus;
            _model._redoUndoChanged += UpdateRedoUndoButtonStatus;

            // delete the shape
            this.KeyPreview = true;
            this.KeyDown += PressDeleteKey;

            Controls.Add(_panel);

            _splitContainer2.Panel1.Controls.Add(_panel);
            _panel.BringToFront();

            _splitContainer1.FixedPanel = FixedPanel.Panel1;
            _splitContainer2.FixedPanel = FixedPanel.Panel2;

            _panelWidthRecord = _panel.Width;

            _undoButton.Enabled = false;
            _redoButton.Enabled = false;

            _slide1.BackColor = Color.BlueViolet;
            _model.SlideIndex = 0;

            _model._slideChanged += CreateSlide;
            _model._slideDeleted += RemoveSlide;
        }

        // slide index
        int SlideIndex {
            get { return _slideIndex; }
            set {
                _slideIndex = value;
                _model.SlideIndex = value;
            }
        }

        // function for create
        private void CreateNewShapeButtonClick(object sender, EventArgs e) {
            string name;
            switch (_addNewShapeSelector.SelectedIndex) {
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
        private void DeleteShapeButtonClick(object sender, DataGridViewCellEventArgs e) {
            if (_shapesDataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {
                int selectedRowIndex = e.RowIndex;
                _model.Remove(selectedRowIndex);
            }
        }

        // update button click status
        private void UpdateButtonStatus() {
            _lineButton.Checked = _presentationModel.LineButtonChecked;
            _rectangleButton.Checked = _presentationModel.RectangleButtonChecked;
            _circleButton.Checked = _presentationModel.CircleButtonChecked;
            _mouseButton.Checked = _presentationModel.MouseButtonChecked;
        }

        // update redo undo button status
        private void UpdateRedoUndoButtonStatus() {
            _undoButton.Enabled = _model.UndoButtonEnabled;
            _redoButton.Enabled = _model.RedoButtonEnabled;
        }

        // line button click
        private void ClickLineButton(object sender, EventArgs e) {
            _presentationModel.ClickLineButton();
        }

        // rectangle button click
        private void ClickRectangleButton(object sender, EventArgs e) {
            _presentationModel.ClickRectangleButton();
        }

        // circle button click
        private void ClickCircleButton(object sender, EventArgs e) {
            _presentationModel.ClickCircleButton();
        }

        // mouse buttton click
        private void ClickMouseButton(object sender, EventArgs e) {
            _presentationModel.ClickMouseButton();
        }

        // mouse pressed
        private void HandleMousePressed(object sender, MouseEventArgs e) {
            _presentationModel.MousePress(new PointF(e.X, e.Y));
        }

        // mouse moved
        public void HandleMouseMoved(object sender, MouseEventArgs e) {
            _presentationModel.MouseMove(new PointF(e.X, e.Y));
        }

        // mouse released
        public void HandleMouseReleased(object sender, MouseEventArgs e) {
            Cursor = Cursors.Default;
            _presentationModel.MouseRelease(new PointF(e.X, e.Y));
        }

        // function to handle paint
        public void HandleMousePaint(object sender, PaintEventArgs e) {
            _presentationModel.Draw(e.Graphics);
        }

        // function to handle preview paint
        public void HandleSlidePaint(object sender, PaintEventArgs e) {
            Button button = sender as Button;
            foreach (Control control in _slidePanel.Controls) {
                _presentationModel.PreviewDraw(e.Graphics, _slidePanel.Controls.GetChildIndex(button));
            }
        }

        // function to handle the change of model
        public void HandleModelChanged() {
            _panel.Invalidate(true);
            //_slide1.Invalidate(true);
            foreach (Control control in _slidePanel.Controls) {
                if (control is Button button) {
                    button.Invalidate(true);
                }
            }
        }

        // function to handle the change of model
        public void HandleModelChangedDraw(object sender, EventArgs e) {
            _panel.Invalidate(true);
            //_slide1.Invalidate(true);
            foreach (Control control in _slidePanel.Controls) {
                if (control is Button button) {
                    if (_slidePanel.Controls.GetChildIndex(button) == _model.SlideIndex) {
                        button.Invalidate(true);
                    }
                }
            }
        }

        // when mouse enter the panel
        private void PanelMouseEnter(object sender, EventArgs e) {
            if (_lineButton.Checked || _rectangleButton.Checked || _circleButton.Checked) {
                Cursor = Cursors.Cross;
            }
        }

        // when mouse leave the panel
        private void PanelMouseLeave(object sender, EventArgs e) {
            Cursor = Cursors.Default;
        }

        // mouse zoom
        private void MouseZoom(object sender, MouseEventArgs e) {
            if (_model.IsClickTheRightBottomCorner(new PointF(e.X, e.Y))) {
                Cursor = Cursors.SizeNWSE;
            }
            else if (_lineButton.Checked || _rectangleButton.Checked || _circleButton.Checked) {
                Cursor = Cursors.Cross;
            }
            else {
                Cursor = Cursors.Default;
            }
        }

        // press delete key
        private void PressDeleteKey(object sender, KeyEventArgs e) {
            if (_model.SlideIndex != -1 && _model.TargetIndex == -1) {
                _model.DeleteSlideCommand(_model.SlideIndex);
                return;
            }

            if (e.KeyCode == Keys.Delete) {
                if (_model.TargetIndex == -1 && _model.SlideIndex != -1) {
                    _slidePanel.Controls.RemoveAt(_model.SlideIndex);
                }
                else {
                    _model.PressDeleteKey();
                }
            }
        }

        private int _panelWidthRecord = -1;

        const int NINE = 9;
        const int SIXTEEN = 16;

        // auto size
        private void UpdateAutoSize(object sender, EventArgs e) {
            _presentationModel.DrawRatio = (float)_panel.Width / (float)_panelWidthRecord;
            _panelWidthRecord = _panel.Width;
            _panel.Size = new Size(_panel.Width, _panel.Width * NINE / SIXTEEN);
        }

        // slide preview auto size
        private void PreviewSlideAutoSize(object sender, EventArgs e) {
            int y = _slide1.Location.Y;
            foreach (Control control in _slidePanel.Controls) {
                if (control is Button button) {
                    button.Width = _splitContainer1.Panel1.Width - 5;
                    button.Size = new Size(button.Width, button.Width * NINE / SIXTEEN);
                    button.Location = new Point(button.Location.X, y);
                    y += button.Height + 10;
                }
            }

            _presentationModel.PreviewDrawRatio = (float)_slide1.Width / (float)_panel.Width;
        }

        // press undo button
        private void PressUndoButton(object sender, EventArgs e) {
            _model.Undo();
        }

        // press redo button
        private void PressRedoButton(object sender, EventArgs e) {
            _model.Redo();
        }

        // press new slide button
        private void PressNewSlideButton(object sender, EventArgs e) {
            _model.AddSlideCommand();
        }

        // create slide
        private void CreateSlide() {
            Button newButton = new Button();
            newButton.BackColor = Color.White;
            newButton.Size = _slide1.Size;
            newButton.Location =
                new Point(_lastButton.Location.X,
                    _lastButton.Location.Y + _lastButton.Height + 10); // 10 is the space between the buttons
            newButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newButton.Paint += HandleSlidePaint;
            newButton.SizeChanged += PreviewSlideAutoSize;
            newButton.Click += new EventHandler(PreviewSlideClick);
            _slidePanel.Controls.Add(newButton);
            _lastButton = newButton;
        }

        // remove slide
        private void RemoveSlide() {
            _slidePanel.Controls.RemoveAt(_model.SlideIndex);
        }

        // preview slide click
        private void PreviewSlideClick(object sender, EventArgs e) {
            foreach (Control control in _slidePanel.Controls) {
                if (control is Button button) {
                    button.BackColor = Color.White;
                }
            }

            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.BlueViolet;
            _model.TargetIndex = -1;
            _model.SlideIndex = _slidePanel.Controls.GetChildIndex(clickedButton);
            _model.NotifyModelChanged();
            _shapesDataGridView.DataSource = _model.GetListOfShape();
        }
    }
}