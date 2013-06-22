namespace Active_Shape_Model
{
  partial class CMainForm
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
      this.mainMenu = new System.Windows.Forms.MenuStrip();
      this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileOpenFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileOpenDevice = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPlayback = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPlaybackPlayPause = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPlaybackStop = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.menuPlaybackForward = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPlaybackBackward = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPlaybackGoToFirst = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPlaybackGoToLast = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsPDM = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsEDM = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsEDMNone = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsEDMHomogenity = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsEDMDifference = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsEDMSobel = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsEDMCanny = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPS = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPSDefault = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPSNoLimit = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPSIVTCFilm = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPSFilm = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPSPal = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPSNTSC = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsFPSCustom = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSettingsOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.statusBar = new System.Windows.Forms.StatusStrip();
      this.statusInputType = new System.Windows.Forms.ToolStripStatusLabel();
      this.videoStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.numFrame = new System.Windows.Forms.ToolStripStatusLabel();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.videoController = new System.Windows.Forms.ToolStrip();
      this.buttonPlay = new System.Windows.Forms.ToolStripButton();
      this.buttonPause = new System.Windows.Forms.ToolStripButton();
      this.buttonStop = new System.Windows.Forms.ToolStripButton();
      this.buttonGoToFirst = new System.Windows.Forms.ToolStripButton();
      this.buttonBackward = new System.Windows.Forms.ToolStripButton();
      this.buttonForward = new System.Windows.Forms.ToolStripButton();
      this.buttonGoToLast = new System.Windows.Forms.ToolStripButton();
      this.videoProgress = new EConTech.Windows.MACUI.MACTrackBar();
      this.cameraWindow = new InputSource.CCameraWindow();
      this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.mainMenu.SuspendLayout();
      this.statusBar.SuspendLayout();
      this.videoController.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenu
      // 
      this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuPlayback,
            this.menuSettings,
            this.menuHelp});
      this.mainMenu.Location = new System.Drawing.Point(0, 0);
      this.mainMenu.Name = "mainMenu";
      this.mainMenu.Size = new System.Drawing.Size(392, 24);
      this.mainMenu.TabIndex = 0;
      this.mainMenu.Text = "Main Menu";
      // 
      // menuFile
      // 
      this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpenFile,
            this.menuFileOpenDevice,
            this.menuFileClose,
            this.toolStripSeparator1,
            this.menuFileExit});
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new System.Drawing.Size(35, 20);
      this.menuFile.Text = "&File";
      // 
      // menuFileOpenFile
      // 
      this.menuFileOpenFile.Name = "menuFileOpenFile";
      this.menuFileOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.menuFileOpenFile.Size = new System.Drawing.Size(186, 22);
      this.menuFileOpenFile.Text = "&Open File...";
      this.menuFileOpenFile.Click += new System.EventHandler(this.menuFileOpenFile_Click);
      // 
      // menuFileOpenDevice
      // 
      this.menuFileOpenDevice.Name = "menuFileOpenDevice";
      this.menuFileOpenDevice.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
      this.menuFileOpenDevice.Size = new System.Drawing.Size(186, 22);
      this.menuFileOpenDevice.Text = "Open &Device...";
      this.menuFileOpenDevice.Click += new System.EventHandler(this.menuFileOpenDevice_Click);
      // 
      // menuFileClose
      // 
      this.menuFileClose.Name = "menuFileClose";
      this.menuFileClose.Size = new System.Drawing.Size(186, 22);
      this.menuFileClose.Text = "&Close";
      this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
      // 
      // menuFileExit
      // 
      this.menuFileExit.Name = "menuFileExit";
      this.menuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.menuFileExit.Size = new System.Drawing.Size(186, 22);
      this.menuFileExit.Text = "E&xit";
      this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
      // 
      // menuPlayback
      // 
      this.menuPlayback.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPlaybackPlayPause,
            this.menuPlaybackStop,
            this.toolStripSeparator3,
            this.menuPlaybackForward,
            this.menuPlaybackBackward,
            this.menuPlaybackGoToFirst,
            this.menuPlaybackGoToLast});
      this.menuPlayback.Name = "menuPlayback";
      this.menuPlayback.Size = new System.Drawing.Size(61, 20);
      this.menuPlayback.Text = "&Playback";
      this.menuPlayback.DropDownOpened += new System.EventHandler(this.menuPlayback_DropDownOpened);
      // 
      // menuPlaybackPlayPause
      // 
      this.menuPlaybackPlayPause.Name = "menuPlaybackPlayPause";
      this.menuPlaybackPlayPause.ShortcutKeyDisplayString = "Space";
      this.menuPlaybackPlayPause.Size = new System.Drawing.Size(163, 22);
      this.menuPlaybackPlayPause.Text = "&Play/Pause";
      this.menuPlaybackPlayPause.Click += new System.EventHandler(this.menuPlaybackPlayPause_Click);
      // 
      // menuPlaybackStop
      // 
      this.menuPlaybackStop.Name = "menuPlaybackStop";
      this.menuPlaybackStop.Size = new System.Drawing.Size(163, 22);
      this.menuPlaybackStop.Text = "&Stop";
      this.menuPlaybackStop.Click += new System.EventHandler(this.buttonStop_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
      // 
      // menuPlaybackForward
      // 
      this.menuPlaybackForward.Name = "menuPlaybackForward";
      this.menuPlaybackForward.ShortcutKeyDisplayString = "";
      this.menuPlaybackForward.Size = new System.Drawing.Size(163, 22);
      this.menuPlaybackForward.Text = "Skip &Forward";
      this.menuPlaybackForward.Click += new System.EventHandler(this.buttonForward_Click);
      // 
      // menuPlaybackBackward
      // 
      this.menuPlaybackBackward.Name = "menuPlaybackBackward";
      this.menuPlaybackBackward.ShortcutKeyDisplayString = "";
      this.menuPlaybackBackward.Size = new System.Drawing.Size(163, 22);
      this.menuPlaybackBackward.Text = "Skip &Backward";
      this.menuPlaybackBackward.Click += new System.EventHandler(this.buttonBackward_Click);
      // 
      // menuPlaybackGoToFirst
      // 
      this.menuPlaybackGoToFirst.Name = "menuPlaybackGoToFirst";
      this.menuPlaybackGoToFirst.ShortcutKeyDisplayString = "";
      this.menuPlaybackGoToFirst.Size = new System.Drawing.Size(163, 22);
      this.menuPlaybackGoToFirst.Text = "Go To First Frame";
      this.menuPlaybackGoToFirst.Click += new System.EventHandler(this.buttonGoToFirst_Click);
      // 
      // menuPlaybackGoToLast
      // 
      this.menuPlaybackGoToLast.Name = "menuPlaybackGoToLast";
      this.menuPlaybackGoToLast.ShortcutKeyDisplayString = "";
      this.menuPlaybackGoToLast.Size = new System.Drawing.Size(163, 22);
      this.menuPlaybackGoToLast.Text = "Go To Last Frame";
      this.menuPlaybackGoToLast.Click += new System.EventHandler(this.buttonGoToLast_Click);
      // 
      // menuSettings
      // 
      this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettingsPDM,
            this.menuSettingsEDM,
            this.menuSettingsFPS,
            this.menuSettingsOptions});
      this.menuSettings.Name = "menuSettings";
      this.menuSettings.Size = new System.Drawing.Size(58, 20);
      this.menuSettings.Text = "&Settings";
      this.menuSettings.DropDownOpened += new System.EventHandler(this.menuSettings_DropDownOpened);
      // 
      // menuSettingsPDM
      // 
      this.menuSettingsPDM.Name = "menuSettingsPDM";
      this.menuSettingsPDM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
      this.menuSettingsPDM.Size = new System.Drawing.Size(202, 22);
      this.menuSettingsPDM.Text = "Select &PDM Data...";
      this.menuSettingsPDM.Click += new System.EventHandler(this.menuSettingsPDM_Click);
      // 
      // menuSettingsEDM
      // 
      this.menuSettingsEDM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettingsEDMNone,
            this.menuSettingsEDMHomogenity,
            this.menuSettingsEDMDifference,
            this.menuSettingsEDMSobel,
            this.menuSettingsEDMCanny});
      this.menuSettingsEDM.Name = "menuSettingsEDM";
      this.menuSettingsEDM.Size = new System.Drawing.Size(202, 22);
      this.menuSettingsEDM.Text = "&Edge Detection Method";
      this.menuSettingsEDM.DropDownOpened += new System.EventHandler(this.menuSettingsEDM_DropDownOpened);
      // 
      // menuSettingsEDMNone
      // 
      this.menuSettingsEDMNone.Checked = true;
      this.menuSettingsEDMNone.CheckState = System.Windows.Forms.CheckState.Checked;
      this.menuSettingsEDMNone.Name = "menuSettingsEDMNone";
      this.menuSettingsEDMNone.Size = new System.Drawing.Size(131, 22);
      this.menuSettingsEDMNone.Text = "&None";
      this.menuSettingsEDMNone.Click += new System.EventHandler(this.menuSettingsEDMNone_Click);
      // 
      // menuSettingsEDMHomogenity
      // 
      this.menuSettingsEDMHomogenity.Name = "menuSettingsEDMHomogenity";
      this.menuSettingsEDMHomogenity.Size = new System.Drawing.Size(131, 22);
      this.menuSettingsEDMHomogenity.Text = "&Homogenity";
      this.menuSettingsEDMHomogenity.Click += new System.EventHandler(this.menuSettingsEDMHomogenity_Click);
      // 
      // menuSettingsEDMDifference
      // 
      this.menuSettingsEDMDifference.Name = "menuSettingsEDMDifference";
      this.menuSettingsEDMDifference.Size = new System.Drawing.Size(131, 22);
      this.menuSettingsEDMDifference.Text = "&Difference";
      this.menuSettingsEDMDifference.Click += new System.EventHandler(this.menuSettingsEDMDifference_Click);
      // 
      // menuSettingsEDMSobel
      // 
      this.menuSettingsEDMSobel.Name = "menuSettingsEDMSobel";
      this.menuSettingsEDMSobel.Size = new System.Drawing.Size(131, 22);
      this.menuSettingsEDMSobel.Text = "&Sobel";
      this.menuSettingsEDMSobel.Click += new System.EventHandler(this.menuSettingsEDMSobel_Click);
      // 
      // menuSettingsEDMCanny
      // 
      this.menuSettingsEDMCanny.Name = "menuSettingsEDMCanny";
      this.menuSettingsEDMCanny.Size = new System.Drawing.Size(131, 22);
      this.menuSettingsEDMCanny.Text = "&Canny";
      this.menuSettingsEDMCanny.Click += new System.EventHandler(this.menuSettingsEDMCanny_Click);
      // 
      // menuSettingsFPS
      // 
      this.menuSettingsFPS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettingsFPSDefault,
            this.menuSettingsFPSNoLimit,
            this.menuSettingsFPSIVTCFilm,
            this.menuSettingsFPSFilm,
            this.menuSettingsFPSPal,
            this.menuSettingsFPSNTSC,
            this.menuSettingsFPSCustom});
      this.menuSettingsFPS.Name = "menuSettingsFPS";
      this.menuSettingsFPS.Size = new System.Drawing.Size(202, 22);
      this.menuSettingsFPS.Text = "Limit &FPS";
      this.menuSettingsFPS.DropDownOpened += new System.EventHandler(this.menuSettingsFPS_DropDownOpened);
      // 
      // menuSettingsFPSDefault
      // 
      this.menuSettingsFPSDefault.Checked = true;
      this.menuSettingsFPSDefault.CheckState = System.Windows.Forms.CheckState.Checked;
      this.menuSettingsFPSDefault.Name = "menuSettingsFPSDefault";
      this.menuSettingsFPSDefault.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
      this.menuSettingsFPSDefault.Size = new System.Drawing.Size(197, 22);
      this.menuSettingsFPSDefault.Text = "-1 (Use Default)";
      this.menuSettingsFPSDefault.Click += new System.EventHandler(this.menuSettingsFPSDefault_Click);
      // 
      // menuSettingsFPSNoLimit
      // 
      this.menuSettingsFPSNoLimit.Name = "menuSettingsFPSNoLimit";
      this.menuSettingsFPSNoLimit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
      this.menuSettingsFPSNoLimit.Size = new System.Drawing.Size(197, 22);
      this.menuSettingsFPSNoLimit.Text = "0 (No Limit)";
      this.menuSettingsFPSNoLimit.Click += new System.EventHandler(this.menuSettingsFPSNoLimit_Click);
      // 
      // menuSettingsFPSIVTCFilm
      // 
      this.menuSettingsFPSIVTCFilm.Name = "menuSettingsFPSIVTCFilm";
      this.menuSettingsFPSIVTCFilm.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
      this.menuSettingsFPSIVTCFilm.Size = new System.Drawing.Size(197, 22);
      this.menuSettingsFPSIVTCFilm.Text = "23.976 (IVTC Film)";
      this.menuSettingsFPSIVTCFilm.Click += new System.EventHandler(this.menuSettingsFPSIVTCFilm_Click);
      // 
      // menuSettingsFPSFilm
      // 
      this.menuSettingsFPSFilm.Name = "menuSettingsFPSFilm";
      this.menuSettingsFPSFilm.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
      this.menuSettingsFPSFilm.Size = new System.Drawing.Size(197, 22);
      this.menuSettingsFPSFilm.Text = "24 (Film)";
      this.menuSettingsFPSFilm.Click += new System.EventHandler(this.menuSettingsFPSFilm_Click);
      // 
      // menuSettingsFPSPal
      // 
      this.menuSettingsFPSPal.Name = "menuSettingsFPSPal";
      this.menuSettingsFPSPal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
      this.menuSettingsFPSPal.Size = new System.Drawing.Size(197, 22);
      this.menuSettingsFPSPal.Text = "25 (PAL)";
      this.menuSettingsFPSPal.Click += new System.EventHandler(this.menuSettingsFPSPal_Click);
      // 
      // menuSettingsFPSNTSC
      // 
      this.menuSettingsFPSNTSC.Name = "menuSettingsFPSNTSC";
      this.menuSettingsFPSNTSC.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
      this.menuSettingsFPSNTSC.Size = new System.Drawing.Size(197, 22);
      this.menuSettingsFPSNTSC.Text = "29.97 (NTSC)";
      this.menuSettingsFPSNTSC.Click += new System.EventHandler(this.menuSettingsFPSNTSC_Click);
      // 
      // menuSettingsFPSCustom
      // 
      this.menuSettingsFPSCustom.Name = "menuSettingsFPSCustom";
      this.menuSettingsFPSCustom.Size = new System.Drawing.Size(197, 22);
      this.menuSettingsFPSCustom.Text = "Custom...";
      this.menuSettingsFPSCustom.Click += new System.EventHandler(this.menuSettingsFPSCustom_Click);
      // 
      // menuSettingsOptions
      // 
      this.menuSettingsOptions.Name = "menuSettingsOptions";
      this.menuSettingsOptions.Size = new System.Drawing.Size(202, 22);
      this.menuSettingsOptions.Text = "&Options...";
      this.menuSettingsOptions.Click += new System.EventHandler(this.menuSettingsOptions_Click);
      // 
      // statusBar
      // 
      this.statusBar.BackColor = System.Drawing.Color.Black;
      this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusInputType,
            this.videoStatus,
            this.numFrame});
      this.statusBar.Location = new System.Drawing.Point(0, 377);
      this.statusBar.Name = "statusBar";
      this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.statusBar.Size = new System.Drawing.Size(392, 22);
      this.statusBar.SizingGrip = false;
      this.statusBar.TabIndex = 2;
      this.statusBar.Text = "Status Bar";
      // 
      // statusInputType
      // 
      this.statusInputType.ForeColor = System.Drawing.Color.White;
      this.statusInputType.Name = "statusInputType";
      this.statusInputType.Size = new System.Drawing.Size(35, 17);
      this.statusInputType.Text = "NONE";
      // 
      // videoStatus
      // 
      this.videoStatus.ForeColor = System.Drawing.Color.White;
      this.videoStatus.Name = "videoStatus";
      this.videoStatus.Size = new System.Drawing.Size(47, 17);
      this.videoStatus.Text = "Stopped";
      // 
      // numFrame
      // 
      this.numFrame.ForeColor = System.Drawing.Color.White;
      this.numFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.numFrame.Name = "numFrame";
      this.numFrame.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.numFrame.RightToLeftAutoMirrorImage = true;
      this.numFrame.Size = new System.Drawing.Size(23, 17);
      this.numFrame.Text = "1/1";
      this.numFrame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // videoController
      // 
      this.videoController.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.videoController.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPlay,
            this.buttonPause,
            this.buttonStop,
            this.toolStripSeparator2,
            this.buttonGoToFirst,
            this.buttonBackward,
            this.buttonForward,
            this.buttonGoToLast});
      this.videoController.Location = new System.Drawing.Point(0, 352);
      this.videoController.Name = "videoController";
      this.videoController.Size = new System.Drawing.Size(392, 25);
      this.videoController.TabIndex = 1;
      this.videoController.Text = "Video Controller";
      // 
      // buttonPlay
      // 
      this.buttonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonPlay.Enabled = false;
      this.buttonPlay.Image = global::Active_Shape_Model.Properties.Resources.buttonPlay;
      this.buttonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonPlay.Name = "buttonPlay";
      this.buttonPlay.Size = new System.Drawing.Size(23, 22);
      this.buttonPlay.Text = "toolStripButton1";
      this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
      // 
      // buttonPause
      // 
      this.buttonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonPause.Enabled = false;
      this.buttonPause.Image = global::Active_Shape_Model.Properties.Resources.buttonPause;
      this.buttonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonPause.Name = "buttonPause";
      this.buttonPause.Size = new System.Drawing.Size(23, 22);
      this.buttonPause.Text = "Pause";
      this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
      // 
      // buttonStop
      // 
      this.buttonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonStop.Enabled = false;
      this.buttonStop.Image = global::Active_Shape_Model.Properties.Resources.buttonStop;
      this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonStop.Name = "buttonStop";
      this.buttonStop.Size = new System.Drawing.Size(23, 22);
      this.buttonStop.Text = "Stop";
      this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
      // 
      // buttonGoToFirst
      // 
      this.buttonGoToFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonGoToFirst.Enabled = false;
      this.buttonGoToFirst.Image = global::Active_Shape_Model.Properties.Resources.buttonGoToFirst;
      this.buttonGoToFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonGoToFirst.Name = "buttonGoToFirst";
      this.buttonGoToFirst.Size = new System.Drawing.Size(23, 22);
      this.buttonGoToFirst.Text = "Go To First Frame";
      this.buttonGoToFirst.Click += new System.EventHandler(this.buttonGoToFirst_Click);
      // 
      // buttonBackward
      // 
      this.buttonBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonBackward.Enabled = false;
      this.buttonBackward.Image = global::Active_Shape_Model.Properties.Resources.buttonBackward;
      this.buttonBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonBackward.Name = "buttonBackward";
      this.buttonBackward.Size = new System.Drawing.Size(23, 22);
      this.buttonBackward.Text = "Step Backward";
      this.buttonBackward.Click += new System.EventHandler(this.buttonBackward_Click);
      // 
      // buttonForward
      // 
      this.buttonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonForward.Enabled = false;
      this.buttonForward.Image = global::Active_Shape_Model.Properties.Resources.buttonForward;
      this.buttonForward.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonForward.Name = "buttonForward";
      this.buttonForward.Size = new System.Drawing.Size(23, 22);
      this.buttonForward.Text = "Step Forward";
      this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
      // 
      // buttonGoToLast
      // 
      this.buttonGoToLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonGoToLast.Enabled = false;
      this.buttonGoToLast.Image = global::Active_Shape_Model.Properties.Resources.buttonGoToLast;
      this.buttonGoToLast.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonGoToLast.Name = "buttonGoToLast";
      this.buttonGoToLast.Size = new System.Drawing.Size(23, 22);
      this.buttonGoToLast.Text = "Go To Last Frame";
      this.buttonGoToLast.Click += new System.EventHandler(this.buttonGoToLast_Click);
      // 
      // videoProgress
      // 
      this.videoProgress.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
      this.videoProgress.BorderColor = System.Drawing.SystemColors.ActiveBorder;
      this.videoProgress.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Sunken;
      this.videoProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.videoProgress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.videoProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
      this.videoProgress.IndentHeight = 4;
      this.videoProgress.Location = new System.Drawing.Point(0, 334);
      this.videoProgress.Maximum = 0;
      this.videoProgress.Minimum = 0;
      this.videoProgress.Name = "videoProgress";
      this.videoProgress.Size = new System.Drawing.Size(392, 18);
      this.videoProgress.TabIndex = 8;
      this.videoProgress.TextTickStyle = System.Windows.Forms.TickStyle.None;
      this.videoProgress.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
      this.videoProgress.TickHeight = 4;
      this.videoProgress.TickStyle = System.Windows.Forms.TickStyle.None;
      this.videoProgress.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
      this.videoProgress.TrackerSize = new System.Drawing.Size(10, 10);
      this.videoProgress.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
      this.videoProgress.TrackLineHeight = 3;
      this.videoProgress.Value = 0;
      this.videoProgress.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.videoProgress_ValueChanged);
      this.videoProgress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMainForm_KeyDown);
      // 
      // cameraWindow
      // 
      this.cameraWindow.BackColor = System.Drawing.Color.Black;
      this.cameraWindow.camera = null;
      this.cameraWindow.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cameraWindow.Location = new System.Drawing.Point(0, 24);
      this.cameraWindow.Name = "cameraWindow";
      this.cameraWindow.Size = new System.Drawing.Size(392, 328);
      this.cameraWindow.TabIndex = 4;
      this.cameraWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMainForm_KeyDown);
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
      this.ClientSize = new System.Drawing.Size(392, 399);
      this.Controls.Add(this.videoProgress);
      this.Controls.Add(this.cameraWindow);
      this.Controls.Add(this.videoController);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.mainMenu);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.mainMenu;
      this.MinimumSize = new System.Drawing.Size(300, 300);
      this.Name = "CMainForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "Active Shape Model";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMainForm_FormClosing);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMainForm_KeyDown);
      this.mainMenu.ResumeLayout(false);
      this.mainMenu.PerformLayout();
      this.statusBar.ResumeLayout(false);
      this.statusBar.PerformLayout();
      this.videoController.ResumeLayout(false);
      this.videoController.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip mainMenu;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem menuFileOpenFile;
    private System.Windows.Forms.ToolStripMenuItem menuFileClose;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem menuFileExit;
    private System.Windows.Forms.ToolStripMenuItem menuFileOpenDevice;
    private System.Windows.Forms.ToolStripMenuItem menuPlayback;
    private System.Windows.Forms.ToolStripMenuItem menuPlaybackPlayPause;
    private System.Windows.Forms.ToolStripMenuItem menuPlaybackStop;
    private System.Windows.Forms.ToolStripMenuItem menuPlaybackForward;
    private System.Windows.Forms.ToolStripMenuItem menuPlaybackBackward;
    private System.Windows.Forms.StatusStrip statusBar;
    private System.Windows.Forms.ToolStripStatusLabel statusInputType;
    private System.Windows.Forms.ToolStripStatusLabel videoStatus;
    private System.Windows.Forms.ToolStripStatusLabel numFrame;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem menuPlaybackGoToFirst;
    private System.Windows.Forms.ToolStripMenuItem menuPlaybackGoToLast;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.ToolStripMenuItem menuSettings;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsPDM;
    private InputSource.CCameraWindow cameraWindow;
    private System.Windows.Forms.ToolStripButton buttonPause;
    private System.Windows.Forms.ToolStripButton buttonStop;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton buttonGoToFirst;
    private System.Windows.Forms.ToolStripButton buttonBackward;
    private System.Windows.Forms.ToolStripButton buttonForward;
    private System.Windows.Forms.ToolStripButton buttonGoToLast;
    private System.Windows.Forms.ToolStrip videoController;
    private System.Windows.Forms.ToolStripButton buttonPlay;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsEDM;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsEDMHomogenity;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsEDMDifference;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsEDMSobel;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsEDMCanny;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPS;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPSDefault;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPSNoLimit;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPSPal;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPSNTSC;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPSIVTCFilm;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPSFilm;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsFPSCustom;
    protected EConTech.Windows.MACUI.MACTrackBar videoProgress;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsEDMNone;
    private System.Windows.Forms.ToolStripMenuItem menuSettingsOptions;
    private System.Windows.Forms.ToolStripMenuItem menuHelp;
    private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
  }
}

