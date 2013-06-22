using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Training_Set_Builder {
  public partial class CSampleListForm : Form {
    public CSampleListForm() {
      InitializeComponent();
    }

    private void CSampleListForm_FormClosing(object sender,FormClosingEventArgs e) {
      e.Cancel = true;
      this.Hide();
    }
  }
}