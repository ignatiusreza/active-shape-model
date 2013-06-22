using System.Windows.Forms;

namespace Training_Set_Builder {
  partial class CClippingForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnHandTool = new System.Windows.Forms.ToolStripButton();
      this.btnZoomTool = new System.Windows.Forms.ToolStripButton();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.clippedPanel = new Training_Set_Builder.CDoubleBufferedPanel();
      this.transparencyPanel = new Training_Set_Builder.CDoubleBufferedPanel();
      this.toolStrip1.SuspendLayout();
      this.clippedPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHandTool,
            this.btnZoomTool});
      this.toolStrip1.Location = new System.Drawing.Point(0,0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(722,25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolBox";
      // 
      // btnHandTool
      // 
      this.btnHandTool.Checked = true;
      this.btnHandTool.CheckState = System.Windows.Forms.CheckState.Checked;
      this.btnHandTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnHandTool.Image = global::Training_Set_Builder.Properties.Resources.pointerToolsHand;
      this.btnHandTool.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnHandTool.Name = "btnHandTool";
      this.btnHandTool.Size = new System.Drawing.Size(23,22);
      this.btnHandTool.Text = "Hand Tool";
      this.btnHandTool.Click += new System.EventHandler(this.btnHandTool_Click);
      // 
      // btnZoomTool
      // 
      this.btnZoomTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnZoomTool.Image = global::Training_Set_Builder.Properties.Resources.pointerToolsZoom;
      this.btnZoomTool.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnZoomTool.Name = "btnZoomTool";
      this.btnZoomTool.Size = new System.Drawing.Size(23,22);
      this.btnZoomTool.Text = "Zoom Tool";
      this.btnZoomTool.Click += new System.EventHandler(this.btnZoomTool_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(637,570);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75,23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(556,570);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75,23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "&OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // clippedPanel
      // 
      this.clippedPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.clippedPanel.Controls.Add(this.transparencyPanel);
      this.clippedPanel.Location = new System.Drawing.Point(10,35);
      this.clippedPanel.Name = "clippedPanel";
      this.clippedPanel.Size = new System.Drawing.Size(704,529);
      this.clippedPanel.TabIndex = 4;
      this.clippedPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.clippedPanel_Paint);
      // 
      // transparencyPanel
      // 
      this.transparencyPanel.BackColor = System.Drawing.Color.Transparent;
      this.transparencyPanel.Location = new System.Drawing.Point(0,0);
      this.transparencyPanel.Margin = new System.Windows.Forms.Padding(0);
      this.transparencyPanel.Name = "transparencyPanel";
      this.transparencyPanel.Size = new System.Drawing.Size(700,525);
      this.transparencyPanel.TabIndex = 5;
      this.transparencyPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.transparencyPanel_MouseDown);
      this.transparencyPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.transparencyPanel_MouseMove);
      this.transparencyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.transparencyPanel_Paint);
      this.transparencyPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.transparencyPanel_MouseUp);
      // 
      // CClippingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(722,603);
      this.Controls.Add(this.clippedPanel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.toolStrip1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CClippingForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Image Clipping";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.clippedPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnHandTool;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.ToolStripButton btnZoomTool;
    public CDoubleBufferedPanel clippedPanel;
    public CDoubleBufferedPanel transparencyPanel;
  }
}