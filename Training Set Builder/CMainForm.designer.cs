namespace Training_Set_Builder {
  partial class CMainForm {
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
      this.mainMenu = new System.Windows.Forms.MenuStrip();
      this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.menuTrainingSet = new System.Windows.Forms.ToolStripMenuItem();
      this.menuTrainingSetStart = new System.Windows.Forms.ToolStripMenuItem();
      this.menuTrainingSetOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuWindow = new System.Windows.Forms.ToolStripMenuItem();
      this.menuWindowVectorData = new System.Windows.Forms.ToolStripMenuItem();
      this.menuWindowSampleList = new System.Windows.Forms.ToolStripMenuItem();
      this.toolBar = new System.Windows.Forms.ToolStrip();
      this.toolBarNew = new System.Windows.Forms.ToolStripButton();
      this.toolBarOpen = new System.Windows.Forms.ToolStripButton();
      this.toolBarSave = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.statusBar = new System.Windows.Forms.TableLayoutPanel();
      this.statusXY = new System.Windows.Forms.Label();
      this.statusLabel = new System.Windows.Forms.Label();
      this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.mainMenu.SuspendLayout();
      this.toolBar.SuspendLayout();
      this.statusBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenu
      // 
      this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTrainingSet,
            this.menuWindow,
            this.menuHelp});
      this.mainMenu.Location = new System.Drawing.Point(0, 0);
      this.mainMenu.Name = "mainMenu";
      this.mainMenu.Size = new System.Drawing.Size(592, 24);
      this.mainMenu.TabIndex = 0;
      this.mainMenu.Text = "Main Menu";
      // 
      // menuFile
      // 
      this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileClose,
            this.toolStripSeparator1,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.toolStripSeparator2,
            this.menuFileExit});
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new System.Drawing.Size(35, 20);
      this.menuFile.Text = "&File";
      this.menuFile.DropDownOpened += new System.EventHandler(this.menuFile_DropDownOpened);
      // 
      // menuFileNew
      // 
      this.menuFileNew.Name = "menuFileNew";
      this.menuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.menuFileNew.Size = new System.Drawing.Size(163, 22);
      this.menuFileNew.Text = "&New";
      this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
      // 
      // menuFileOpen
      // 
      this.menuFileOpen.Name = "menuFileOpen";
      this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.menuFileOpen.Size = new System.Drawing.Size(163, 22);
      this.menuFileOpen.Text = "&Open";
      this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
      // 
      // menuFileClose
      // 
      this.menuFileClose.Name = "menuFileClose";
      this.menuFileClose.Size = new System.Drawing.Size(163, 22);
      this.menuFileClose.Text = "&Close";
      this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
      // 
      // menuFileSave
      // 
      this.menuFileSave.Name = "menuFileSave";
      this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.menuFileSave.Size = new System.Drawing.Size(163, 22);
      this.menuFileSave.Text = "&Save";
      this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
      // 
      // menuFileSaveAs
      // 
      this.menuFileSaveAs.Name = "menuFileSaveAs";
      this.menuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F12)));
      this.menuFileSaveAs.Size = new System.Drawing.Size(163, 22);
      this.menuFileSaveAs.Text = "Save &As";
      this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
      // 
      // menuFileExit
      // 
      this.menuFileExit.Name = "menuFileExit";
      this.menuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.menuFileExit.Size = new System.Drawing.Size(163, 22);
      this.menuFileExit.Text = "E&xit";
      this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
      // 
      // menuTrainingSet
      // 
      this.menuTrainingSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTrainingSetStart,
            this.menuTrainingSetOpen});
      this.menuTrainingSet.Name = "menuTrainingSet";
      this.menuTrainingSet.Size = new System.Drawing.Size(76, 20);
      this.menuTrainingSet.Text = "&Training Set";
      // 
      // menuTrainingSetStart
      // 
      this.menuTrainingSetStart.Name = "menuTrainingSetStart";
      this.menuTrainingSetStart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
      this.menuTrainingSetStart.Size = new System.Drawing.Size(177, 22);
      this.menuTrainingSetStart.Text = "&Start Training";
      this.menuTrainingSetStart.Click += new System.EventHandler(this.menuTrainingSetStart_Click);
      // 
      // menuTrainingSetOpen
      // 
      this.menuTrainingSetOpen.Name = "menuTrainingSetOpen";
      this.menuTrainingSetOpen.Size = new System.Drawing.Size(177, 22);
      this.menuTrainingSetOpen.Text = "&Open Saved Result";
      this.menuTrainingSetOpen.Click += new System.EventHandler(this.menuTrainingSetOpen_Click);
      // 
      // menuWindow
      // 
      this.menuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWindowVectorData,
            this.menuWindowSampleList});
      this.menuWindow.Name = "menuWindow";
      this.menuWindow.Size = new System.Drawing.Size(57, 20);
      this.menuWindow.Text = "&Window";
      this.menuWindow.DropDownOpened += new System.EventHandler(this.menuWindow_DropDownOpened);
      // 
      // menuWindowVectorData
      // 
      this.menuWindowVectorData.Checked = true;
      this.menuWindowVectorData.CheckState = System.Windows.Forms.CheckState.Checked;
      this.menuWindowVectorData.Name = "menuWindowVectorData";
      this.menuWindowVectorData.Size = new System.Drawing.Size(152, 22);
      this.menuWindowVectorData.Text = "Vector &Data";
      this.menuWindowVectorData.Click += new System.EventHandler(this.menuWindowVectorData_Click);
      // 
      // menuWindowSampleList
      // 
      this.menuWindowSampleList.Checked = true;
      this.menuWindowSampleList.CheckState = System.Windows.Forms.CheckState.Checked;
      this.menuWindowSampleList.Name = "menuWindowSampleList";
      this.menuWindowSampleList.Size = new System.Drawing.Size(152, 22);
      this.menuWindowSampleList.Text = "Sample &List";
      this.menuWindowSampleList.Click += new System.EventHandler(this.menuWindowSampleList_Click);
      // 
      // toolBar
      // 
      this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarNew,
            this.toolBarOpen,
            this.toolBarSave,
            this.toolStripSeparator3});
      this.toolBar.Location = new System.Drawing.Point(0, 24);
      this.toolBar.Name = "toolBar";
      this.toolBar.Size = new System.Drawing.Size(592, 25);
      this.toolBar.TabIndex = 1;
      this.toolBar.Text = "Tool Bar";
      // 
      // toolBarNew
      // 
      this.toolBarNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolBarNew.Image = global::Training_Set_Builder.Properties.Resources.buttonNew;
      this.toolBarNew.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolBarNew.Name = "toolBarNew";
      this.toolBarNew.Size = new System.Drawing.Size(23, 22);
      this.toolBarNew.Text = "ToolBar New";
      this.toolBarNew.Click += new System.EventHandler(this.menuFileNew_Click);
      // 
      // toolBarOpen
      // 
      this.toolBarOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolBarOpen.Image = global::Training_Set_Builder.Properties.Resources.buttonOpen;
      this.toolBarOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolBarOpen.Name = "toolBarOpen";
      this.toolBarOpen.Size = new System.Drawing.Size(23, 22);
      this.toolBarOpen.Text = "ToolBar Open";
      this.toolBarOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
      // 
      // toolBarSave
      // 
      this.toolBarSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolBarSave.Image = global::Training_Set_Builder.Properties.Resources.buttonSave;
      this.toolBarSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolBarSave.Name = "toolBarSave";
      this.toolBarSave.Size = new System.Drawing.Size(23, 22);
      this.toolBarSave.Text = "ToolBar Save";
      this.toolBarSave.Click += new System.EventHandler(this.menuFileSave_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // statusBar
      // 
      this.statusBar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.statusBar.ColumnCount = 2;
      this.statusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.statusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 522F));
      this.statusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 371F));
      this.statusBar.Controls.Add(this.statusXY, 0, 0);
      this.statusBar.Controls.Add(this.statusLabel, 2, 0);
      this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.statusBar.Location = new System.Drawing.Point(0, 549);
      this.statusBar.Name = "statusBar";
      this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.statusBar.RowCount = 1;
      this.statusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.statusBar.Size = new System.Drawing.Size(592, 17);
      this.statusBar.TabIndex = 4;
      // 
      // statusXY
      // 
      this.statusXY.AutoSize = true;
      this.statusXY.Dock = System.Windows.Forms.DockStyle.Fill;
      this.statusXY.Location = new System.Drawing.Point(525, 1);
      this.statusXY.Name = "statusXY";
      this.statusXY.Size = new System.Drawing.Size(63, 15);
      this.statusXY.TabIndex = 2;
      this.statusXY.Text = "(X,Y) = (0,0)";
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = true;
      this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.statusLabel.Location = new System.Drawing.Point(2, 1);
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(516, 15);
      this.statusLabel.TabIndex = 0;
      this.statusLabel.Text = "Training Set Builder";
      this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // menuHelp
      // 
      this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
      this.menuHelp.Name = "menuHelp";
      this.menuHelp.Size = new System.Drawing.Size(40, 20);
      this.menuHelp.Text = "&Help";
      // 
      // menuHelpAbout
      // 
      this.menuHelpAbout.Name = "menuHelpAbout";
      this.menuHelpAbout.Size = new System.Drawing.Size(152, 22);
      this.menuHelpAbout.Text = "&About";
      this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
      // 
      // CMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(592, 566);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.toolBar);
      this.Controls.Add(this.mainMenu);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.mainMenu;
      this.Name = "CMainForm";
      this.Text = "Training Set Builder";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.SizeChanged += new System.EventHandler(this.CMainForm_SizeChanged);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMainForm_FormClosing);
      this.Load += new System.EventHandler(this.mainForm_Load);
      this.mainMenu.ResumeLayout(false);
      this.mainMenu.PerformLayout();
      this.toolBar.ResumeLayout(false);
      this.toolBar.PerformLayout();
      this.statusBar.ResumeLayout(false);
      this.statusBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip mainMenu;
    private System.Windows.Forms.ToolStrip toolBar;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem menuFileNew;
    private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
    private System.Windows.Forms.ToolStripMenuItem menuFileClose;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem menuFileSave;
    private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem menuFileExit;
    private System.Windows.Forms.ToolStripButton toolBarNew;
    private System.Windows.Forms.ToolStripButton toolBarOpen;
    private System.Windows.Forms.ToolStripButton toolBarSave;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.ToolStripMenuItem menuWindow;
    private System.Windows.Forms.ToolStripMenuItem menuWindowVectorData;
    private System.Windows.Forms.ToolStripMenuItem menuWindowSampleList;
    private System.Windows.Forms.ToolStripMenuItem menuTrainingSet;
    private System.Windows.Forms.ToolStripMenuItem menuTrainingSetStart;
    private System.Windows.Forms.TableLayoutPanel statusBar;
    private System.Windows.Forms.Label statusXY;
    public System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.ToolStripMenuItem menuTrainingSetOpen;
    private System.Windows.Forms.ToolStripMenuItem menuHelp;
    private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
  }
}

