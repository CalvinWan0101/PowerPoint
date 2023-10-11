
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
            this._slidePanel = new System.Windows.Forms.Panel();
            this._slide2 = new System.Windows.Forms.Button();
            this._slide1 = new System.Windows.Forms.Button();
            this._createNewShape = new System.Windows.Forms.Button();
            this._addNewShapeSelector = new System.Windows.Forms.ComboBox();
            this._slideDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._shapesDataGridView = new System.Windows.Forms.DataGridView();
            this._headMenu = new System.Windows.Forms.MenuStrip();
            this._headMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this._headMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._informationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._slidePanel.SuspendLayout();
            this._slideDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapesDataGridView)).BeginInit();
            this._headMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _slidePanel
            // 
            this._slidePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._slidePanel.Controls.Add(this._slide2);
            this._slidePanel.Controls.Add(this._slide1);
            this._slidePanel.Location = new System.Drawing.Point(0, 28);
            this._slidePanel.Name = "_slidePanel";
            this._slidePanel.Size = new System.Drawing.Size(200, 536);
            this._slidePanel.TabIndex = 0;
            // 
            // _slide2
            // 
            this._slide2.Location = new System.Drawing.Point(3, 109);
            this._slide2.Name = "_slide2";
            this._slide2.Size = new System.Drawing.Size(195, 100);
            this._slide2.TabIndex = 1;
            this._slide2.UseVisualStyleBackColor = true;
            // 
            // _slide1
            // 
            this._slide1.Location = new System.Drawing.Point(3, 3);
            this._slide1.Name = "_slide1";
            this._slide1.Size = new System.Drawing.Size(195, 100);
            this._slide1.TabIndex = 0;
            this._slide1.UseVisualStyleBackColor = true;
            // 
            // _createNewShape
            // 
            this._createNewShape.Location = new System.Drawing.Point(-1, 22);
            this._createNewShape.Name = "_createNewShape";
            this._createNewShape.Size = new System.Drawing.Size(63, 31);
            this._createNewShape.TabIndex = 2;
            this._createNewShape.Text = "新增";
            this._createNewShape.UseVisualStyleBackColor = true;
            this._createNewShape.Click += new System.EventHandler(this.CreateNewShapeButtonClick);
            // 
            // _addNewShapeSelector
            // 
            this._addNewShapeSelector.FormattingEnabled = true;
            this._addNewShapeSelector.Items.AddRange(new object[] {
            "線",
            "矩形"});
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
            this._slideDetailGroupBox.Location = new System.Drawing.Point(884, 27);
            this._slideDetailGroupBox.Name = "_slideDetailGroupBox";
            this._slideDetailGroupBox.Size = new System.Drawing.Size(300, 537);
            this._slideDetailGroupBox.TabIndex = 4;
            this._slideDetailGroupBox.TabStop = false;
            this._slideDetailGroupBox.Text = "資料顯示";
            // 
            // _shapesDataGridView
            // 
            this._shapesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._informationColumn});
            this._shapesDataGridView.Location = new System.Drawing.Point(-1, 56);
            this._shapesDataGridView.Name = "_shapesDataGridView";
            this._shapesDataGridView.ReadOnly = true;
            this._shapesDataGridView.RowHeadersVisible = false;
            this._shapesDataGridView.Size = new System.Drawing.Size(300, 481);
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
            this._headMenu.Size = new System.Drawing.Size(1184, 24);
            this._headMenu.TabIndex = 5;
            this._headMenu.Text = "menuStrip1";
            // 
            // _headMenuHelp
            // 
            this._headMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._headMenuAbout});
            this._headMenuHelp.Name = "_headMenuHelp";
            this._headMenuHelp.Size = new System.Drawing.Size(44, 20);
            this._headMenuHelp.Text = "說明";
            // 
            // _headMenuAbout
            // 
            this._headMenuAbout.Name = "_headMenuAbout";
            this._headMenuAbout.Size = new System.Drawing.Size(98, 22);
            this._headMenuAbout.Text = "關於";
            // 
            // _deleteColumn
            // 
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _shapeColumn
            // 
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.Name = "_shapeColumn";
            this._shapeColumn.ReadOnly = true;
            // 
            // _informationColumn
            // 
            this._informationColumn.HeaderText = "資訊";
            this._informationColumn.Name = "_informationColumn";
            this._informationColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this._slideDetailGroupBox);
            this.Controls.Add(this._slidePanel);
            this.Controls.Add(this._headMenu);
            this.MainMenuStrip = this._headMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this._slidePanel.ResumeLayout(false);
            this._slideDetailGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapesDataGridView)).EndInit();
            this._headMenu.ResumeLayout(false);
            this._headMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _slidePanel;
        private System.Windows.Forms.Button _createNewShape;
        private System.Windows.Forms.ComboBox _addNewShapeSelector;
        private System.Windows.Forms.GroupBox _slideDetailGroupBox;
        private System.Windows.Forms.Button _slide1;
        private System.Windows.Forms.Button _slide2;
        private System.Windows.Forms.MenuStrip _headMenu;
        private System.Windows.Forms.ToolStripMenuItem _headMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem _headMenuAbout;
        private System.Windows.Forms.DataGridView _shapesDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _informationColumn;
    }
}

