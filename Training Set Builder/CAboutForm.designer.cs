namespace Training_Set_Builder {
  partial class CAboutForm {
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
      this.btnOk = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.textAbout = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(226, 105);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(77, 24);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "&Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.textAbout);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(297, 87);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Active Shape Model";
      // 
      // textAbout
      // 
      this.textAbout.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.textAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textAbout.Location = new System.Drawing.Point(11, 19);
      this.textAbout.Multiline = true;
      this.textAbout.Name = "textAbout";
      this.textAbout.Size = new System.Drawing.Size(276, 62);
      this.textAbout.TabIndex = 0;
      this.textAbout.Text = "Active Shape Model Implementation\r\nBased On The Method Made By Tim F. Cootes\r\n(c)" +
    " Ignatius Reza Lesmana / 2003730028\r\nFinal Project, Juli 2007";
      this.textAbout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // CAboutForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(320, 138);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "CAboutForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CAboutForm_FormClosing);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox textAbout;
  }
}