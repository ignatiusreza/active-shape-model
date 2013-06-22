namespace Training_Set_Builder
{
  partial class CSampleEditor
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
      this.controller = new System.Windows.Forms.ToolStrip();
      this.buttonFirstFrame = new System.Windows.Forms.ToolStripButton();
      this.buttonBackward = new System.Windows.Forms.ToolStripButton();
      this.numFrame = new System.Windows.Forms.ToolStripLabel();
      this.buttonForward = new System.Windows.Forms.ToolStripButton();
      this.buttonLastFrame = new System.Windows.Forms.ToolStripButton();
      this.hScrollBar = new System.Windows.Forms.HScrollBar();
      this.vScrollBar = new System.Windows.Forms.VScrollBar();
      this.trickPanel = new System.Windows.Forms.Panel();
      this.sample = new Training_Set_Builder.CDoubleBufferedPanel();
      this.controller.SuspendLayout();
      this.trickPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // controller
      // 
      this.controller.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.controller.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonFirstFrame,
            this.buttonBackward,
            this.numFrame,
            this.buttonForward,
            this.buttonLastFrame});
      this.controller.Location = new System.Drawing.Point(0,381);
      this.controller.Name = "controller";
      this.controller.Size = new System.Drawing.Size(478,25);
      this.controller.TabIndex = 10;
      this.controller.Text = "Controller";
      // 
      // buttonFirstFrame
      // 
      this.buttonFirstFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonFirstFrame.Image = global::Training_Set_Builder.Properties.Resources.buttongotofirst;
      this.buttonFirstFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonFirstFrame.Name = "buttonFirstFrame";
      this.buttonFirstFrame.Size = new System.Drawing.Size(23,22);
      this.buttonFirstFrame.Text = "First Sample";
      // 
      // buttonBackward
      // 
      this.buttonBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonBackward.Image = global::Training_Set_Builder.Properties.Resources.buttonbackward;
      this.buttonBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonBackward.Name = "buttonBackward";
      this.buttonBackward.Size = new System.Drawing.Size(23,22);
      this.buttonBackward.Text = "Previous Sample";
      // 
      // numFrame
      // 
      this.numFrame.Name = "numFrame";
      this.numFrame.Size = new System.Drawing.Size(35,22);
      this.numFrame.Text = "3 / 15";
      // 
      // buttonForward
      // 
      this.buttonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonForward.Image = global::Training_Set_Builder.Properties.Resources.buttonforward;
      this.buttonForward.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonForward.Name = "buttonForward";
      this.buttonForward.Size = new System.Drawing.Size(23,22);
      this.buttonForward.Text = "Next Sample";
      // 
      // buttonLastFrame
      // 
      this.buttonLastFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonLastFrame.Image = global::Training_Set_Builder.Properties.Resources.buttongotolast;
      this.buttonLastFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonLastFrame.Name = "buttonLastFrame";
      this.buttonLastFrame.Size = new System.Drawing.Size(23,22);
      this.buttonLastFrame.Text = "Last Sample";
      // 
      // hScrollBar
      // 
      this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.hScrollBar.LargeChange = 5;
      this.hScrollBar.Location = new System.Drawing.Point(0,361);
      this.hScrollBar.Maximum = 125;
      this.hScrollBar.Minimum = -125;
      this.hScrollBar.Name = "hScrollBar";
      this.hScrollBar.Size = new System.Drawing.Size(458,20);
      this.hScrollBar.SmallChange = 5;
      this.hScrollBar.TabIndex = 11;
      this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
      // 
      // vScrollBar
      // 
      this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.vScrollBar.LargeChange = 5;
      this.vScrollBar.Location = new System.Drawing.Point(458,0);
      this.vScrollBar.Minimum = -100;
      this.vScrollBar.Name = "vScrollBar";
      this.vScrollBar.Size = new System.Drawing.Size(20,381);
      this.vScrollBar.SmallChange = 5;
      this.vScrollBar.TabIndex = 12;
      this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
      // 
      // trickPanel
      // 
      this.trickPanel.Controls.Add(this.sample);
      this.trickPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trickPanel.Location = new System.Drawing.Point(0,0);
      this.trickPanel.Margin = new System.Windows.Forms.Padding(0);
      this.trickPanel.Name = "trickPanel";
      this.trickPanel.Size = new System.Drawing.Size(478,381);
      this.trickPanel.TabIndex = 13;
      // 
      // sample
      // 
      this.sample.BackColor = System.Drawing.Color.White;
      this.sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.sample.Location = new System.Drawing.Point(104,81);
      this.sample.Name = "sample";
      this.sample.Size = new System.Drawing.Size(250,200);
      this.sample.TabIndex = 0;
      this.sample.SizeChanged += new System.EventHandler(this.sample_SizeChanged);
      // 
      // CSampleEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(478,406);
      this.Controls.Add(this.hScrollBar);
      this.Controls.Add(this.vScrollBar);
      this.Controls.Add(this.trickPanel);
      this.Controls.Add(this.controller);
      this.MinimumSize = new System.Drawing.Size(200,200);
      this.Name = "CSampleEditor";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Sample Editor";
      this.SizeChanged += new System.EventHandler(this.CSampleEditor_SizeChanged);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CSampleEditor_FormClosing);
      this.controller.ResumeLayout(false);
      this.controller.PerformLayout();
      this.trickPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip controller;
    private System.Windows.Forms.Panel trickPanel;
    public CDoubleBufferedPanel sample;
    public System.Windows.Forms.ToolStripLabel numFrame;
    public System.Windows.Forms.ToolStripButton buttonFirstFrame;
    public System.Windows.Forms.ToolStripButton buttonBackward;
    public System.Windows.Forms.ToolStripButton buttonForward;
    public System.Windows.Forms.ToolStripButton buttonLastFrame;
    public System.Windows.Forms.HScrollBar hScrollBar;
    public System.Windows.Forms.VScrollBar vScrollBar;
  }
}