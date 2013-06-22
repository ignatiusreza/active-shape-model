using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Training_Set_Builder
{
    static class CMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CMainForm());
        }
    }
}