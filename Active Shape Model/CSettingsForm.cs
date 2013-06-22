using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Active_Shape_Model {
  public partial class CSettingsForm :Form {
    public CSettingsForm() {
      InitializeComponent();
    }

    private void inputFreedom_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputFreedom.Text == "") return;

      int maxFreedom = int.Parse(textValuePointNum.Text);
      try
      {
        int value = int.Parse(inputFreedom.Text);
        if(value < 0 || value > maxFreedom)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Variation Mode Value Has To Be A Valid Integer Between 0 and " + maxFreedom.ToString(),
          "Invalid Variation Mode",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputFreedom;
      }
    }

    private void inputCX_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputCX.Text == "") return;

      try
      {
        int value = int.Parse(inputCX.Text);
      }catch(Exception) {
        MessageBox.Show(
          "Initial Position Value Has To Be A Valid Integer",
          "Invalid Initial Position",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputCX;
      }
    }

    private void inputCY_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputCY.Text == "") return;

      try
      {
        int value = int.Parse(inputCY.Text);
      }catch(Exception) {
        MessageBox.Show(
          "Initial Position Value Has To Be A Valid Integer",
          "Invalid Initial Position",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputCY;
      }
    }

    private void inputThreshold_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputThreshold.Text == "") return;

      try
      {
        int value = int.Parse(inputThreshold.Text);
        if(value < 0 || value > 255)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Edge Threshold Value Has To Be A Valid Integer Between 0 and 255",
          "Invalid Edge Threshold",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputThreshold;
      }
    }

    private void inputLimit_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputLimit.Text == "") return;

      try
      {
        int value = int.Parse(inputLimit.Text);
        if(value < 5 || value > 100)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Range of View Value Has To Be A Valid Integer Between 0 and 100",
          "Invalid Range of View",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputLimit;
      }
    }

    private void inputMaxStep_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputMaxStep.Text == "") return;

      try
      {
        int value = int.Parse(inputMaxStep.Text);
        if(value < 0)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Maximum Step Value Has To Be A Valid Positif Integer",
          "Invalid Maximum Step",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputMaxStep;
      }
    }

    private void inputIterateEvery_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputIterateEvery.Text == "") return;

      try
      {
        int value = int.Parse(inputIterateEvery.Text);
      }catch(Exception) {
        MessageBox.Show(
          "Iteration Step Value Has To Be A Valid Integer",
          "Invalid Value",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputIterateEvery;
      }
    }

    private void inputIterationDelay_Leave(object sender, EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputIterationDelay.Text == "") return;

      try
      {
        int value = int.Parse(inputIterationDelay.Text);
      }catch(Exception) {
        MessageBox.Show(
          "Iteration Delay Value Has To Be A Valid Integer",
          "Invalid Iteration Delay",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputIterationDelay;
      }
    }

    private void btnOk_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.OK;
      this.Hide();
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Hide();
    }
  }
}