namespace Active_Shape_Model {
  partial class CFPSForm {
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
      this.label1 = new System.Windows.Forms.Label();
      this.fpsLimit = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9,9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36,13);
      this.label1.TabIndex = 0;
      this.label1.Text = "FPS : ";
      // 
      // fpsLimit
      // 
      this.fpsLimit.Location = new System.Drawing.Point(43,6);
      this.fpsLimit.Name = "fpsLimit";
      this.fpsLimit.Size = new System.Drawing.Size(101,20);
      this.fpsLimit.TabIndex = 1;
      this.fpsLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpsLimit_KeyDown);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(148,9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(20,13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Hz";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(12,32);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75,23);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "&OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(93,32);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75,23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // CFPSForm
      // 
      this.AcceptButton = this.btnOk;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(178,62);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.fpsLimit);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "CFPSForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Custom FPS";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.TextBox fpsLimit;
    public System.Windows.Forms.Button btnOk;
    public System.Windows.Forms.Button btnCancel;
  }
}