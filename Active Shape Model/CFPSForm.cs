using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Active_Shape_Model {
  public partial class CFPSForm:Form {
    public CFPSForm() {
      InitializeComponent();
    }

    private void fpsLimit_KeyDown(object sender,KeyEventArgs e) {
      switch(e.KeyCode) {
        case Keys.D0 : case Keys.D1 : case Keys.D2 : case Keys.D3 : case Keys.D4 :
        case Keys.D5 : case Keys.D6 : case Keys.D7 : case Keys.D8 : case Keys.D9 :
        case Keys.NumPad0 : case Keys.NumPad1 : case Keys.NumPad2 : case Keys.NumPad3 : case Keys.NumPad4 :
        case Keys.NumPad5 : case Keys.NumPad6 : case Keys.NumPad7 : case Keys.NumPad8 : case Keys.NumPad9 :
        case Keys.Left  : case Keys.Right  : case Keys.Tab :
        case Keys.Enter : case Keys.Escape :
        case Keys.Back  : case Keys.Delete :
          break;
        default :
          e.SuppressKeyPress = true;
          break;
      }
    }

    private void btnOk_Click(object sender,EventArgs e) {
      this.DialogResult = DialogResult.OK;
    }
  }
}