using PowerPoint.model;
using System;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        const int LINE_NUMBER = 0;
        const int RECTANGLE_NUMBER = 1;
        const int CIRCLE_NUMBER = 2;
        const string DELETE = "Delete";
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string CIRCLE = "Circle";
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
                _shapesDataGridView.Rows.Add(Translator.Translate(DELETE), Translator.Translate(name), _model.Add(name, _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX)).GetInformation());
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
