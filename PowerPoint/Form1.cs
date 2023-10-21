using PowerPoint.Properties;
using PowerPoint.model;
using System;
using System.Windows.Forms;
using System.Drawing;

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
        private PresentationModel _presentationModel;
        private Random _random = new Random();

        public Form1(Model model, PresentationModel presentationModel)
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
            Shape shapeTemp = _model.Add(name, _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX), _random.Next(RANDOM_NUMBER_MAX));
            shapeTemp.Draw(this._panel);
            _shapesDataGridView.Rows.Add(DELETE, shapeTemp.GetShapeChineseName(), shapeTemp.GetInformation());
        }

        // delete shpae
        private void DeleteShapeButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            _model.Remove(selectedRowIndex);
            _shapesDataGridView.Rows.RemoveAt(selectedRowIndex);
        }

        // what show on panel
        private void Panel(object sender, PaintEventArgs e)
        {
            //Graphics graphics = this._panel.CreateGraphics();

            //Pen pen = new Pen(Color.Black, 3);
            //PointF point1 = new PointF(100.0F, 100.0F);
            //PointF point2 = new PointF(500.0F, 200.0F);
            //e.Graphics.DrawLine(pen, point1, point2);
        }
    }
}
