
namespace PowerPoint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._createNewShape = new System.Windows.Forms.Button();
            this._addNewShapeSelector = new System.Windows.Forms.ComboBox();
            this._slideDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._shapesDataGridView = new System.Windows.Forms.DataGridView();
            this._headMenu = new System.Windows.Forms.MenuStrip();
            this._headMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this._headMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._toolBar = new System.Windows.Forms.ToolStrip();
            this._lineButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleButton = new System.Windows.Forms.ToolStripButton();
            this._circleButton = new System.Windows.Forms.ToolStripButton();
            this._mouseButton = new System.Windows.Forms.ToolStripButton();
            this._newSlideButton = new System.Windows.Forms.ToolStripButton();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._slidePanel = new System.Windows.Forms.FlowLayoutPanel();
            this._slide1 = new System.Windows.Forms.Button();
            this._lastButton = _slide1;
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._panel = new PowerPoint.DoubleBufferedPanel();
            this._slideDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapesDataGridView)).BeginInit();
            this._headMenu.SuspendLayout();
            this._toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            this._slidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _createNewShape
            // 
            this._createNewShape.Location = new System.Drawing.Point(-1, 22);
            this._createNewShape.Name = "_createNewShape";
            this._createNewShape.Size = new System.Drawing.Size(63, 31);
            this._createNewShape.TabIndex = 2;
            this._createNewShape.Text = "New";
            this._createNewShape.UseVisualStyleBackColor = true;
            this._createNewShape.Click += new System.EventHandler(this.CreateNewShapeButtonClick);
            // 
            // _addNewShapeSelector
            // 
            this._addNewShapeSelector.FormattingEnabled = true;
            this._addNewShapeSelector.Items.AddRange(new object[] {
            "Line",
            "Rectangle",
            "Circle"});
            this._addNewShapeSelector.Location = new System.Drawing.Point(68, 29);
            this._addNewShapeSelector.Name = "_addNewShapeSelector";
            this._addNewShapeSelector.Size = new System.Drawing.Size(91, 21);
            this._addNewShapeSelector.TabIndex = 3;
            // 
            // _slideDetailGroupBox
            // 
            this._slideDetailGroupBox.Controls.Add(this._shapesDataGridView);
            this._slideDetailGroupBox.Controls.Add(this._addNewShapeSelector);
            this._slideDetailGroupBox.Controls.Add(this._createNewShape);
            this._slideDetailGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._slideDetailGroupBox.Location = new System.Drawing.Point(0, 0);
            this._slideDetailGroupBox.Name = "_slideDetailGroupBox";
            this._slideDetailGroupBox.Size = new System.Drawing.Size(273, 361);
            this._slideDetailGroupBox.TabIndex = 4;
            this._slideDetailGroupBox.TabStop = false;
            this._slideDetailGroupBox.Text = "Data Grid View";
            // 
            // _shapesDataGridView
            // 
            this._shapesDataGridView.AllowUserToAddRows = false;
            this._shapesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapesDataGridView.Location = new System.Drawing.Point(-2, 56);
            this._shapesDataGridView.Name = "_shapesDataGridView";
            this._shapesDataGridView.ReadOnly = true;
            this._shapesDataGridView.RowHeadersVisible = false;
            this._shapesDataGridView.Size = new System.Drawing.Size(275, 357);
            this._shapesDataGridView.TabIndex = 4;
            this._shapesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeleteShapeButtonClick);
            // 
            // _headMenu
            // 
            this._headMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._headMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._headMenuHelp});
            this._headMenu.Location = new System.Drawing.Point(0, 0);
            this._headMenu.Name = "_headMenu";
            this._headMenu.Size = new System.Drawing.Size(1094, 24);
            this._headMenu.TabIndex = 5;
            this._headMenu.Text = "menuStrip1";
            // 
            // _headMenuHelp
            // 
            this._headMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._headMenuAbout});
            this._headMenuHelp.Name = "_headMenuHelp";
            this._headMenuHelp.Size = new System.Drawing.Size(44, 20);
            this._headMenuHelp.Text = "Help";
            // 
            // _headMenuAbout
            // 
            this._headMenuAbout.Name = "_headMenuAbout";
            this._headMenuAbout.Size = new System.Drawing.Size(98, 22);
            this._headMenuAbout.Text = "About";
            // 
            // _toolBar
            // 
            this._toolBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._circleButton,
            this._mouseButton,
            this._newSlideButton,
            this._undoButton,
            this._redoButton});
            this._toolBar.Location = new System.Drawing.Point(0, 24);
            this._toolBar.Name = "_toolBar";
            this._toolBar.Size = new System.Drawing.Size(1094, 25);
            this._toolBar.TabIndex = 6;
            this._toolBar.Text = "toolStrip1";
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineButton.Image")));
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(23, 22);
            this._lineButton.Text = "Line";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleButton.Image")));
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(23, 22);
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleButton.Image = ((System.Drawing.Image)(resources.GetObject("_circleButton.Image")));
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(23, 22);
            this._circleButton.Text = "Circle";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _mouseButton
            // 
            this._mouseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._mouseButton.Image = ((System.Drawing.Image)(resources.GetObject("_mouseButton.Image")));
            this._mouseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mouseButton.Name = "_mouseButton";
            this._mouseButton.Size = new System.Drawing.Size(23, 22);
            this._mouseButton.Text = "Mouse";
            this._mouseButton.Click += new System.EventHandler(this.ClickMouseButton);
            // 
            // _newSlideButton
            // 
            this._newSlideButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._newSlideButton.Image = ((System.Drawing.Image)(resources.GetObject("_newSlideButton.Image")));
            this._newSlideButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._newSlideButton.Name = "_newSlideButton";
            this._newSlideButton.Size = new System.Drawing.Size(23, 22);
            this._newSlideButton.Text = "New Slide";
            this._newSlideButton.Click += new System.EventHandler(this.PressNewSlideButton);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(23, 22);
            this._undoButton.Text = "Undo";
            this._undoButton.Click += new System.EventHandler(this.PressUndoButton);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(23, 22);
            this._redoButton.Text = "Redo";
            this._redoButton.Click += new System.EventHandler(this.PressRedoButton);
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer1.Location = new System.Drawing.Point(0, 52);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._slidePanel);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1094, 361);
            this._splitContainer1.SplitterDistance = 167;
            this._splitContainer1.TabIndex = 8;
            // 
            // _slidePanel
            // 
            this._slidePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this._slidePanel.Controls.Add(this._slide1);
            this._slidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._slidePanel.Location = new System.Drawing.Point(0, 0);
            this._slidePanel.Name = "_slidePanel";
            this._slidePanel.Size = new System.Drawing.Size(167, 361);
            this._slidePanel.TabIndex = 0;
            // 
            // _slide1
            // 
            this._slide1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._slide1.AutoSize = true;
            this._slide1.Location = new System.Drawing.Point(3, 3);
            this._slide1.Name = "_slide1";
            this._slide1.Size = new System.Drawing.Size(161, 90);
            this._slide1.TabIndex = 0;
            this._slide1.UseVisualStyleBackColor = true;
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this._splitContainer2.Panel1.Controls.Add(this._panel);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._slideDetailGroupBox);
            this._splitContainer2.Size = new System.Drawing.Size(923, 361);
            this._splitContainer2.SplitterDistance = 646;
            this._splitContainer2.TabIndex = 0;
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.AutoScroll = true;
            this._panel.BackColor = System.Drawing.SystemColors.Control;
            this._panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._panel.Location = new System.Drawing.Point(2, 1);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(640, 360);
            this._panel.TabIndex = 7;
            this._panel.MouseEnter += new System.EventHandler(this.PanelMouseEnter);
            this._panel.MouseLeave += new System.EventHandler(this.PanelMouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 413);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._headMenu);
            this.Controls.Add(this._splitContainer1);
            this.MainMenuStrip = this._headMenu;
            this.Name = "Form1";
            this.Text = "PowerPoint";
            this._slideDetailGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapesDataGridView)).EndInit();
            this._headMenu.ResumeLayout(false);
            this._headMenu.PerformLayout();
            this._toolBar.ResumeLayout(false);
            this._toolBar.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._slidePanel.ResumeLayout(false);
            this._slidePanel.PerformLayout();
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _createNewShape;
        private System.Windows.Forms.ComboBox _addNewShapeSelector;
        private System.Windows.Forms.GroupBox _slideDetailGroupBox;
        private System.Windows.Forms.Button _lastButton;
        private System.Windows.Forms.MenuStrip _headMenu;
        private System.Windows.Forms.ToolStripMenuItem _headMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem _headMenuAbout;
        private System.Windows.Forms.DataGridView _shapesDataGridView;
        private System.Windows.Forms.ToolStrip _toolBar;
        private System.Windows.Forms.ToolStripButton _lineButton;
        private System.Windows.Forms.ToolStripButton _rectangleButton;
        private System.Windows.Forms.ToolStripButton _circleButton;
        private DoubleBufferedPanel _panel;
        private System.Windows.Forms.ToolStripButton _mouseButton;
        private System.Windows.Forms.ToolStripButton _undoButton;
        private System.Windows.Forms.ToolStripButton _redoButton;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer2;
        private System.Windows.Forms.ToolStripButton _newSlideButton;
        private System.Windows.Forms.Button _slide1;
        private System.Windows.Forms.FlowLayoutPanel _slidePanel;
    }
}

