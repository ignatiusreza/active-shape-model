namespace Training_Set_Builder
{
  partial class CDetailedForm
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.toolBox = new System.Windows.Forms.ToolStrip();
      this.textTools = new System.Windows.Forms.ToolStripLabel();
      this.btnPointerTool = new System.Windows.Forms.ToolStripButton();
      this.btnLineTool = new System.Windows.Forms.ToolStripButton();
      this.sampleVector = new System.Windows.Forms.ListView();
      this.colNo = new System.Windows.Forms.ColumnHeader();
      this.colX = new System.Windows.Forms.ColumnHeader();
      this.colY = new System.Windows.Forms.ColumnHeader();
      this.tableLayoutPanel1.SuspendLayout();
      this.toolBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.toolBox, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.sampleVector, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.53488F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(182, 324);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // toolBox
      // 
      this.toolBox.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textTools,
            this.btnPointerTool,
            this.btnLineTool});
      this.toolBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
      this.toolBox.Location = new System.Drawing.Point(0, 0);
      this.toolBox.Name = "toolBox";
      this.toolBox.Size = new System.Drawing.Size(182, 23);
      this.toolBox.TabIndex = 0;
      this.toolBox.Text = "ToolBox";
      // 
      // textTools
      // 
      this.textTools.Name = "textTools";
      this.textTools.Size = new System.Drawing.Size(39, 13);
      this.textTools.Text = "Tools :";
      // 
      // btnPointerTool
      // 
      this.btnPointerTool.Checked = true;
      this.btnPointerTool.CheckState = System.Windows.Forms.CheckState.Checked;
      this.btnPointerTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnPointerTool.Image = global::Training_Set_Builder.Properties.Resources.buttonPointer;
      this.btnPointerTool.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnPointerTool.Name = "btnPointerTool";
      this.btnPointerTool.Size = new System.Drawing.Size(23, 20);
      this.btnPointerTool.Text = "Pointer Tool";
      // 
      // btnLineTool
      // 
      this.btnLineTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnLineTool.Image = global::Training_Set_Builder.Properties.Resources.buttonLineTool;
      this.btnLineTool.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnLineTool.Name = "btnLineTool";
      this.btnLineTool.Size = new System.Drawing.Size(23, 20);
      this.btnLineTool.Text = "Line Tool";
      // 
      // sampleVector
      // 
      this.sampleVector.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.sampleVector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colX,
            this.colY});
      this.sampleVector.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sampleVector.FullRowSelect = true;
      this.sampleVector.GridLines = true;
      this.sampleVector.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.sampleVector.HideSelection = false;
      this.sampleVector.LabelEdit = true;
      this.sampleVector.Location = new System.Drawing.Point(3, 26);
      this.sampleVector.Name = "sampleVector";
      this.sampleVector.Size = new System.Drawing.Size(176, 295);
      this.sampleVector.TabIndex = 1;
      this.sampleVector.UseCompatibleStateImageBehavior = false;
      this.sampleVector.View = System.Windows.Forms.View.Details;
      // 
      // colNo
      // 
      this.colNo.Text = "No.";
      this.colNo.Width = 29;
      // 
      // colX
      // 
      this.colX.Text = "X";
      this.colX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.colX.Width = 65;
      // 
      // colY
      // 
      this.colY.Text = "Y";
      this.colY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.colY.Width = 65;
      // 
      // CDetailedForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(182, 324);
      this.Controls.Add(this.tableLayoutPanel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Location = new System.Drawing.Point(10, 10);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(200, 5000);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(150, 200);
      this.Name = "CDetailedForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Vector Data";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CDetailedForm_FormClosing);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.toolBox.ResumeLayout(false);
      this.toolBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.ToolStrip toolBox;
    private System.Windows.Forms.ToolStripLabel textTools;
    public System.Windows.Forms.ToolStripButton btnPointerTool;
    public System.Windows.Forms.ToolStripButton btnLineTool;
    public System.Windows.Forms.ListView sampleVector;
    public System.Windows.Forms.ColumnHeader colNo;
    public System.Windows.Forms.ColumnHeader colX;
    public System.Windows.Forms.ColumnHeader colY;

}
}