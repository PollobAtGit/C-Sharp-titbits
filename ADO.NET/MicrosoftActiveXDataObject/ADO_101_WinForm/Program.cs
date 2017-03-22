using System;
using System.Windows.Forms;
using ADO_101_WinForm.Forms;

namespace ADO_101_WinForm
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
            Application.Run(new StudentGrid());
        }
    }
}
