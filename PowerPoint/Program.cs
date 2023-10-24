using PowerPoint.model;
using System;
using System.Windows.Forms;

namespace PowerPoint
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Model model = new Model();
            Application.Run(new Form1(model));
        }
    }
}