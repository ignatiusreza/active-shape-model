namespace ASMLibrary {
  partial class CStatusForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if(disposing && (components != null)) {
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
      this.statusProgress = new System.Windows.Forms.ProgressBar();
      this.statusLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // statusProgress
      // 
      this.statusProgress.Location = new System.Drawing.Point(15,33);
      this.statusProgress.Name = "statusProgress";
      this.statusProgress.Size = new System.Drawing.Size(346,23);
      this.statusProgress.TabIndex = 0;
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = true;
      this.statusLabel.Location = new System.Drawing.Point(12,9);
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(61,13);
      this.statusLabel.TabIndex = 1;
      this.statusLabel.Text = "statusLabel";
      // 
      // CStatusForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(373,68);
      this.ControlBox = false;
      this.Controls.Add(this.statusLabel);
      this.Controls.Add(this.statusProgress);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "CStatusForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Opening Training Set";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.ProgressBar statusProgress;
    public System.Windows.Forms.Label statusLabel;

  }
}