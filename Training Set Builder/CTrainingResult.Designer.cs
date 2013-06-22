namespace Training_Set_Builder {
  partial class CTrainingResult {
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.listAlignment = new System.Windows.Forms.ListView();
      this.colNo = new System.Windows.Forms.ColumnHeader();
      this.colDistance = new System.Windows.Forms.ColumnHeader();
      this.colTime = new System.Windows.Forms.ColumnHeader();
      this.textNumberOfAlignment = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textPCATime = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.textNumberOfAlignment);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.listAlignment);
      this.groupBox1.Controls.Add(this.textPCATime);
      this.groupBox1.Location = new System.Drawing.Point(12,12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(307,171);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Summary";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6,16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(113,13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Number Of Alignment :";
      // 
      // listAlignment
      // 
      this.listAlignment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colDistance,
            this.colTime});
      this.listAlignment.FullRowSelect = true;
      this.listAlignment.GridLines = true;
      this.listAlignment.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listAlignment.Location = new System.Drawing.Point(6,32);
      this.listAlignment.Name = "listAlignment";
      this.listAlignment.Size = new System.Drawing.Size(295,133);
      this.listAlignment.TabIndex = 2;
      this.listAlignment.UseCompatibleStateImageBehavior = false;
      this.listAlignment.View = System.Windows.Forms.View.Details;
      // 
      // colNo
      // 
      this.colNo.Text = "No.";
      this.colNo.Width = 36;
      // 
      // colDistance
      // 
      this.colDistance.Text = "Distance From Previous";
      this.colDistance.Width = 142;
      // 
      // colTime
      // 
      this.colTime.Text = "Time (in second)";
      this.colTime.Width = 93;
      // 
      // textNumberOfAlignment
      // 
      this.textNumberOfAlignment.AutoSize = true;
      this.textNumberOfAlignment.Location = new System.Drawing.Point(115,16);
      this.textNumberOfAlignment.Name = "textNumberOfAlignment";
      this.textNumberOfAlignment.Size = new System.Drawing.Size(0,13);
      this.textNumberOfAlignment.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(193,16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63,13);
      this.label2.TabIndex = 3;
      this.label2.Text = "PCA Time : ";
      // 
      // textPCATime
      // 
      this.textPCATime.Location = new System.Drawing.Point(252,16);
      this.textPCATime.Name = "textPCATime";
      this.textPCATime.Size = new System.Drawing.Size(31,13);
      this.textPCATime.TabIndex = 5;
      this.textPCATime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(289,16);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(12,13);
      this.label3.TabIndex = 6;
      this.label3.Text = "s";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(244,189);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75,23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "&OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // CTrainingResult
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(331,220);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "CTrainingResult";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Training Result";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CTrainingResult_FormClosing);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ColumnHeader colNo;
    private System.Windows.Forms.ColumnHeader colDistance;
    private System.Windows.Forms.ColumnHeader colTime;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnOK;
    public System.Windows.Forms.Label textNumberOfAlignment;
    public System.Windows.Forms.ListView listAlignment;
    public System.Windows.Forms.Label textPCATime;

  }
}