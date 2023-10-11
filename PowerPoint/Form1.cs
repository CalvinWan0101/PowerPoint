using PowerPoint.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        const int LINE_NUMBER = 0;
        const int RECTANGLE_NUMBER = 1;
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string DELETE_BUTTON = "刪除";
        const string LINE_CHINESE = "線";
        const string RECTANGLE_CHINESE = "矩形";
        const int RANDOM_NUMBER_MAX = 101;

        private Model _model;
        private Random _random = new Random();

        public Form1(Model model)
        {
            InitializeComponent();
            _model = model;
        }

        // function for create
        private void CreateNewShapeButtonClick(object sender, EventArgs e)
        {
            string name = "";
            string showName = "";
            switch (_addNewShapeSelector.SelectedIndex)
            {
                case LINE_NUMBER:
                    name = LINE;
                    showName = LINE_CHINESE;
                    break;
                case RECTANGLE_NUMBER:
                    name = RECTANGLE;
                    showName = RECTANGLE_CHINESE;
                    break;
            }
            if (name != "")
            {
                _shapesDataGridView.Rows.Add(DELETE_BUTTON, showName, _model.Add(name, _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX)).GetInformation());
            }
        }

        // delete shpae
        private void DeleteShapeButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            int clickColumn = e.ColumnIndex;
            if (clickColumn != 0)
            {
                return;
            }
            int selectedRowIndex = e.RowIndex;
            _model.Remove(selectedRowIndex);
            _shapesDataGridView.Rows.RemoveAt(selectedRowIndex);
        }
    }
}
