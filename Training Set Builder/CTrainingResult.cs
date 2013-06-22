using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Training_Set_Builder {
  public partial class CTrainingResult:Form {
    public CTrainingResult() {
      InitializeComponent();
    }

    private void btnOK_Click(object sender,EventArgs e) {
      this.Hide();
    }

    private void CTrainingResult_FormClosing(object sender,FormClosingEventArgs e) {
      e.Cancel = true;
      this.Hide();
    }
  }
}