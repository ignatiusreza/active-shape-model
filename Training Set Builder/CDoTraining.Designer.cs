namespace Training_Set_Builder {
  partial class CDoTrainingForm {
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Initilize Training Set", 0, 0);
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Realign Each Sample");
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Calculate Mean Sample");
      System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Normalize Mean Sample");
      System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Is Converge?");
      System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Aligning The Training Set", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
      System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Manual Orientation");
      System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Capturing The Statistics", 0, 0);
      System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Principle Component Analysis", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6,
            treeNode7,
            treeNode8});
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDoTrainingForm));
      this.trainingSetPanel = new System.Windows.Forms.Panel();
      this.trainingSetImage = new Training_Set_Builder.CDoubleBufferedPanel();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.treeProgress = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.inputDelay = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.b5 = new System.Windows.Forms.TrackBar();
      this.b4 = new System.Windows.Forms.TrackBar();
      this.b3 = new System.Windows.Forms.TrackBar();
      this.b2 = new System.Windows.Forms.TrackBar();
      this.b1 = new System.Windows.Forms.TrackBar();
      this.btnSavePDM = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.inputNormalSize = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.trainingSetPanel.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.b5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.b4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.b3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.b2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.b1)).BeginInit();
      this.SuspendLayout();
      // 
      // trainingSetPanel
      // 
      this.trainingSetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.trainingSetPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.trainingSetPanel.Controls.Add(this.trainingSetImage);
      this.trainingSetPanel.Location = new System.Drawing.Point(220, 12);
      this.trainingSetPanel.Name = "trainingSetPanel";
      this.trainingSetPanel.Size = new System.Drawing.Size(400, 340);
      this.trainingSetPanel.TabIndex = 0;
      // 
      // trainingSetImage
      // 
      this.trainingSetImage.BackColor = System.Drawing.Color.White;
      this.trainingSetImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trainingSetImage.Location = new System.Drawing.Point(0, 0);
      this.trainingSetImage.Name = "trainingSetImage";
      this.trainingSetImage.Size = new System.Drawing.Size(396, 336);
      this.trainingSetImage.TabIndex = 0;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(748, 292);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 7;
      this.btnClose.Text = "&Close";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // btnStart
      // 
      this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnStart.Location = new System.Drawing.Point(667, 292);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 6;
      this.btnStart.Text = "&Start";
      this.btnStart.UseVisualStyleBackColor = true;
      // 
      // treeProgress
      // 
      this.treeProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.treeProgress.ImageIndex = 0;
      this.treeProgress.ImageList = this.imageList1;
      this.treeProgress.Location = new System.Drawing.Point(11, 64);
      this.treeProgress.Name = "treeProgress";
      treeNode1.ImageIndex = 0;
      treeNode1.Name = "nodeInitTs";
      treeNode1.SelectedImageIndex = 0;
      treeNode1.Text = "Initilize Training Set";
      treeNode1.ToolTipText = "Initialize All Variable Used In Training To A Default Value";
      treeNode2.Name = "nodeRealignTS";
      treeNode2.Text = "Realign Each Sample";
      treeNode3.Name = "nodeCalcMean";
      treeNode3.Text = "Calculate Mean Sample";
      treeNode4.Name = "nodeNormalizeMean";
      treeNode4.Text = "Normalize Mean Sample";
      treeNode5.Name = "nodeIsConverge";
      treeNode5.Text = "Is Converge?";
      treeNode6.ImageIndex = 0;
      treeNode6.Name = "nodeAlignTS";
      treeNode6.SelectedImageIndex = 0;
      treeNode6.Text = "Aligning The Training Set";
      treeNode6.ToolTipText = "Aligning All Sampe In Training Set";
      treeNode7.Name = "nodeManualOrientation";
      treeNode7.Text = "Manual Orientation";
      treeNode7.ToolTipText = "Rotate The Mean Sample To A Desired Orientation";
      treeNode8.ImageIndex = 0;
      treeNode8.Name = "nodeCaptureStatistics";
      treeNode8.SelectedImageIndex = 0;
      treeNode8.Text = "Capturing The Statistics";
      treeNode8.ToolTipText = "Get The Statistics Of A Set Of Aligned Sample";
      treeNode9.ImageIndex = 0;
      treeNode9.Name = "nodePCA";
      treeNode9.SelectedImageIndex = 0;
      treeNode9.Text = "Principle Component Analysis";
      this.treeProgress.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
      this.treeProgress.SelectedImageIndex = 0;
      this.treeProgress.Size = new System.Drawing.Size(200, 286);
      this.treeProgress.TabIndex = 4;
      this.treeProgress.TabStop = false;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
      this.imageList1.Images.SetKeyName(0, "cross.bmp");
      this.imageList1.Images.SetKeyName(1, "checklist.bmp");
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(84, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Training Delay : ";
      // 
      // inputDelay
      // 
      this.inputDelay.Location = new System.Drawing.Point(92, 12);
      this.inputDelay.Name = "inputDelay";
      this.inputDelay.Size = new System.Drawing.Size(93, 20);
      this.inputDelay.TabIndex = 1;
      this.inputDelay.Text = "0";
      this.inputDelay.Leave += new System.EventHandler(this.textDelay_Leave);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.b5);
      this.groupBox1.Controls.Add(this.b4);
      this.groupBox1.Controls.Add(this.b3);
      this.groupBox1.Controls.Add(this.b2);
      this.groupBox1.Controls.Add(this.b1);
      this.groupBox1.Location = new System.Drawing.Point(626, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(197, 274);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Top Largest Mode";
      // 
      // b5
      // 
      this.b5.LargeChange = 50;
      this.b5.Location = new System.Drawing.Point(6, 223);
      this.b5.Maximum = 3000;
      this.b5.Minimum = -3000;
      this.b5.Name = "b5";
      this.b5.Size = new System.Drawing.Size(188, 45);
      this.b5.SmallChange = 10;
      this.b5.TabIndex = 4;
      this.b5.TickFrequency = 1000;
      this.b5.ValueChanged += new System.EventHandler(this.b1_ValueChanged);
      // 
      // b4
      // 
      this.b4.LargeChange = 50;
      this.b4.Location = new System.Drawing.Point(6, 172);
      this.b4.Maximum = 3000;
      this.b4.Minimum = -3000;
      this.b4.Name = "b4";
      this.b4.Size = new System.Drawing.Size(188, 45);
      this.b4.SmallChange = 10;
      this.b4.TabIndex = 3;
      this.b4.TickFrequency = 1000;
      this.b4.ValueChanged += new System.EventHandler(this.b1_ValueChanged);
      // 
      // b3
      // 
      this.b3.LargeChange = 50;
      this.b3.Location = new System.Drawing.Point(6, 121);
      this.b3.Maximum = 3000;
      this.b3.Minimum = -3000;
      this.b3.Name = "b3";
      this.b3.Size = new System.Drawing.Size(188, 45);
      this.b3.SmallChange = 10;
      this.b3.TabIndex = 2;
      this.b3.TickFrequency = 1000;
      this.b3.ValueChanged += new System.EventHandler(this.b1_ValueChanged);
      // 
      // b2
      // 
      this.b2.LargeChange = 50;
      this.b2.Location = new System.Drawing.Point(6, 70);
      this.b2.Maximum = 3000;
      this.b2.Minimum = -3000;
      this.b2.Name = "b2";
      this.b2.Size = new System.Drawing.Size(188, 45);
      this.b2.SmallChange = 10;
      this.b2.TabIndex = 1;
      this.b2.TickFrequency = 1000;
      this.b2.ValueChanged += new System.EventHandler(this.b1_ValueChanged);
      // 
      // b1
      // 
      this.b1.LargeChange = 50;
      this.b1.Location = new System.Drawing.Point(6, 19);
      this.b1.Maximum = 3000;
      this.b1.Minimum = -3000;
      this.b1.Name = "b1";
      this.b1.Size = new System.Drawing.Size(188, 45);
      this.b1.SmallChange = 10;
      this.b1.TabIndex = 0;
      this.b1.TickFrequency = 1000;
      this.b1.ValueChanged += new System.EventHandler(this.b1_ValueChanged);
      // 
      // btnSavePDM
      // 
      this.btnSavePDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSavePDM.Location = new System.Drawing.Point(708, 321);
      this.btnSavePDM.Name = "btnSavePDM";
      this.btnSavePDM.Size = new System.Drawing.Size(115, 23);
      this.btnSavePDM.TabIndex = 8;
      this.btnSavePDM.Text = "Save Training Result";
      this.btnSavePDM.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(191, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(20, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "ms";
      // 
      // inputNormalSize
      // 
      this.inputNormalSize.Location = new System.Drawing.Point(92, 38);
      this.inputNormalSize.Name = "inputNormalSize";
      this.inputNormalSize.Size = new System.Drawing.Size(93, 20);
      this.inputNormalSize.TabIndex = 10;
      this.inputNormalSize.Text = "500";
      this.inputNormalSize.Leave += new System.EventHandler(this.inputNormalSize_Leave);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(11, 41);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(70, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "Target Size : ";
      // 
      // CDoTrainingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(832, 370);
      this.Controls.Add(this.inputNormalSize);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnSavePDM);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.inputDelay);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.treeProgress);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.trainingSetPanel);
      this.MinimumSize = new System.Drawing.Size(750, 400);
      this.Name = "CDoTrainingForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Sample Training";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CDoTrainingForm_FormClosing);
      this.trainingSetPanel.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.b5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.b4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.b3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.b2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.b1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.Panel trainingSetPanel;
    public System.Windows.Forms.TreeView treeProgress;
    private System.Windows.Forms.ImageList imageList1;
    public CDoubleBufferedPanel trainingSetImage;
    public System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    public System.Windows.Forms.TrackBar b5;
    public System.Windows.Forms.TrackBar b4;
    public System.Windows.Forms.TrackBar b3;
    public System.Windows.Forms.TrackBar b2;
    public System.Windows.Forms.TrackBar b1;
    public System.Windows.Forms.Button btnClose;
    public System.Windows.Forms.Button btnSavePDM;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.TextBox inputDelay;
    public System.Windows.Forms.TextBox inputNormalSize;
    private System.Windows.Forms.Label label3;
  }
}