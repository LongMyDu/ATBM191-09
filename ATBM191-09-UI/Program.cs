using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM191_09_UI
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
            //MainForm mainForm = new MainForm();
            //if (!mainForm.IsDisposed)
            //  Application.Run(mainForm);
            Login log = new Login();
            if (!log.IsDisposed)
                Application.Run(log);
            
        }
    }
}
