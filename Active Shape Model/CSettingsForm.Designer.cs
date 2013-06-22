namespace Active_Shape_Model {
  partial class CSettingsForm {
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
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.groupPDM = new System.Windows.Forms.GroupBox();
      this.textMaxMode = new System.Windows.Forms.Label();
      this.textValueResolution = new System.Windows.Forms.Label();
      this.textValuePointNum = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.inputFreedom = new System.Windows.Forms.TextBox();
      this.textFreedom = new System.Windows.Forms.Label();
      this.modelSize = new System.Windows.Forms.Label();
      this.textPointNum = new System.Windows.Forms.Label();
      this.groupASMInit = new System.Windows.Forms.GroupBox();
      this.label8 = new System.Windows.Forms.Label();
      this.inputCY = new System.Windows.Forms.TextBox();
      this.inputCX = new System.Windows.Forms.TextBox();
      this.textInitialGuess = new System.Windows.Forms.Label();
      this.cbUsePreviousResult = new System.Windows.Forms.CheckBox();
      this.groupDetection = new System.Windows.Forms.GroupBox();
      this.label14 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.inputMaxStep = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.inputLimit = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.inputThreshold = new System.Windows.Forms.TextBox();
      this.cbShowIterationStep = new System.Windows.Forms.CheckBox();
      this.cbShowDetectedEdge = new System.Windows.Forms.CheckBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.inputIterationDelay = new System.Windows.Forms.TextBox();
      this.inputIterateEvery = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.groupPDM.SuspendLayout();
      this.groupASMInit.SuspendLayout();
      this.groupDetection.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(392, 252);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 12;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(311, 252);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 11;
      this.btnOk.Text = "&OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // groupPDM
      // 
      this.groupPDM.Controls.Add(this.textMaxMode);
      this.groupPDM.Controls.Add(this.textValueResolution);
      this.groupPDM.Controls.Add(this.textValuePointNum);
      this.groupPDM.Controls.Add(this.label7);
      this.groupPDM.Controls.Add(this.label6);
      this.groupPDM.Controls.Add(this.label5);
      this.groupPDM.Controls.Add(this.inputFreedom);
      this.groupPDM.Controls.Add(this.textFreedom);
      this.groupPDM.Controls.Add(this.modelSize);
      this.groupPDM.Controls.Add(this.textPointNum);
      this.groupPDM.Location = new System.Drawing.Point(10, 10);
      this.groupPDM.Name = "groupPDM";
      this.groupPDM.Size = new System.Drawing.Size(230, 90);
      this.groupPDM.TabIndex = 9;
      this.groupPDM.TabStop = false;
      this.groupPDM.Text = "Model Data";
      // 
      // textMaxMode
      // 
      this.textMaxMode.AutoSize = true;
      this.textMaxMode.Location = new System.Drawing.Point(165, 64);
      this.textMaxMode.Name = "textMaxMode";
      this.textMaxMode.Size = new System.Drawing.Size(54, 13);
      this.textMaxMode.TabIndex = 9;
      this.textMaxMode.Text = "(Max : 80)";
      // 
      // textValueResolution
      // 
      this.textValueResolution.AutoSize = true;
      this.textValueResolution.Location = new System.Drawing.Point(121, 42);
      this.textValueResolution.Name = "textValueResolution";
      this.textValueResolution.Size = new System.Drawing.Size(54, 13);
      this.textValueResolution.TabIndex = 8;
      this.textValueResolution.Text = "800 x 600";
      // 
      // textValuePointNum
      // 
      this.textValuePointNum.AutoSize = true;
      this.textValuePointNum.Location = new System.Drawing.Point(121, 20);
      this.textValuePointNum.Name = "textValuePointNum";
      this.textValuePointNum.Size = new System.Drawing.Size(19, 13);
      this.textValuePointNum.TabIndex = 7;
      this.textValuePointNum.Text = "80";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(108, 64);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(10, 13);
      this.label7.TabIndex = 6;
      this.label7.Text = ":";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(108, 42);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(10, 13);
      this.label6.TabIndex = 5;
      this.label6.Text = ":";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(108, 20);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(10, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = ":";
      // 
      // inputFreedom
      // 
      this.inputFreedom.Location = new System.Drawing.Point(124, 60);
      this.inputFreedom.Name = "inputFreedom";
      this.inputFreedom.Size = new System.Drawing.Size(35, 20);
      this.inputFreedom.TabIndex = 0;
      this.inputFreedom.Leave += new System.EventHandler(this.inputFreedom_Leave);
      // 
      // textFreedom
      // 
      this.textFreedom.AutoSize = true;
      this.textFreedom.Location = new System.Drawing.Point(10, 64);
      this.textFreedom.Name = "textFreedom";
      this.textFreedom.Size = new System.Drawing.Size(78, 13);
      this.textFreedom.TabIndex = 2;
      this.textFreedom.Text = "&Variation Mode";
      // 
      // modelSize
      // 
      this.modelSize.AutoSize = true;
      this.modelSize.Location = new System.Drawing.Point(10, 42);
      this.modelSize.Name = "modelSize";
      this.modelSize.Size = new System.Drawing.Size(57, 13);
      this.modelSize.TabIndex = 1;
      this.modelSize.Text = "Resolution";
      // 
      // textPointNum
      // 
      this.textPointNum.AutoSize = true;
      this.textPointNum.Location = new System.Drawing.Point(10, 20);
      this.textPointNum.Name = "textPointNum";
      this.textPointNum.Size = new System.Drawing.Size(88, 13);
      this.textPointNum.TabIndex = 0;
      this.textPointNum.Text = "Number of Points";
      // 
      // groupASMInit
      // 
      this.groupASMInit.Controls.Add(this.label8);
      this.groupASMInit.Controls.Add(this.inputCY);
      this.groupASMInit.Controls.Add(this.inputCX);
      this.groupASMInit.Controls.Add(this.textInitialGuess);
      this.groupASMInit.Controls.Add(this.cbUsePreviousResult);
      this.groupASMInit.Location = new System.Drawing.Point(250, 10);
      this.groupASMInit.Name = "groupASMInit";
      this.groupASMInit.Size = new System.Drawing.Size(230, 90);
      this.groupASMInit.TabIndex = 10;
      this.groupASMInit.TabStop = false;
      this.groupASMInit.Text = "Initialization";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(164, 20);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(12, 13);
      this.label8.TabIndex = 4;
      this.label8.Text = "x";
      // 
      // inputCY
      // 
      this.inputCY.Location = new System.Drawing.Point(182, 17);
      this.inputCY.Name = "inputCY";
      this.inputCY.Size = new System.Drawing.Size(35, 20);
      this.inputCY.TabIndex = 2;
      this.inputCY.Leave += new System.EventHandler(this.inputCY_Leave);
      // 
      // inputCX
      // 
      this.inputCX.Location = new System.Drawing.Point(123, 17);
      this.inputCX.Name = "inputCX";
      this.inputCX.Size = new System.Drawing.Size(35, 20);
      this.inputCX.TabIndex = 1;
      this.inputCX.Leave += new System.EventHandler(this.inputCX_Leave);
      // 
      // textInitialGuess
      // 
      this.textInitialGuess.AutoSize = true;
      this.textInitialGuess.Location = new System.Drawing.Point(10, 20);
      this.textInitialGuess.Name = "textInitialGuess";
      this.textInitialGuess.Size = new System.Drawing.Size(110, 13);
      this.textInitialGuess.TabIndex = 1;
      this.textInitialGuess.Text = "Initial &Guess Position :";
      // 
      // cbUsePreviousResult
      // 
      this.cbUsePreviousResult.AutoSize = true;
      this.cbUsePreviousResult.Location = new System.Drawing.Point(13, 38);
      this.cbUsePreviousResult.Name = "cbUsePreviousResult";
      this.cbUsePreviousResult.Size = new System.Drawing.Size(197, 17);
      this.cbUsePreviousResult.TabIndex = 3;
      this.cbUsePreviousResult.Text = "Use &Previous Result As Initial Guess";
      this.cbUsePreviousResult.UseVisualStyleBackColor = true;
      // 
      // groupDetection
      // 
      this.groupDetection.Controls.Add(this.label14);
      this.groupDetection.Controls.Add(this.label9);
      this.groupDetection.Controls.Add(this.label13);
      this.groupDetection.Controls.Add(this.inputMaxStep);
      this.groupDetection.Controls.Add(this.label11);
      this.groupDetection.Controls.Add(this.inputLimit);
      this.groupDetection.Controls.Add(this.label12);
      this.groupDetection.Controls.Add(this.label10);
      this.groupDetection.Controls.Add(this.inputThreshold);
      this.groupDetection.Controls.Add(this.cbShowIterationStep);
      this.groupDetection.Controls.Add(this.cbShowDetectedEdge);
      this.groupDetection.Controls.Add(this.label4);
      this.groupDetection.Controls.Add(this.label3);
      this.groupDetection.Controls.Add(this.inputIterationDelay);
      this.groupDetection.Controls.Add(this.inputIterateEvery);
      this.groupDetection.Controls.Add(this.label2);
      this.groupDetection.Controls.Add(this.label1);
      this.groupDetection.Location = new System.Drawing.Point(10, 106);
      this.groupDetection.Name = "groupDetection";
      this.groupDetection.Size = new System.Drawing.Size(470, 140);
      this.groupDetection.TabIndex = 11;
      this.groupDetection.TabStop = false;
      this.groupDetection.Text = "Detection";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(10, 42);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(76, 13);
      this.label14.TabIndex = 20;
      this.label14.Text = "&Maximum Step";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(10, 20);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(82, 13);
      this.label9.TabIndex = 14;
      this.label9.Text = "Edge &Threshold";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(108, 44);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(10, 13);
      this.label13.TabIndex = 19;
      this.label13.Text = ":";
      // 
      // inputMaxStep
      // 
      this.inputMaxStep.Location = new System.Drawing.Point(124, 39);
      this.inputMaxStep.Name = "inputMaxStep";
      this.inputMaxStep.Size = new System.Drawing.Size(35, 20);
      this.inputMaxStep.TabIndex = 6;
      this.inputMaxStep.Text = "10";
      this.inputMaxStep.Leave += new System.EventHandler(this.inputMaxStep_Leave);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(345, 20);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(10, 13);
      this.label11.TabIndex = 16;
      this.label11.Text = ":";
      // 
      // inputLimit
      // 
      this.inputLimit.Location = new System.Drawing.Point(363, 17);
      this.inputLimit.Name = "inputLimit";
      this.inputLimit.Size = new System.Drawing.Size(35, 20);
      this.inputLimit.TabIndex = 5;
      this.inputLimit.Text = "10";
      this.inputLimit.Leave += new System.EventHandler(this.inputLimit_Leave);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(247, 20);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(77, 13);
      this.label12.TabIndex = 17;
      this.label12.Text = "&Range of View";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(108, 20);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(10, 13);
      this.label10.TabIndex = 9;
      this.label10.Text = ":";
      // 
      // inputThreshold
      // 
      this.inputThreshold.Location = new System.Drawing.Point(124, 17);
      this.inputThreshold.Name = "inputThreshold";
      this.inputThreshold.Size = new System.Drawing.Size(35, 20);
      this.inputThreshold.TabIndex = 4;
      this.inputThreshold.Text = "10";
      this.inputThreshold.Leave += new System.EventHandler(this.inputThreshold_Leave);
      // 
      // cbShowIterationStep
      // 
      this.cbShowIterationStep.AutoSize = true;
      this.cbShowIterationStep.Location = new System.Drawing.Point(13, 86);
      this.cbShowIterationStep.Name = "cbShowIterationStep";
      this.cbShowIterationStep.Size = new System.Drawing.Size(270, 17);
      this.cbShowIterationStep.TabIndex = 8;
      this.cbShowIterationStep.Text = "Show &Iteration Step (Only Applicable For Image File)";
      this.cbShowIterationStep.UseVisualStyleBackColor = true;
      // 
      // cbShowDetectedEdge
      // 
      this.cbShowDetectedEdge.AutoSize = true;
      this.cbShowDetectedEdge.Location = new System.Drawing.Point(13, 64);
      this.cbShowDetectedEdge.Name = "cbShowDetectedEdge";
      this.cbShowDetectedEdge.Size = new System.Drawing.Size(128, 17);
      this.cbShowDetectedEdge.TabIndex = 7;
      this.cbShowDetectedEdge.Text = "Show Detected &Edge";
      this.cbShowDetectedEdge.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(399, 108);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(20, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "ms";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(181, 108);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(45, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Iteration";
      // 
      // inputIterationDelay
      // 
      this.inputIterationDelay.Location = new System.Drawing.Point(293, 105);
      this.inputIterationDelay.Name = "inputIterationDelay";
      this.inputIterationDelay.Size = new System.Drawing.Size(100, 20);
      this.inputIterationDelay.TabIndex = 10;
      this.inputIterationDelay.Text = "100";
      this.inputIterationDelay.Leave += new System.EventHandler(this.inputIterationDelay_Leave);
      // 
      // inputIterateEvery
      // 
      this.inputIterateEvery.Location = new System.Drawing.Point(75, 105);
      this.inputIterateEvery.Name = "inputIterateEvery";
      this.inputIterateEvery.Size = new System.Drawing.Size(100, 20);
      this.inputIterateEvery.TabIndex = 9;
      this.inputIterateEvery.Text = "1";
      this.inputIterateEvery.Leave += new System.EventHandler(this.inputIterateEvery_Leave);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(247, 108);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(40, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "&Delay :";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 108);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(40, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "&Every :";
      // 
      // CSettingsForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(492, 285);
      this.Controls.Add(this.groupDetection);
      this.Controls.Add(this.groupASMInit);
      this.Controls.Add(this.groupPDM);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.btnCancel);
      this.Name = "CSettingsForm";
      this.Text = "Options";
      this.groupPDM.ResumeLayout(false);
      this.groupPDM.PerformLayout();
      this.groupASMInit.ResumeLayout(false);
      this.groupASMInit.PerformLayout();
      this.groupDetection.ResumeLayout(false);
      this.groupDetection.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.GroupBox groupPDM;
      private System.Windows.Forms.Label textFreedom;
      private System.Windows.Forms.Label modelSize;
    private System.Windows.Forms.Label textPointNum;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.GroupBox groupASMInit;
    private System.Windows.Forms.Label textInitialGuess;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.GroupBox groupDetection;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.TextBox inputIterationDelay;
    public System.Windows.Forms.TextBox inputIterateEvery;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label10;
    public System.Windows.Forms.TextBox inputThreshold;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label11;
    public System.Windows.Forms.TextBox inputLimit;
    private System.Windows.Forms.Label label12;
    public System.Windows.Forms.CheckBox cbUsePreviousResult;
    public System.Windows.Forms.TextBox inputCY;
    public System.Windows.Forms.TextBox inputCX;
    public System.Windows.Forms.CheckBox cbShowIterationStep;
    public System.Windows.Forms.CheckBox cbShowDetectedEdge;
    public System.Windows.Forms.Label textMaxMode;
    public System.Windows.Forms.TextBox inputFreedom;
    public System.Windows.Forms.Label textValueResolution;
    public System.Windows.Forms.Label textValuePointNum;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label13;
    public System.Windows.Forms.TextBox inputMaxStep;
  }
}