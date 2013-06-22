using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Active_Shape_Model {
  public partial class CAboutForm : Form {
    public CAboutForm() {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e) {
      this.Hide();
    }

    private void CAboutForm_FormClosing(object sender, FormClosingEventArgs e) {
      e.Cancel = true;
      this.Hide();
    }
  }
}