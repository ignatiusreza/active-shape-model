using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Active_Shape_Model
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