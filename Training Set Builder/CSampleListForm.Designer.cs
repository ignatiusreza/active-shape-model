namespace Training_Set_Builder
{
  partial class CSampleListForm
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
      this.components = new System.ComponentModel.Container();
      this.sampleImagesSmall = new System.Windows.Forms.ImageList(this.components);
      this.addRemoveImage = new System.Windows.Forms.ToolStrip();
      this.btnAddImage = new System.Windows.Forms.ToolStripButton();
      this.btnRemoveImage = new System.Windows.Forms.ToolStripButton();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.sampleImageList = new System.Windows.Forms.ListView();
      this.colImage = new System.Windows.Forms.ColumnHeader();
      this.colName = new System.Windows.Forms.ColumnHeader();
      this.addRemoveImage.SuspendLayout();
      this.SuspendLayout();
      // 
      // sampleImagesSmall
      // 
      this.sampleImagesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.sampleImagesSmall.ImageSize = new System.Drawing.Size(40,40);
      this.sampleImagesSmall.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // addRemoveImage
      // 
      this.addRemoveImage.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.addRemoveImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddImage,
            this.btnRemoveImage});
      this.addRemoveImage.Location = new System.Drawing.Point(0,275);
      this.addRemoveImage.Name = "addRemoveImage";
      this.addRemoveImage.Size = new System.Drawing.Size(150,25);
      this.addRemoveImage.TabIndex = 1;
      this.addRemoveImage.Text = "Add Remove Image";
      // 
      // btnAddImage
      // 
      this.btnAddImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnAddImage.Image = global::Training_Set_Builder.Properties.Resources.buttonAddImage;
      this.btnAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAddImage.Name = "btnAddImage";
      this.btnAddImage.Size = new System.Drawing.Size(23,22);
      this.btnAddImage.Text = "Add Image";
      // 
      // btnRemoveImage
      // 
      this.btnRemoveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRemoveImage.Image = global::Training_Set_Builder.Properties.Resources.buttonRemoveImage;
      this.btnRemoveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRemoveImage.Name = "btnRemoveImage";
      this.btnRemoveImage.Size = new System.Drawing.Size(23,22);
      this.btnRemoveImage.Text = "Remove Image";
      // 
      // sampleImageList
      // 
      this.sampleImageList.BackColor = System.Drawing.Color.White;
      this.sampleImageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.sampleImageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImage,
            this.colName});
      this.sampleImageList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sampleImageList.FullRowSelect = true;
      this.sampleImageList.GridLines = true;
      this.sampleImageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.sampleImageList.HideSelection = false;
      this.sampleImageList.LabelEdit = true;
      this.sampleImageList.LabelWrap = false;
      this.sampleImageList.LargeImageList = this.sampleImagesSmall;
      this.sampleImageList.Location = new System.Drawing.Point(0,0);
      this.sampleImageList.MultiSelect = false;
      this.sampleImageList.Name = "sampleImageList";
      this.sampleImageList.Size = new System.Drawing.Size(150,275);
      this.sampleImageList.SmallImageList = this.sampleImagesSmall;
      this.sampleImageList.TabIndex = 2;
      this.sampleImageList.UseCompatibleStateImageBehavior = false;
      this.sampleImageList.View = System.Windows.Forms.View.Details;
      // 
      // colImage
      // 
      this.colImage.Text = "Image";
      this.colImage.Width = 46;
      // 
      // colName
      // 
      this.colName.Text = "Name";
      this.colName.Width = 104;
      // 
      // CSampleListForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(150,300);
      this.Controls.Add(this.sampleImageList);
      this.Controls.Add(this.addRemoveImage);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Location = new System.Drawing.Point(400,150);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CSampleListForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Sample List";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CSampleListForm_FormClosing);
      this.addRemoveImage.ResumeLayout(false);
      this.addRemoveImage.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip addRemoveImage;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    public System.Windows.Forms.ColumnHeader colImage;
    public System.Windows.Forms.ColumnHeader colName;
    public System.Windows.Forms.ListView sampleImageList;
    public System.Windows.Forms.ToolStripButton btnAddImage;
    public System.Windows.Forms.ToolStripButton btnRemoveImage;
    public System.Windows.Forms.ImageList sampleImagesSmall;
  }
}