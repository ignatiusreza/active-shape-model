using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using ASMLibrary;

namespace Training_Set_Builder {
  public partial class CNewTrainingSetForm : Form {
    public CNewTrainingSetForm() {
        InitializeComponent();
    }

    private void btnBrowse_Click(object sender,EventArgs e) {
      folderBrowserDialog.SelectedPath = inputPath.Text;
      DialogResult res = folderBrowserDialog.ShowDialog();

      if(res == DialogResult.OK)
        inputPath.Text = folderBrowserDialog.SelectedPath;
    }

    private void btnOk_Click(object sender, EventArgs e) {
      bool isEmpty = (this.inputName.Text == "") || 
                     (this.inputPath.Text == "") || 
                     (this.inputClippingHeight.Text == "") || 
                     (this.inputClippingWidth.Text == "");
      bool createDir = false;

      if(isEmpty) {
        MessageBox.Show("All Fields Must Not Be Empty!","Empty Fields!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        return;
      }

      this.inputPath.Text += "\\";

      if(!Directory.Exists(this.inputPath.Text)) {
        DialogResult res = MessageBox.Show(
                             "Create Destination Folder?",
                             "Folder Not Exist!",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
        if(res == DialogResult.Yes)
          createDir = true;
        else {
          this.ActiveControl = this.inputPath;
          return;
        }
      }
      if(File.Exists(this.inputPath.Text + this.inputName.Text + ".ts") ||
        Directory.Exists(this.inputPath.Text + this.inputName.Text + "_data")) {
        DialogResult res = MessageBox.Show(
                             "Destination Folder Or Training Set Already Exist!\n" +
                             "Please Select A Different Folder or Training Set Name",
                             "Folder Or Training Set Already Exist!",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputName;
        return;
      }
      if(createDir) {
        try
        {
          Directory.CreateDirectory(this.inputPath.Text);
        }catch(Exception exc) {
          MessageBox.Show("Invalid Path : " + exc.Message);
          return;
        }
      }
      
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void inputPath_Leave(object sender,EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputPath.Text == "") return;
      inputPath.Text = Path.GetFullPath(inputPath.Text);
    }

    private void inputClippingWidth_Leave(object sender,EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputClippingWidth.Text == "") return;

      try
      {
        int value = int.Parse(inputClippingWidth.Text);
        if(value < 50 || value > CSettings.MAXCLIPSIZE.Width)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Width Value Has To Be A Valid Integer Between 50 and " + CSettings.MAXCLIPSIZE.Width.ToString(),
          "Invalid Width",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputClippingWidth;
      }
    }

    private void inputClippingHeight_Leave(object sender,EventArgs e) {
      if(this.ActiveControl == this.btnCancel) return;
      if(inputClippingHeight.Text == "") return;

      try
      {
        int value = int.Parse(inputClippingHeight.Text);
        if(value < 50 || value > CSettings.MAXCLIPSIZE.Height)
          throw new Exception();
      }catch(Exception) {
        MessageBox.Show(
          "Height Value Has To Be A Valid Integer Between 50 and " + CSettings.MAXCLIPSIZE.Height.ToString(),
          "Invalid Height",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        this.ActiveControl = this.inputClippingHeight;
        return;
      }
    }

    private void splitFullPath(string fullPath,out string path,out string filename) {
      int idx = fullPath.LastIndexOf('\\');
      int idx2 = fullPath.LastIndexOf('/');
      if(idx < idx2) idx = idx2;
      if(idx != -1) path = fullPath.Substring(0,idx);
      else path = "";
      path += "\\";
      filename = fullPath.Substring(idx+1);
    }

    public void clear() {
      this.inputClippingHeight.Text = "";
      this.inputClippingWidth.Text  = "";
      this.inputName.Text           = "";
      this.inputPath.Text           = "";
    }
  }
}