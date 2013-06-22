using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Training_Set_Builder {
  public partial class CDetailedForm : Form {
    public enum TTools {
      POINTER = 0,
      LINE
    };

    #region "Attributes"

    public TTools toolsSelected;

    #endregion

    #region "Constructor & Destructor"

    public CDetailedForm() {
      InitializeComponent();
    }

    #endregion

    private void CDetailedForm_FormClosing(object sender,FormClosingEventArgs e) {
      e.Cancel = true;
      this.Hide();
    }

    #region "Event Handler"
 
    #endregion
  }
}