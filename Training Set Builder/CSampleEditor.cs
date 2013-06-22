using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Training_Set_Builder
{
  public partial class CSampleEditor : Form {
    public CSampleEditor() {
      InitializeComponent();
    }

    public void vScrollBar_Scroll(object sender, ScrollEventArgs e) {
      int Y = (int)(trickPanel.Height - sample.Height) / 2;
      Point newLocation = new Point(sample.Location.X,Y-vScrollBar.Value);
      sample.Location = newLocation;
    }

    public void hScrollBar_Scroll(object sender, ScrollEventArgs e) {
      int X = (int)(trickPanel.Width - sample.Width) / 2;
      Point newLocation = new Point(X - hScrollBar.Value, sample.Location.Y);
      sample.Location = newLocation;
    }

    private void sample_SizeChanged(object sender, EventArgs e) {
      vScrollBar.Maximum = sample.Height/2;
      vScrollBar.Minimum = -vScrollBar.Maximum;
      hScrollBar.Maximum = sample.Width/2;
      hScrollBar.Minimum = -hScrollBar.Maximum;
    }

    private void CSampleEditor_SizeChanged(object sender,EventArgs e) {
      vScrollBar_Scroll(null,null);
      hScrollBar_Scroll(null, null);
    }

    private void CSampleEditor_FormClosing(object sender,FormClosingEventArgs e) {
      e.Cancel = true;
      this.WindowState = FormWindowState.Normal;
      this.Hide();
    }
  }
}