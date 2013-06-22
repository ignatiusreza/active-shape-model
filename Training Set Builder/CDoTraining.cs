using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Training_Set_Builder {
  public partial class CDoTrainingForm:Form {
    public enum TTrainingStats {
      STARTING=0,
      STARTED,
      STOPPED,
      MANUAL_ORIENTATION,
      CONVERGED,
      FINISHED
    };

    #region "Attributes"

    public TTrainingStats trainingStats;

    #endregion

    public CDoTrainingForm() {
      InitializeComponent();
    }

    private void textDelay_Leave(object sender,EventArgs e) {
      if(this.ActiveControl == this.btnClose) return;
      if(inputDelay.Text == "") return;

      try
      {
        int value = int.Parse(inputDelay.Text);
        if(value < 0)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Delay Value Has To Be A Valid Positif Interger",
          "Invalid Delay Value",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputDelay;
        return;
      }
    }

    private void b1_ValueChanged(object sender,EventArgs e) {
      trainingSetImage.Invalidate();
    }

    private void CDoTrainingForm_FormClosing(object sender,FormClosingEventArgs e) {
      e.Cancel = true;
      btnClose.PerformClick();
    }

    private void inputNormalSize_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnClose) return;

      try
      {
        int value = int.Parse(inputNormalSize.Text);
        if(value <= 0)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Normal Size Value Has To Be A Valid Positif Interger",
          "Invalid Normal Size",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputNormalSize;
        return;
      }
    }
  }
}