using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using ASMLibrary;
using LinearAlgebra;

namespace Training_Set_Builder {
  public partial class CMainForm : Form {
    #region "DLL Import"

    [DllImport("user32")]
    public static extern int SetParent(int hWndChild, int hWndNewParent);

    #endregion

    #region "Form Declaration"

    private CDetailedForm       _detailed       = new CDetailedForm();
    private CSampleEditor       _sampleEditor   = new CSampleEditor();
    private CSampleListForm     _sampleList     = new CSampleListForm();
    private CNewTrainingSetForm _newTrainingSet = new CNewTrainingSetForm();
    private CDoTrainingForm     _doTraining     = new CDoTrainingForm();
    private CAboutForm          _about          = new CAboutForm();

    #endregion

    #region "Private Attributes"

    private Graphics   _sampleGraphics;
    private Image      _selectedImage;
    private bool       _isDrawing,_isSelecting,_isMoving,_isDrawTrainingData,_isUpdating,_isRotating;
    private int        _X1,_Y1,_X2,_Y2,_diffX,_diffY;
    private double     _boundX1,_boundY1,_boundX2,_boundY2,_orientationAngle,_diffAngle;
    private int        _selectedIdx;
    private double     _zoomRatio;

    private Brush[]    _brushes;
    private Pen        _dashedBlackPen;

    private CTrainingSet            _trainingSet;
    private CTrainingResult         _summary = new CTrainingResult();
    private CPointDistributionModel _trainingResult;

    #endregion

    public CMainForm() {
      CSettings.ISSAVED     = true;
      CSettings.MAXCLIPSIZE = new Size(700,525);
      CSettings.MAXPOINT    = 500;
      CSettings.APPDIR   = Directory.GetCurrentDirectory();
      CSettings.CACHEDIR = CSettings.APPDIR + "\\cache\\";

      InitializeComponent();

      _sampleEditor.KeyDown          += new KeyEventHandler(this.CSampleEditor_KeyDown);
      _sampleEditor.sample.KeyDown   += new KeyEventHandler(this.CSampleEditor_KeyDown);
      _sampleList.KeyDown            += new KeyEventHandler(this.CSampleEditor_KeyDown);
      _detailed.KeyDown              += new KeyEventHandler(this.CSampleEditor_KeyDown);
      _detailed.sampleVector.KeyDown += new KeyEventHandler(this.CSampleEditor_KeyDown);

      _detailed.Paint                += new PaintEventHandler(this.CDetailedForm_Paint);
      _detailed.btnPointerTool.Click += new EventHandler(this.btnPointerTool_Click);
      _detailed.btnLineTool.Click    += new EventHandler(this.btnLineTool_Click);
      _detailed.sampleVector.SelectedIndexChanged += new EventHandler(sampleVector_SelectedIndexChanged);

      _sampleEditor.sample.Paint           += new PaintEventHandler(this.sample_Paint);
      _sampleEditor.sample.MouseDown       += new MouseEventHandler(this.sample_MouseDown);
      _sampleEditor.sample.MouseMove       += new MouseEventHandler(this.sample_MouseMove);
      _sampleEditor.sample.MouseUp         += new MouseEventHandler(this.sample_MouseUp);
      _sampleEditor.buttonFirstFrame.Click += new EventHandler(buttonFirstFrame_Click);
      _sampleEditor.buttonBackward.Click   += new EventHandler(buttonBackward_Click);
      _sampleEditor.buttonForward.Click    += new EventHandler(buttonForward_Click);
      _sampleEditor.buttonLastFrame.Click  += new EventHandler(buttonLastFrame_Click);

      _sampleList.btnAddImage.Click    += new EventHandler(this.btnAddImage_Click);
      _sampleList.btnRemoveImage.Click += new EventHandler(this.btnRemoveImage_Click);

      _sampleList.sampleImageList.SelectedIndexChanged += new System.EventHandler(this.sampleImageList_SelectedIndexChanged);

      _doTraining.trainingSetImage.Paint     += new PaintEventHandler(this.trainingSetImage_Paint);
      _doTraining.trainingSetImage.MouseDown += new MouseEventHandler(trainingSetImage_MouseDown);
      _doTraining.trainingSetImage.MouseMove += new MouseEventHandler(trainingSetImage_MouseMove);
      _doTraining.trainingSetImage.MouseUp   += new MouseEventHandler(trainingSetImage_MouseUp);
      _doTraining.btnStart.Click             += new EventHandler(this.btnStart_Click);
      _doTraining.btnClose.Click             += new EventHandler(btnClose_Click);
      _doTraining.btnSavePDM.Click           += new EventHandler(btnSavePDM_Click);
      
      Random _rand = new Random();
      _brushes = new Brush[CSettings.MAXPOINT];
      for(int i=0;i<CSettings.MAXPOINT;i++)
        _brushes[i] = new SolidBrush(Color.FromArgb(_rand.Next(100)+50,_rand.Next(100)+50,_rand.Next(100)+50));
      _dashedBlackPen = new Pen(Color.Black,1);
      _dashedBlackPen.DashStyle = DashStyle.Dash;
    }

    #region "Main Form Event Handler"

    private void mainForm_Load(object sender, EventArgs e) {
      SetParent((int)_detailed.Handle,(int)this.Handle);
      _detailed.Size = new System.Drawing.Size(190, 350);
      _detailed.Location = new System.Drawing.Point(10, 70);
      _detailed.Show();

      _sampleEditor.MdiParent = this;
      _sampleEditor.Location  = new System.Drawing.Point(
        Width/2 - _sampleEditor.Width/2,
        70);

      SetParent((int)_sampleList.Handle,(int)this.Handle);
      _sampleList.Location = new System.Drawing.Point(
        Width - _sampleList.Width - 50,
        Height - _sampleList.Height - 150);
      _sampleList.Show();

      this.reset();
    }

    private void CMainForm_SizeChanged(object sender, EventArgs e) {
      _sampleList.Location = new System.Drawing.Point(
        Width - _sampleList.Width - 50,
        Height - _sampleList.Height - 150);
    }
    
    private void CMainForm_FormClosing(object sender,FormClosingEventArgs e) {
      isUnsaved();
    }

    private void menuFile_DropDownOpened(object sender, EventArgs e) {
      menuFileSave.Enabled = (!CSettings.ISSAVED && _trainingSet != null);
    }

    private void menuFileNew_Click(object sender, EventArgs e) {
      _newTrainingSet.clear();
      DialogResult res = _newTrainingSet.ShowDialog();
      if(res == DialogResult.OK) {
        // Close Opened TS
        menuFileClose_Click(sender,e);
        menuFileSaveAs.Enabled             = true;
        menuTrainingSetStart.Enabled       = true;
        _detailed.btnPointerTool.Enabled   = true;
        _detailed.btnLineTool.Enabled      = true;
        _sampleList.btnAddImage.Enabled    = true;
        _sampleList.btnRemoveImage.Enabled = true;

        _trainingSet = new CTrainingSet();
        _trainingSet.createNew(
          _newTrainingSet.inputPath.Text,
          _newTrainingSet.inputName.Text,
          new Size(
            int.Parse(_newTrainingSet.inputClippingWidth.Text),
            int.Parse(_newTrainingSet.inputClippingHeight.Text))
          );

        _zoomRatio                  = 1.0f;
        _sampleEditor.sample.Width  = int.Parse(_newTrainingSet.inputClippingWidth.Text);
        _sampleEditor.sample.Height = int.Parse(_newTrainingSet.inputClippingHeight.Text);
        _sampleEditor.vScrollBar.Value = 0;
        _sampleEditor.hScrollBar.Value = 0;
        _sampleEditor.vScrollBar_Scroll(null,null);
        _sampleEditor.hScrollBar_Scroll(null,null);
        _sampleEditor.Show();
      }
    }

    private void menuFileOpen_Click(object sender,EventArgs e) {
      openFileDialog.Filter = "Training Set Project (*.ts) | *.ts";
      openFileDialog.FileName = "";
      if(openFileDialog.ShowDialog() == DialogResult.OK) {
        menuFileClose_Click(sender,e);
        string path, name;
        splitFullPath(openFileDialog.FileName,out path,out name);
        _trainingSet = new CTrainingSet();

        statusLabel.Text = "...Opening Sample Data File";
        statusLabel.Refresh();

        if(!_trainingSet.open(path,name)) {
          MessageBox.Show("Training Set Project Not Found or Corrupted!","Cannot Open Training Set");
          _trainingSet.Dispose();
          _trainingSet = null;
          return;
        }

        // update all form..
        // Main Form
        menuFileSaveAs.Enabled             = true;
        menuTrainingSetStart.Enabled       = true;
        _detailed.btnPointerTool.Enabled   = true;
        _detailed.btnLineTool.Enabled      = true;
        _sampleList.btnAddImage.Enabled    = true;
        _sampleList.btnRemoveImage.Enabled = true;
        
        // CSampleList
        int i;
        
        CSettings.status.Show();
        CSettings.status.statusProgress.Minimum = 0;
        CSettings.status.statusProgress.Maximum = _trainingSet.numSamples;
        CSettings.status.statusProgress.Step    = 1;
        CSettings.status.statusProgress.Value   = 0;
        
        for(i=0;i<_trainingSet.numSamples;i++) {
          CSettings.status.statusLabel.Text = "Opening Sample Image " + i + "/" + _trainingSet.numSamples;
          CSettings.status.statusLabel.Refresh();
          Image buff = Image.FromFile(((CSample)_trainingSet.sample[i]).pictureFilename);
          addImage(buff);
          buff.Dispose();
          CSettings.status.statusProgress.PerformStep();
        }
        CSettings.status.Hide();

        if(_trainingSet.numSamples!=0) {
          _sampleList.sampleImageList.Items[0].Selected = true;
          _sampleEditor.numFrame.Text = "1/" + _trainingSet.numSamples.ToString();
        }else
          _sampleEditor.numFrame.Text = "0/" + _trainingSet.numSamples.ToString();
        
        // CSampleEditor
        _zoomRatio                  = 1.0f;
        _sampleEditor.sample.Width  = _trainingSet.clippingSize.Width;
        _sampleEditor.sample.Height = _trainingSet.clippingSize.Height;
        _sampleEditor.vScrollBar.Value = 0;
        _sampleEditor.hScrollBar.Value = 0;
        _sampleEditor.vScrollBar_Scroll(null,null);
        _sampleEditor.hScrollBar_Scroll(null,null);
        _sampleEditor.Show();
        
        // CDetailed
        _detailed.Invalidate();

        statusLabel.Text = "Training Set Builder : " + name;
        statusLabel.Refresh();
      }
    }

    private void menuFileClose_Click(object sender,EventArgs e) {
      if(_trainingSet != null) {
        isUnsaved();
        _trainingSet.Dispose();
        _trainingSet = null;
      }
      reset();
      _sampleEditor.WindowState = FormWindowState.Normal;
      _sampleEditor.Hide();
    }

    private void menuFileSave_Click(object sender,EventArgs e) {
      if(_trainingSet != null) {
        _trainingSet.saveToDisk();
        CSettings.ISSAVED = true;
      }
    }

    private void menuFileSaveAs_Click(object sender,EventArgs e) {
      saveFileDialog.Filter = "Training Set Project (*.ts) | *.ts";
      saveFileDialog.InitialDirectory = _trainingSet.path;
      saveFileDialog.FileName = _trainingSet.name + ".ts";
      if(saveFileDialog.ShowDialog() == DialogResult.OK) {
        string path,name;
        splitFullPath(saveFileDialog.FileName,out path,out name);
        _trainingSet.saveToDisk(path,name);
        CSettings.ISSAVED = true;
      }
    }

    private void menuFileExit_Click(object sender, EventArgs e) {
      while(this.Visible) this.Close();
    }

    private void menuTrainingSetStart_Click(object sender,EventArgs e) {
      this.Hide();
      _doTraining.trainingStats        = CDoTrainingForm.TTrainingStats.STARTING;
      _doTraining.treeProgress.Visible = true;
      _doTraining.treeProgress.Nodes[0].ImageIndex                   = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[0].ImageIndex          = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[1].ImageIndex          = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[0].ImageIndex = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[1].ImageIndex = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[2].ImageIndex = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[3].ImageIndex = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[2].ImageIndex          = 0;
      _doTraining.treeProgress.Nodes[0].Nodes[3].ImageIndex          = 0;
      _doTraining.treeProgress.ExpandAll();
      _doTraining.b1.Enabled         = false;
      _doTraining.b1.Value           = 0;
      _doTraining.b2.Enabled         = false;
      _doTraining.b2.Value           = 0;
      _doTraining.b3.Enabled         = false;
      _doTraining.b3.Value           = 0;
      _doTraining.b4.Enabled         = false;
      _doTraining.b4.Value           = 0;
      _doTraining.b5.Enabled         = false;
      _doTraining.b5.Value           = 0;
      _doTraining.btnStart.Enabled   = true;
      _doTraining.btnStart.Text      = "Start";
      _doTraining.btnSavePDM.Enabled = false;
      _isDrawTrainingData = true;
      _doTraining.Size    = new Size(_trainingSet.clippingSize.Width+440,_trainingSet.clippingSize.Height+60);


      _doTraining.ShowDialog();
    }

    private void menuTrainingSetOpen_Click(object sender,EventArgs e) {
      openFileDialog.Filter = "Point Distribution Model Data (*.pdm) | *.pdm";
      openFileDialog.FileName = "";
      if(openFileDialog.ShowDialog() == DialogResult.OK) {
        _trainingResult = CPointDistributionModel.open(openFileDialog.FileName);
        if(_trainingResult == null) {
          MessageBox.Show("Point Distribution Model Data Not Found or Corrupted!","Cannot Open PDM Data");
          return;
        }
        this.Hide();
        _doTraining.trainingStats    = CDoTrainingForm.TTrainingStats.FINISHED;
        _doTraining.treeProgress.Visible = true;
        _doTraining.treeProgress.Nodes[0].ImageIndex                   = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[0].ImageIndex          = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[1].ImageIndex          = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[0].ImageIndex = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[1].ImageIndex = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[2].ImageIndex = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[3].ImageIndex = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[2].ImageIndex          = 1;
        _doTraining.treeProgress.Nodes[0].Nodes[3].ImageIndex          = 1;
        _doTraining.b1.Enabled         = true;
        _doTraining.b1.Value           = 0;
        _doTraining.b2.Enabled         = true;
        _doTraining.b2.Value           = 0;
        _doTraining.b3.Enabled         = true;
        _doTraining.b3.Value           = 0;
        _doTraining.b4.Enabled         = true;
        _doTraining.b4.Value           = 0;
        _doTraining.b5.Enabled         = true;
        _doTraining.b5.Value           = 0;
        _doTraining.btnStart.Enabled = false;
        _doTraining.btnStart.Text    = "Start";
        _isDrawTrainingData          = false;
        _doTraining.Show();
      }
    }

    private void menuWindow_DropDownOpened(object sender,EventArgs e) {
      menuWindowSampleList.Checked = _sampleList.Visible;
      menuWindowVectorData.Checked = _detailed.Visible;
    }

    private void menuWindowVectorData_Click(object sender, EventArgs e) {
      menuWindowVectorData.Checked = !menuWindowVectorData.Checked;
      if (menuWindowVectorData.Checked) {
        _detailed.Location = new System.Drawing.Point(10, 70);
        _detailed.Show();
      } else
        _detailed.Hide();
    }

    private void menuWindowSampleList_Click(object sender, EventArgs e) {
      menuWindowSampleList.Checked = !menuWindowSampleList.Checked;
      if(menuWindowSampleList.Checked) {
        _sampleList.Location = new System.Drawing.Point(
          Width - _sampleList.Width - 50,
          Height - _sampleList.Height - 150);
        _sampleList.Show();
      } else
        _sampleList.Hide();
    }

    private void menuHelpAbout_Click(object sender, EventArgs e) {
      _about.ShowDialog();
    }

    #endregion
        
    #region "CDetailedForm Event Handler"

    private void CDetailedForm_Paint(object sender,PaintEventArgs e) {
      if(_trainingSet == null || _selectedIdx == -1) {
        if(_trainingSet != null && _trainingSet.numSamples == 0) 
          _detailed.sampleVector.Items.Clear();
        return;
      }

      // Tulis ulang semua data vector
      _isUpdating = true;
      _detailed.sampleVector.Items.Clear();

      int i;

      for(i=0;i<_trainingSet.numPoints;i++) {
        string[] item = {((int)(i+1)).ToString(),_trainingSet.activeSample[i][0].ToString("F5"),_trainingSet.activeSample[i][1].ToString("F5") };
        _detailed.sampleVector.Items.Add(
          new ListViewItem(item));
        if(_trainingSet.isSelected[i])
          _detailed.sampleVector.Items[i].Selected = true;
      }
      _isUpdating = false;
    }

    private void btnPointerTool_Click(object sender,EventArgs e) {
      if(_detailed.toolsSelected != CDetailedForm.TTools.POINTER) {
        _detailed.btnPointerTool.Checked = true;
        _detailed.btnLineTool.Checked = false;

        _detailed.toolsSelected = Training_Set_Builder.CDetailedForm.TTools.POINTER;
        _isDrawing = _isMoving = _isSelecting = false;
        _trainingSet.diselectAll();
        updateBoundingRect();

        _sampleEditor.sample.Cursor = Cursors.Arrow;
        _sampleEditor.sample.Invalidate();
      }
    }

    private void btnLineTool_Click(object sender,EventArgs e) {
      if(_detailed.toolsSelected != CDetailedForm.TTools.LINE) {
        _detailed.btnPointerTool.Checked = false;
        _detailed.btnLineTool.Checked = true;
        _detailed.toolsSelected = Training_Set_Builder.CDetailedForm.TTools.LINE;
        _isDrawing = _isMoving = _isSelecting = false;
        _trainingSet.diselectAll();
        updateBoundingRect();

        _sampleEditor.sample.Cursor = Cursors.Cross;
        _sampleEditor.sample.Invalidate();
      }
    }

    private void sampleVector_SelectedIndexChanged(object sender,EventArgs e) {
      int n = _detailed.sampleVector.SelectedIndices.Count;
      if(n > 0 && !_isUpdating) {
        _trainingSet.diselectAll();
        for(int i=0;i<n;i++)
          _trainingSet.select(_detailed.sampleVector.SelectedIndices[i],true);
        updateBoundingRect();
        _sampleEditor.sample.Invalidate();
      }
    }

    #endregion

    #region "CSampleEditor Event Handler"

    private void CSampleEditor_KeyDown(object sender,KeyEventArgs e) {
      switch(e.KeyCode) {
        case Keys.Escape :
          if(_isDrawing)
            _isDrawing = false;
          else if(_isMoving) {
            _isMoving = false;
            _diffX = 0;
            _diffY = 0;
          }
          _sampleEditor.sample.Invalidate();
          break;
        case Keys.C :
          _trainingSet.connectAllSelected(!e.Shift);
          CSettings.ISSAVED = false;
          _sampleEditor.sample.Invalidate();
          break;
        case Keys.Delete :
          _trainingSet.removeAllSelected();
          _boundX1 = _boundX2 = _boundY1 = _boundY2 = -1;
          _sampleEditor.sample.Invalidate();
          _detailed.Invalidate();
          break;
        case Keys.Oemplus :
          _zoomRatio += 0.1f;
          if(_zoomRatio > 5) _zoomRatio = 5;
          _sampleEditor.vScrollBar.SmallChange = (int)(_zoomRatio+0.49)*5;
          _sampleEditor.hScrollBar.SmallChange = (int)(_zoomRatio+0.49)*5;
          _sampleEditor.sample.Size = new Size((int)(_trainingSet.clippingSize.Width * _zoomRatio),(int)(_trainingSet.clippingSize.Height * _zoomRatio));
          _sampleEditor.vScrollBar_Scroll(null,null);
          _sampleEditor.hScrollBar_Scroll(null,null);
          _sampleEditor.sample.Invalidate();
          break;
        case Keys.OemMinus :
          _zoomRatio -= 0.1f;
          if(_zoomRatio < 0.6f) _zoomRatio = 0.6f;
          _sampleEditor.vScrollBar.SmallChange = (int)(_zoomRatio+0.49)*5;
          _sampleEditor.hScrollBar.SmallChange = (int)(_zoomRatio+0.49)*5;
          _sampleEditor.sample.Size = new Size((int)(_trainingSet.clippingSize.Width * _zoomRatio),(int)(_trainingSet.clippingSize.Height * _zoomRatio));
          _sampleEditor.vScrollBar_Scroll(null,null);
          _sampleEditor.hScrollBar_Scroll(null,null);
          _sampleEditor.sample.Invalidate();
          break;
      }
    }

    private void sample_Paint(object sender,PaintEventArgs e) {
      if(_sampleGraphics != null) {
        _sampleGraphics.Dispose();
        _sampleGraphics = null;
      }
      _sampleGraphics = e.Graphics;

      _sampleGraphics.Clear(Color.White);
      if(_selectedImage != null) {
        Pen dashedPen = new Pen(Color.GreenYellow,1);
        dashedPen.DashCap    = DashCap.Flat;
        dashedPen.DashStyle  = DashStyle.Dash;

        // Draw The Image
        _sampleGraphics.DrawImage(_selectedImage,0,0,_sampleEditor.sample.Size.Width,_sampleEditor.sample.Size.Height);

        // Draw The Line
        int i,j;
        double xi,yi,xj,yj;
        for(i=0;i<_trainingSet.numPoints;i++) {
          xi = _trainingSet.activeSample[i][0] * _zoomRatio;
          yi = _trainingSet.activeSample[i][1] * _zoomRatio;
          if(_trainingSet.isSelected[i]) {
            xi+=_diffX;yi+=_diffY;
          }
          for(j=0;j<i;j++)
            if(_trainingSet.isConnected(i,j)) {
              xj = _trainingSet.activeSample[j][0] * _zoomRatio;
              yj = _trainingSet.activeSample[j][1] * _zoomRatio;
              if(_trainingSet.isSelected[j]) {
                xj+=_diffX;yj+=_diffY;
              }
              _sampleGraphics.DrawLine(
                Pens.LightBlue,
                (float)xi,(float)yi,(float)xj,(float)yj);
            }
        }

        // Draw The Point
        for(i=0;i<_trainingSet.numPoints;i++) {
          xi = _trainingSet.activeSample[i][0] * _zoomRatio - 2;
          yi = _trainingSet.activeSample[i][1] * _zoomRatio - 2;
          if(_trainingSet.isSelected[i])
            _sampleGraphics.FillRectangle(
              Brushes.Red,
              (float)xi+_diffX,(float)yi+_diffY,5,5);
          else
            _sampleGraphics.FillRectangle(
              Brushes.Green,
              (float)xi,(float)yi,5,5);
        }

        // Draw New Line
        if(_isDrawing)
          _sampleGraphics.DrawLine(
            Pens.LightBlue,
            _X1,_Y1,_X2,_Y2);

        // Draw Selection Rectangle
        if(_isSelecting) {
          xi = _X1;xj = _X2;
          yi = _Y1;yj = _Y2;
          if(_X2 < _X1) {
            xi  = _X2;xj = _X1;
          }
          if(_Y2 < _Y1) {
            yi = _Y2;yj = _Y1;
          }
          _sampleGraphics.DrawRectangle(
            dashedPen,
            (float)xi,(float)yi,(float)(xj-xi),(float)(yj-yi)
            );
        }

        //Draw Bounding Rect
        _sampleGraphics.DrawRectangle(
          dashedPen,
          (float)(_boundX1*_zoomRatio + _diffX - 2),
          (float)(_boundY1*_zoomRatio + _diffY - 2),
          (float)((_boundX2-_boundX1) * _zoomRatio + 5),
          (float)((_boundY2-_boundY1) * _zoomRatio + 5)
        );
      }
    }

    private void sample_MouseDown(object sender,MouseEventArgs e) {
      if(_selectedIdx == -1) return;

      if(e.Button == MouseButtons.Left) {
        if(_detailed.toolsSelected == CDetailedForm.TTools.LINE) {
          if(!_isDrawing) {
            // First Line
            _isDrawing = true;
            CSettings.ISSAVED = false;
            _X1 = _X2 = e.X;
            _Y1 = _Y2 = e.Y;
          }
        }else if(_detailed.toolsSelected == CDetailedForm.TTools.POINTER) {
          _X1 = _X2 = e.X;
          _Y1 = _Y2 = e.Y;
          
          if((_X1-(_boundX1*_zoomRatio-2)) >= 10e-6 && ((_boundX2*_zoomRatio+5)-_X1) >= 10e-6 &&
             (_Y1-(_boundY1*_zoomRatio-2)) >= 10e-6 && ((_boundY2*_zoomRatio+5)-_Y1) >= 10e-6)
            _isMoving = true;
          else{
            _boundX1 = _boundY1 = _boundX2 = _boundY2 = -1;
            _trainingSet.diselectAll();
            _isSelecting = true;
          }
        }
      }
    }

    private void sample_MouseMove(object sender,MouseEventArgs e) {
      statusXY.Text = "(X,Y) = (" + e.X + ", " + e.Y + ")";
        
      if(_selectedIdx == -1) return;
      if(_isDrawing || _isMoving || _isSelecting) {
        _X2 = e.X;
        _Y2 = e.Y;
        if(_isMoving) {
          _diffX = _X2 - _X1;
          _diffY = _Y2 - _Y1;
        }
        _sampleEditor.sample.Invalidate();
      }
    }

    private void sample_MouseUp(object sender,MouseEventArgs e) {
      if(_selectedIdx == -1) return;
      _X2 = e.X;
      _Y2 = e.Y;
      if(_isDrawing) {
        if(_detailed.toolsSelected == CDetailedForm.TTools.LINE) {
          if(_X1 == _X2 && _Y1 == _Y2) {
            // The Mouse Doesn't Move, Don't Add!
          }else{
            // Add Line To Training Set
            double x1 = _X1/_zoomRatio;
            double x2 = _X2/_zoomRatio;
            double y1 = _Y1/_zoomRatio;
            double y2 = _Y2/_zoomRatio;

            int idx1 = _trainingSet.isPointExist(x1,y1);
            if(idx1 == -1) idx1 = _trainingSet.addPoint(x1,y1);
            int idx2 = _trainingSet.isPointExist(x2,y2);
            if(idx2 == -1) idx2 = _trainingSet.addPoint(x2,y2);

            _trainingSet.connect(idx1,idx2,true);
            CSettings.ISSAVED = false;
          }
        }
        _X1 = _X2;
        _Y1 = _Y2;
        if(e.Button == MouseButtons.Right) {
          _isDrawing = false;
          _X1 = _X2 = -1;
          _Y1 = _Y2 = -1;
        }

        _detailed.Invalidate();
        _sampleEditor.sample.Invalidate();
        return;
      }else if(_isMoving) {
        _isMoving = false;
        _trainingSet.moveSelectedPoint(_diffX/_zoomRatio,_diffY/_zoomRatio);
        _boundX1 += _diffX/_zoomRatio;
        _boundX2 += _diffX/_zoomRatio;
        _boundY1 += _diffY/_zoomRatio;
        _boundY2 += _diffY/_zoomRatio;
        _diffX = 0;_diffY = 0;
        //_trainingSet.removeDuplicatePoint();
        CSettings.ISSAVED = false;
      }else if(_isSelecting) {
        _isSelecting = false;
        double x1 = _X1/_zoomRatio;
        double x2 = _X2/_zoomRatio;
        double y1 = _Y1/_zoomRatio;
        double y2 = _Y2/_zoomRatio;
        if((_X1 - _X2) >= 10e-6) { 
          x1 = _X2/_zoomRatio;
          x2 = _X1/_zoomRatio;
        }else{
          x1 = _X1/_zoomRatio;
          x2 = _X2/_zoomRatio;
        }
        if((_Y1 - _Y2) >= 10e-6) { 
          y1 = _Y2/_zoomRatio;
          y2 = _Y1/_zoomRatio;
        }else{
          y1 = _Y1/_zoomRatio;
          y2 = _Y2/_zoomRatio;
        }

        _trainingSet.selectAllInArea(x1,y1,x2,y2);
        updateBoundingRect();
      }
      _X1 = _X2 = -1;
      _Y1 = _Y2 = -1;
      _isUpdating = false;
      _detailed.Invalidate();
      _sampleEditor.sample.Invalidate();
    }

    private void buttonFirstFrame_Click(object sender, EventArgs e) {
      if(_trainingSet.numSamples > 0)
        _sampleList.sampleImageList.Items[0].Selected = true;
    }

    private void buttonBackward_Click(object sender, EventArgs e) {
      int idx = _trainingSet.activeSampleIdx-1;
      if(idx >= 0)
        _sampleList.sampleImageList.Items[idx].Selected = true;
    }

    private void buttonForward_Click(object sender, EventArgs e) {
      int idx = _trainingSet.activeSampleIdx+1;
      if(idx < _trainingSet.numSamples)
        _sampleList.sampleImageList.Items[idx].Selected = true;
    }

    private void buttonLastFrame_Click(object sender, EventArgs e) {
      if(_trainingSet.numSamples > 0)
        _sampleList.sampleImageList.Items[_trainingSet.numSamples-1].Selected = true;
    }

    #endregion

    #region "CSampleListForm Event Handler"

    private void btnAddImage_Click(object sender, EventArgs e) {
      if(_trainingSet == null) return;

      CClippingForm   _clipping     = new CClippingForm();

      // Select Image
      openFileDialog.FileName = "";
      openFileDialog.Filter = "Picture Files (*.bmp,*.jpeg,*.jp?,*.png,*.emf,*.exif,*.ico,*.tiff,*.wmf)|*.bmp;*.jpeg;*.jp?;*.png;*.emf;*.exif;*.ico;*.tiff;*.wmf";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.Cancel)
        return;

      // Clip Image
      if(_clipping.fullImage != null) {
        _clipping.fullImage.Dispose();
        _clipping.fullImage = null;
      }
      _clipping.fullImage = Image.FromFile(openFileDialog.FileName);
      _clipping.clippedImage = new Bitmap(_trainingSet.clippingSize.Width,_trainingSet.clippingSize.Height);

      _clipping.clippedRect = new Rectangle(
        (CSettings.MAXCLIPSIZE.Width  - _trainingSet.clippingSize.Width) / 2,
        (CSettings.MAXCLIPSIZE.Height - _trainingSet.clippingSize.Height) / 2,
        _trainingSet.clippingSize.Width,
        _trainingSet.clippingSize.Height);
      _clipping.clippedLocation = new Point(
          (CSettings.MAXCLIPSIZE.Width  - _clipping.fullImage.Width) / 2,
          (CSettings.MAXCLIPSIZE.Height - _clipping.fullImage.Height) / 2
        );

      result = _clipping.ShowDialog();

      if(result == DialogResult.OK) {
        // Add Image
        int n;
        _trainingSet.addSample(_clipping.clippedImage);
        n = addImage(_clipping.clippedImage);
        _sampleList.sampleImageList.Items[n].Selected = true;
        
        CSettings.ISSAVED = false;
      }
      _sampleEditor.Focus();
    }

    private void btnRemoveImage_Click(object sender, EventArgs e) {
      int i,n = _sampleList.sampleImageList.Items.Count;

      if(_selectedIdx == -1 || _selectedIdx >= n) return;

      // hapus dari form
      _sampleList.sampleImagesSmall.Images.RemoveAt(_selectedIdx);
      _sampleList.sampleImageList.Items.RemoveAt(_selectedIdx);
      n--;
      for(i = _selectedIdx;i<n;i++) {
        _sampleList.sampleImageList.Items[i].ImageIndex = i;
        _sampleList.sampleImageList.Items[i].SubItems.Clear();
        _sampleList.sampleImageList.Items[i].SubItems.Add(((int)(i+1)).ToString());
      }

      // hapus dari training set
      _trainingSet.removeSample(_selectedIdx);

      if(_selectedIdx >= n)
        _selectedIdx--;
      _sampleEditor.numFrame.Text = ((int)(_selectedIdx+1)).ToString() + "/" + _trainingSet.numSamples.ToString();
      _trainingSet.activeSampleIdx = _selectedIdx;
      if(_selectedIdx != -1) {
        _sampleList.sampleImageList.Items[_selectedIdx].Selected = true;
        _selectedImage = _trainingSet.activeSampleImage;
      }else
        _selectedImage = null;

      // update form
      _detailed.Invalidate();
      _sampleEditor.sample.Refresh();
      _sampleEditor.Focus();
      CSettings.ISSAVED = false;
    }

    private void sampleImageList_SelectedIndexChanged(object sender, EventArgs e) {
      if(_sampleList.sampleImageList.SelectedIndices.Count == 1) {
        int currIdx = _sampleList.sampleImageList.SelectedIndices[0]; 
        if(_selectedIdx != currIdx) {
          _selectedIdx = currIdx;
          _sampleEditor.numFrame.Text = ((int)(_selectedIdx+1)).ToString() + "/" + _trainingSet.numSamples.ToString();
          _trainingSet.activeSampleIdx = _selectedIdx;
          _selectedImage = _trainingSet.activeSampleImage;
          updateBoundingRect();
          _sampleEditor.sample.Refresh();
          _detailed.Invalidate();
        }
        _sampleEditor.Show();
      }
    }

    #endregion

    #region "CDoTrainingForm Event Handler"

    private void trainingSetImage_Paint(object sender, PaintEventArgs e) {
      if(_sampleGraphics != null) {
        _sampleGraphics.Dispose();
        _sampleGraphics = null;
      }
      _sampleGraphics = e.Graphics;
      _sampleGraphics.Clear(Color.White);
      int s,i,j;
      int xc = _doTraining.trainingSetImage.Width/2;
      int yc = _doTraining.trainingSetImage.Height/2;
      switch(_doTraining.trainingStats) {
        case CDoTrainingForm.TTrainingStats.STARTING :
          // Draw The Original Label
          xc -= _trainingSet.clippingSize.Width/2;
          yc -= _trainingSet.clippingSize.Height/2;
          for(i=0;i<_trainingSet.numPoints;i++)
            for(j=0;j<i;j++)
              if(_trainingSet.isConnected(i,j))
                for(s=0;s<_trainingSet.numSamples;s++) {
                  CSample buff = (CSample)_trainingSet.sample[s];
                  _sampleGraphics.DrawLine(
                    Pens.Black,
                    (float)buff[i][0] + xc,(float)buff[i][1] + yc,
                    (float)buff[j][0] + xc,(float)buff[j][1] + yc);
                }
          break;
        case CDoTrainingForm.TTrainingStats.STARTED :
          // Draw The Mean & Trained Label
          for(i=0;i<_trainingSet.numPoints;i++)
            for(j=0;j<i;j++)
              if(_trainingSet.isConnected(i,j)) {
                for(s=0;s<_trainingSet.numSamples;s++) {
                  CXYVector buff = _trainingSet.trainingData[s];
                  _sampleGraphics.DrawLine(
                    Pens.DarkGray,
                    (float)buff[i][0] + xc,(float)buff[i][1]+yc,
                    (float)buff[j][0] + xc,(float)buff[j][1]+yc);
                }
                _sampleGraphics.DrawLine(
                  Pens.Red,
                  (float)_trainingSet.mean[i][0] + xc,(float)_trainingSet.mean[i][1] + yc,
                  (float)_trainingSet.mean[j][0] + xc,(float)_trainingSet.mean[j][1] + yc);
              }
          break;
        case CDoTrainingForm.TTrainingStats.MANUAL_ORIENTATION :
          // Convert X1-2 & Y1-2 To Degree
          double  k1 = CVector2.length2(_X1,_Y1,_X2,_Y2);
          double  k2 = CVector2.length (_X1,_Y1, xc, yc);
          double  k3 = CVector2.length2( xc, yc,_X2,_Y2);
          double  x  = ((k1+k2*k2-k3)/(2*k2));
          double  h  = Math.Sqrt(k1-(x*x));
          double  y  = (k2-x);
          CVector2 p1 = new CVector2(_X1 - xc,_Y1 - yc);
          CVector2 p2 = new CVector2(_X2 - xc,_Y2 - yc);
          _diffAngle = Math.Atan(h/y);
          if(_diffAngle<0) _diffAngle+=Math.PI;
          _diffAngle *= isTurnLeft(p1,p2);

          // Make The Rotation Matrix
          double angle = _orientationAngle + _diffAngle;
          double cosA  = Math.Cos(angle);
          double sinA  = Math.Sin(angle);
          CMatrix3x3 rotMat = new CMatrix3x3(
                                new CVector3(cosA,-sinA,0),
                                new CVector3(sinA,cosA, 0),
                                new CVector3(   0,   0, 1));

          // Draw The Mean & Trained Label In Respect To The Manual Rotation
          CXYVector   rotatedMean    = new CXYVector(_trainingSet.mean);
          CXYVector[] rotatedSamples = new CXYVector[_trainingSet.numSamples];
          for(s=0;s<_trainingSet.numSamples;s++) {
            rotatedSamples[s] = new CXYVector(_trainingSet.trainingData[s]);
            rotatedSamples[s].transform(rotMat);
          }
          for(i=0;i<_trainingSet.numPoints;i++) {
            rotatedMean[i].transform(rotMat);
            for(j=0;j<i;j++)
              if(_trainingSet.isConnected(i,j)) {
                for(s=0;s<_trainingSet.numSamples;s++) {
                  _sampleGraphics.DrawLine(
                    Pens.DarkGray,
                    (float)rotatedSamples[s][i][0] + xc,(float)rotatedSamples[s][i][1] + yc,
                    (float)rotatedSamples[s][j][0] + xc,(float)rotatedSamples[s][j][1] + yc);
                }
                _sampleGraphics.DrawLine(
                  Pens.Red,
                  (float)rotatedMean[i][0] + xc,(float)rotatedMean[i][1] + yc,
                  (float)rotatedMean[j][0] + xc,(float)rotatedMean[j][1] + yc);
              }
          }

          break;
        case CDoTrainingForm.TTrainingStats.FINISHED :
          // Draw The Mean Label Only With Respect To Parameter
          // Get The Parameter
          double []param = new double[5];
          param[0] = _doTraining.b1.Value / 1000f * _trainingResult.sqrtEigenValues[0];
          param[1] = _doTraining.b2.Value / 1000f * _trainingResult.sqrtEigenValues[1];
          param[2] = _doTraining.b3.Value / 1000f * _trainingResult.sqrtEigenValues[2];
          param[3] = _doTraining.b4.Value / 1000f * _trainingResult.sqrtEigenValues[3];
          param[4] = _doTraining.b5.Value / 1000f * _trainingResult.sqrtEigenValues[4];

          CXYVector newShape = _trainingResult.generateNewVariation(5,param);

          if(_isDrawTrainingData)
            for(s=0;s<_trainingSet.numSamples;s++)
              for(i=0;i<_trainingResult.numPoints;i++)
                for(j=0;j<i;j++)
                  if(_trainingResult.isConnected(i,j))
                    _sampleGraphics.DrawLine(
                      Pens.DarkGray,
                      (float)_trainingSet.trainingData[s][i][0] + xc,(float)_trainingSet.trainingData[s][i][1] + yc,
                      (float)_trainingSet.trainingData[s][j][0] + xc,(float)_trainingSet.trainingData[s][j][1] + yc);
          for(i=0;i<_trainingResult.numPoints;i++)
            for(j=0;j<i;j++)
              if(_trainingResult.isConnected(i,j))
                _sampleGraphics.DrawLine(
                  Pens.Red,
                  (float)newShape[i][0] + xc,(float)newShape[i][1] + yc,
                  (float)newShape[j][0] + xc,(float)newShape[j][1] + yc);
 
          break;
      }
    }

    private void trainingSetImage_MouseDown(object sender,MouseEventArgs e) {
      if(_doTraining.trainingStats == CDoTrainingForm.TTrainingStats.MANUAL_ORIENTATION) {
        _X1 = e.X;
        _Y1 = e.Y;
        _isRotating = true;
      }
    }

    private void trainingSetImage_MouseMove(object sender,MouseEventArgs e) {
      if(_doTraining.trainingStats == CDoTrainingForm.TTrainingStats.MANUAL_ORIENTATION && _isRotating) {
        _X2 = e.X;
        _Y2 = e.Y;
        _doTraining.trainingSetImage.Refresh();
      }
    }

    private void trainingSetImage_MouseUp(object sender,MouseEventArgs e) {
      if(_doTraining.trainingStats == CDoTrainingForm.TTrainingStats.MANUAL_ORIENTATION && _isRotating) {
        _X2 = e.X;
        _Y2 = e.Y;
        _doTraining.trainingSetImage.Refresh();
        _orientationAngle += _diffAngle;
        _diffAngle = 0;
        _isRotating = false;
      }
    }

    private void btnStart_Click(object sender,EventArgs e) {
      long time;
      switch(_doTraining.trainingStats) {
        case CDoTrainingForm.TTrainingStats.STARTING :
          _doTraining.trainingStats = CDoTrainingForm.TTrainingStats.STARTED;
          _doTraining.btnStart.Enabled = false;

          int numSamples = _trainingSet.numSamples,cnt=1;
          int modelSize = int.Parse(_doTraining.inputNormalSize.Text);;

          // Initialize
          _trainingSet.initializeTraining(modelSize);
          _doTraining.treeProgress.Nodes[0].Nodes[0].ImageIndex = 1;
          _doTraining.treeProgress.Refresh();
          System.Threading.Thread.Sleep(int.Parse(_doTraining.inputDelay.Text));
          _summary.listAlignment.Items.Clear();

          // Align And Realign
          while(!_trainingSet.isConverge()) {
            _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[0].ImageIndex = 0;
            _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[1].ImageIndex = 0;
            _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[2].ImageIndex = 0;

            time = _trainingSet.realignAll();

            _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[0].ImageIndex = 1;
            _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[1].ImageIndex = 1;
            _doTraining.treeProgress.Refresh();
            System.Threading.Thread.Sleep(int.Parse(_doTraining.inputDelay.Text));

            _trainingSet.normalizeMean();
            
            _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[2].ImageIndex = 1;
            _doTraining.treeProgress.Refresh();
            _doTraining.trainingSetImage.Refresh();
            System.Threading.Thread.Sleep(int.Parse(_doTraining.inputDelay.Text));

            _summary.listAlignment.Items.Add(cnt.ToString());
            _summary.listAlignment.Items[cnt-1].SubItems.Add(_trainingSet.energy.ToString());
            _summary.listAlignment.Items[cnt-1].SubItems.Add(((double)time / 1000.0).ToString("f5"));
            cnt++;
          }
          _doTraining.treeProgress.Nodes[0].Nodes[1].Nodes[3].ImageIndex = 1;
          _doTraining.treeProgress.Nodes[0].Nodes[1].ImageIndex = 1;
          _doTraining.treeProgress.Refresh();

          _doTraining.trainingStats = CDoTrainingForm.TTrainingStats.MANUAL_ORIENTATION;
          _doTraining.btnStart.Enabled = true;
          _doTraining.btnStart.Text    = "Resume";

          _summary.textNumberOfAlignment.Text = ((int)(cnt-1)).ToString();
          break;
        case CDoTrainingForm.TTrainingStats.MANUAL_ORIENTATION :
          // Manual Orientation Done, Save Changes...
          // Make The Rotation Matrix
          double angle = _orientationAngle + _diffAngle;
          double cosA  = Math.Cos(angle);
          double sinA  = Math.Sin(angle);
          CMatrix3x3 rotMat = new CMatrix3x3(
                                new CVector3(cosA,-sinA,0),
                                new CVector3(sinA,cosA, 0),
                                new CVector3(   0,   0, 1));

          for(int i = 0;i<_trainingSet.numPoints;i++) {
            _trainingSet.mean[i].transform(rotMat);
            for(int s = 0;s<_trainingSet.numSamples;s++)
            _trainingSet.trainingData[s][i].transform(rotMat);
          }

          // Training Data is Finally Converged...
          _doTraining.trainingStats = CDoTrainingForm.TTrainingStats.CONVERGED;
          _doTraining.treeProgress.Nodes[0].Nodes[2].ImageIndex = 1;
          _doTraining.btnStart.PerformClick();
          _doTraining.btnStart.Enabled = false;
          break;
        case CDoTrainingForm.TTrainingStats.CONVERGED :
          // Mean Sample Is Converge Do PCA
          _trainingResult = _trainingSet.principalComponentAnalysis(_trainingSet.clippingSize,out time);
          _doTraining.treeProgress.Nodes[0].Nodes[3].ImageIndex = 1;
          _doTraining.treeProgress.Nodes[0].ImageIndex = 1;
          _doTraining.treeProgress.Refresh();
          _doTraining.trainingStats = CDoTrainingForm.TTrainingStats.FINISHED;

          _doTraining.btnStart.Text    = "View Result";
          _doTraining.btnStart.Enabled = true;
          
          _doTraining.btnSavePDM.Enabled = true;

          _doTraining.b1.Enabled = true;
          _doTraining.b2.Enabled = true;
          _doTraining.b3.Enabled = true;
          _doTraining.b4.Enabled = true;
          _doTraining.b5.Enabled = true;

          _summary.textPCATime.Text = ((double)(time / 1000.0)).ToString("f5");

          _summary.ShowDialog();
          break;
        case CDoTrainingForm.TTrainingStats.FINISHED :
          _summary.ShowDialog();
          break;
      }
    }

    private void btnSavePDM_Click(object sender,EventArgs e) {
      saveFileDialog.Filter   = "Point Distribution Model Data (*.pdm) | *.pdm";
      saveFileDialog.FileName = "";
      if(saveFileDialog.ShowDialog() == DialogResult.OK) {
        if(_trainingResult != null)
          _trainingResult.saveToDisk(saveFileDialog.FileName);
      }
    }

    private void btnClose_Click(object sender,EventArgs e) {
      _doTraining.Hide();
      this.Show();
    }

    #endregion

    #region "Methods"

    private int addImage(Image newImage) {
      int newId = _sampleList.sampleImageList.Items.Count + 1;
      _sampleList.sampleImagesSmall.Images.Add(newImage);
      _sampleList.sampleImageList.Items.Add("");
      _sampleList.sampleImageList.Items[newId-1].ImageIndex = newId-1;
      _sampleList.sampleImageList.Items[newId-1].SubItems.Add(newId.ToString());

      return newId-1;
    }

    private void splitFullPath(string fullPath,out string path,out string filename) {
      int idx = fullPath.LastIndexOf('\\');
      int idx2 = fullPath.LastIndexOf('/');
      if(idx < idx2) idx = idx2;
      if(idx != -1) path = fullPath.Substring(0,idx);
      else path = "";
      path += "\\";
      filename = fullPath.Substring(idx+1);
    }

    private void isUnsaved() {
      // Save Previously Unsaved Training Set
      if(!CSettings.ISSAVED && _trainingSet != null) {
        DialogResult res2 = MessageBox.Show(
                             "Save Training Set " + _trainingSet.name + "?",
                             "Save Training Set?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

        if(res2 == DialogResult.Yes)
          _trainingSet.saveToDisk();
      }
    }

    private void reset() {
      // reset menu visibility to default value
      // menu->File
      menuFileNew.Enabled    = true;
      menuFileOpen.Enabled   = true;
      menuFileSave.Enabled   = false;
      menuFileSaveAs.Enabled = false;
      menuFileExit.Enabled   = true;

      // menu->Training Set
      menuTrainingSetStart.Enabled = false;

      // menu->Window
      menuWindowSampleList.Enabled = true;
      menuWindowVectorData.Enabled = true;

      // reset form visibility to default value
      _detailed.btnPointerTool.Enabled   = false;
      _detailed.btnLineTool.Enabled      = false;
      _sampleList.btnAddImage.Enabled    = false;
      _sampleList.btnRemoveImage.Enabled = false;

      //clear image, sample list, and point list
      //form detailed 
      _detailed.sampleVector.Clear();
      _detailed.sampleVector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            _detailed.colNo,
            _detailed.colX,
            _detailed.colY});

      //form sample list
      _sampleList.sampleImageList.Clear();
      _sampleList.sampleImageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            _sampleList.colImage,
            _sampleList.colName});
      _sampleList.sampleImagesSmall.Images.Clear();

      //form sample editor
      _sampleEditor.sample.Size = new Size(250,200);
      _sampleEditor.numFrame.Text = "0/0";

      if(_sampleGraphics!= null) {
        _sampleGraphics.Dispose();
        _sampleGraphics = null;
      }
      _sampleGraphics = _sampleEditor.sample.CreateGraphics();
      _sampleGraphics.Clear(Color.White);

      //reset attribute
      _sampleGraphics.Dispose();
      _sampleGraphics = null;

      if(_selectedImage != null) {
        _selectedImage.Dispose();
        _selectedImage = null;
      }
      if(_trainingSet != null) {
        _trainingSet.Dispose();
        _trainingSet = null;
      }

      CSettings.ISSAVED = true;
      _isDrawing = false;
      _isRotating = false;
      _X1 = _Y1 = _X2 = _Y2 = -1;
      _boundX1 = _boundY1 = _boundX2 = _boundY2 = -1;
      _orientationAngle = 0;
      _diffAngle = 0;
      _selectedIdx = -1;
      _zoomRatio = 1.0f;
    }

    private void updateBoundingRect() {
      _trainingSet.getSelectedBoundingRect(out _boundX1,out _boundY1,out _boundX2,out _boundY2);
    }

    private int isTurnLeft(CVector2 p1,CVector2 p2) {
	    double delta = ((p1[0] * p2[1]) - (p2[0] * p1[1]));
      if(delta > 10e-100) return 1;
      if(delta < -10e-100) return -1;
      return 0;
    }

    #endregion
  }
}