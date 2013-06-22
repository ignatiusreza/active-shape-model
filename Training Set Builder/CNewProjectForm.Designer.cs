namespace Training_Set_Builder {
  partial class CNewTrainingSetForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.inputClippingWidth = new System.Windows.Forms.TextBox();
      this.textWidth = new System.Windows.Forms.Label();
      this.inputClippingHeight = new System.Windows.Forms.TextBox();
      this.textHeight = new System.Windows.Forms.Label();
      this.textPixels = new System.Windows.Forms.Label();
      this.textPixels2 = new System.Windows.Forms.Label();
      this.groupClipping = new System.Windows.Forms.GroupBox();
      this.textName = new System.Windows.Forms.Label();
      this.inputName = new System.Windows.Forms.TextBox();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.textPath = new System.Windows.Forms.Label();
      this.inputPath = new System.Windows.Forms.TextBox();
      this.bevel = new System.Windows.Forms.Panel();
      this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.groupClipping.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(290,155);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75,23);
      this.btnOk.TabIndex = 5;
      this.btnOk.Text = "&OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(371,155);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75,23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // inputClippingWidth
      // 
      this.inputClippingWidth.Location = new System.Drawing.Point(62,19);
      this.inputClippingWidth.Name = "inputClippingWidth";
      this.inputClippingWidth.Size = new System.Drawing.Size(110,20);
      this.inputClippingWidth.TabIndex = 3;
      this.inputClippingWidth.Leave += new System.EventHandler(this.inputClippingWidth_Leave);
      // 
      // textWidth
      // 
      this.textWidth.AutoSize = true;
      this.textWidth.Location = new System.Drawing.Point(15,22);
      this.textWidth.Name = "textWidth";
      this.textWidth.Size = new System.Drawing.Size(41,13);
      this.textWidth.TabIndex = 1;
      this.textWidth.Text = "&Width :";
      // 
      // inputClippingHeight
      // 
      this.inputClippingHeight.Location = new System.Drawing.Point(62,45);
      this.inputClippingHeight.Name = "inputClippingHeight";
      this.inputClippingHeight.Size = new System.Drawing.Size(110,20);
      this.inputClippingHeight.TabIndex = 4;
      this.inputClippingHeight.WordWrap = false;
      this.inputClippingHeight.Leave += new System.EventHandler(this.inputClippingHeight_Leave);
      // 
      // textHeight
      // 
      this.textHeight.AutoSize = true;
      this.textHeight.Location = new System.Drawing.Point(15,48);
      this.textHeight.Name = "textHeight";
      this.textHeight.Size = new System.Drawing.Size(44,13);
      this.textHeight.TabIndex = 3;
      this.textHeight.Text = "&Height :";
      // 
      // textPixels
      // 
      this.textPixels.AutoSize = true;
      this.textPixels.Location = new System.Drawing.Point(178,22);
      this.textPixels.Name = "textPixels";
      this.textPixels.Size = new System.Drawing.Size(33,13);
      this.textPixels.TabIndex = 4;
      this.textPixels.Text = "pixels";
      // 
      // textPixels2
      // 
      this.textPixels2.AutoSize = true;
      this.textPixels2.Location = new System.Drawing.Point(178,48);
      this.textPixels2.Name = "textPixels2";
      this.textPixels2.Size = new System.Drawing.Size(33,13);
      this.textPixels2.TabIndex = 5;
      this.textPixels2.Text = "pixels";
      // 
      // groupClipping
      // 
      this.groupClipping.Controls.Add(this.textPixels2);
      this.groupClipping.Controls.Add(this.textPixels);
      this.groupClipping.Controls.Add(this.textHeight);
      this.groupClipping.Controls.Add(this.inputClippingHeight);
      this.groupClipping.Controls.Add(this.textWidth);
      this.groupClipping.Controls.Add(this.inputClippingWidth);
      this.groupClipping.Location = new System.Drawing.Point(59,61);
      this.groupClipping.Name = "groupClipping";
      this.groupClipping.Size = new System.Drawing.Size(217,75);
      this.groupClipping.TabIndex = 2;
      this.groupClipping.TabStop = false;
      this.groupClipping.Text = "Clipping Area";
      // 
      // textName
      // 
      this.textName.AutoSize = true;
      this.textName.Location = new System.Drawing.Point(9,13);
      this.textName.Name = "textName";
      this.textName.Size = new System.Drawing.Size(41,13);
      this.textName.TabIndex = 3;
      this.textName.Text = "Name :";
      // 
      // inputName
      // 
      this.inputName.Location = new System.Drawing.Point(59,10);
      this.inputName.Name = "inputName";
      this.inputName.Size = new System.Drawing.Size(306,20);
      this.inputName.TabIndex = 0;
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(370,34);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75,23);
      this.btnBrowse.TabIndex = 2;
      this.btnBrowse.Text = "&Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // textPath
      // 
      this.textPath.AutoSize = true;
      this.textPath.Location = new System.Drawing.Point(9,39);
      this.textPath.Name = "textPath";
      this.textPath.Size = new System.Drawing.Size(35,13);
      this.textPath.TabIndex = 6;
      this.textPath.Text = "Path :";
      // 
      // inputPath
      // 
      this.inputPath.Location = new System.Drawing.Point(59,36);
      this.inputPath.Name = "inputPath";
      this.inputPath.Size = new System.Drawing.Size(306,20);
      this.inputPath.TabIndex = 1;
      this.inputPath.Leave += new System.EventHandler(this.inputPath_Leave);
      // 
      // bevel
      // 
      this.bevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.bevel.Location = new System.Drawing.Point(12,147);
      this.bevel.Name = "bevel";
      this.bevel.Size = new System.Drawing.Size(433,4);
      this.bevel.TabIndex = 7;
      // 
      // CNewTrainingSetForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(457,187);
      this.Controls.Add(this.bevel);
      this.Controls.Add(this.inputPath);
      this.Controls.Add(this.textPath);
      this.Controls.Add(this.btnBrowse);
      this.Controls.Add(this.inputName);
      this.Controls.Add(this.textName);
      this.Controls.Add(this.groupClipping);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CNewTrainingSetForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "New Training Set";
      this.groupClipping.ResumeLayout(false);
      this.groupClipping.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label textWidth;
    private System.Windows.Forms.Label textHeight;
    private System.Windows.Forms.Label textPixels;
    private System.Windows.Forms.Label textPixels2;
    private System.Windows.Forms.GroupBox groupClipping;
    private System.Windows.Forms.Label textName;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Label textPath;
    private System.Windows.Forms.Panel bevel;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    public System.Windows.Forms.TextBox inputClippingWidth;
    public System.Windows.Forms.TextBox inputClippingHeight;
    public System.Windows.Forms.TextBox inputName;
    public System.Windows.Forms.TextBox inputPath;
  }
}