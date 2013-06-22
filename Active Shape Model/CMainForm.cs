// C# Library
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

// AForge.NET Library
using AForge.Imaging.Filters;

// My Library
using ASMLibrary;
using InputSource;
using LinearAlgebra;
using System.IO;

namespace Active_Shape_Model {
  public enum TDetectionMethod {
    NONE = 0,
    HOMOGENITY,
    DIFFERENCE,
    SOBEL,
    CANNY
  };

  public enum TFPSLimitMode {
    DEFAULT = 0,
    NOLIMIT,
    IVTCFILM,
    FILM,
    PAL,
    NTSC,
    CUSTOM
  };

  public partial class CMainForm : Form {
    // Form
    private CCaptureDeviceForm _captureDeviceForm;
    private CFPSForm           _fpsForm     = new CFPSForm();
    private CSettingsForm      _settingFrom = new CSettingsForm();
    private CAboutForm         _aboutForm   = new CAboutForm();

    // FPS
    private TFPSLimitMode _fpsLimitMode = TFPSLimitMode.DEFAULT;
    private bool          _isLimit      = true;
    private float         _fpsLimit     = -1;
    private Timer         _fpsTimer     = new Timer();

    // Input Processing
    private CInputSource       _inputSource;
    private FilterColorToGray  _edgeDetector;
    private TDetectionMethod   _detectionMethod = TDetectionMethod.HOMOGENITY;
    private bool               _showDetectedEdge;

    // ASM Engine
    private string            _pdmPath;
    private CActiveShapeModel _asmEngine;
    private float             _zoomRatioX,_zoomRatioY;
    private int               _iterateEvery;
    private Timer             _iterationTimer = new Timer();

    public CMainForm() {
      InitializeComponent();

      CSettings.APPDIR   = Directory.GetCurrentDirectory();

      _inputSource = new CInputSource(cameraWindow);
      _inputSource.postRenderingEvent = new PostRendering(postrendering);
      _inputSource.preRenderingEvent  = new PreRendering(prerendering);
      _edgeDetector = _edgeDetector = new HomogenityEdgeDetector();
      _fpsTimer.Interval = 250;
      _fpsTimer.Tick += new EventHandler(_fpsTimer_Tick);
      _pdmPath = CSettings.APPDIR + "\\last.pdm";
      _asmEngine = new CActiveShapeModel(_pdmPath);
      _asmEngine.detectionLimit = 10;
      _iterateEvery = 1;
      _iterationTimer.Interval = 100;
      _iterationTimer.Tick +=new EventHandler(_iterationTimer_Tick);
      loadSetting();
    }

    private void CMainForm_FormClosing(object sender,FormClosingEventArgs e) {
      buttonStop_Click(null,null);
    }

    private void CMainForm_KeyDown(object sender,KeyEventArgs e) {
      switch(e.KeyCode) {
        case Keys.Space    : 
          if(buttonPlay.Enabled || buttonPause.Enabled)
            menuPlaybackPlayPause_Click(null,null);
          break;
        case Keys.PageUp   : 
          if(buttonGoToFirst.Enabled)
            buttonGoToFirst_Click(null,null);
          break;
        case Keys.PageDown :
          if(buttonGoToLast.Enabled)
            buttonGoToLast_Click(null,null);
          break;
        case Keys.R :
          if(e.Control)
            _asmEngine.resetModel();
          break;
      }
    }

    #region "Main Menu Event Handler"

    private void menuFileOpenFile_Click(object sender, EventArgs e) {
      openFileDialog.FileName = "";
      openFileDialog.Filter   = "Picture Files (*.bmp,*.gif,*.jpeg,*.jp?,*.png,*.emf,*.exif,*.ico,*.tiff,*.wmf)|*.bmp;*.gif;*.jpeg;*.jp?;*.png;*.emf;*.exif;*.ico;*.tiff;*.wmf";
      openFileDialog.Filter  += "|Video Files (*.avi)|*.avi";
      DialogResult result     = openFileDialog.ShowDialog();
      if(result == DialogResult.Cancel)
        return;
      
      try
      {
        TInputType type = TInputType.UNKNOWN;
        reset();
        if(openFileDialog.FilterIndex==1) {
          type = TInputType.IMAGE;
          statusInputType.Text = "Image";
          buttonPlay.Enabled      = false;
          buttonPause.Enabled     = false;
          buttonStop.Enabled      = false;
          buttonGoToFirst.Enabled = false;
          buttonBackward.Enabled  = false;
          buttonForward.Enabled   = false;
          buttonGoToLast.Enabled  = false;
        } else if (openFileDialog.FilterIndex==2) {
          type = TInputType.VIDEO;
          statusInputType.Text = "Video";
          buttonPlay_Click(null,null);
          buttonGoToFirst.Enabled = true;
          buttonBackward.Enabled  = true;
          buttonForward.Enabled   = true;
          buttonGoToLast.Enabled  = true;
        }
        _asmEngine.resetModel();
        _inputSource.openInputSource(openFileDialog.FileName,type,true);
        _inputSource.setFps(_isLimit,_fpsLimit);
        videoProgress.Minimum = 0;
        videoProgress.Maximum = _inputSource.length;
        videoProgress.Value   = 0;
      }catch(Exception exc) {
        MessageBox.Show(exc.Message);
        statusInputType.Text = "NONE";
      }
    }

    private void menuFileOpenDevice_Click(object sender, EventArgs e) {
      _captureDeviceForm = new CCaptureDeviceForm();
      DialogResult result = _captureDeviceForm.ShowDialog();
      if(result == DialogResult.OK) {
        try
        {
          _asmEngine.resetModel();
          _inputSource.openInputSource(_captureDeviceForm.Device,TInputType.DEVICE,true);
          statusInputType.Text = "Device";
          buttonPlay_Click(null,null);
          buttonGoToFirst.Enabled = false;
          buttonBackward.Enabled  = false;
          buttonForward.Enabled   = false;
          buttonGoToLast.Enabled  = false;
        } catch(Exception exc) {
          MessageBox.Show(exc.Message);
          statusInputType.Text = "NONE";
        }
      }
       _captureDeviceForm.Dispose();
    }

    private void menuFileClose_Click(object sender,EventArgs e) {
      buttonStop_Click(null,null);
      _inputSource.closeInputSource();
      reset();
    }

    private void menuFileExit_Click(object sender, EventArgs e) {
      Close();
    }

    private void menuPlayback_DropDownOpened(object sender,EventArgs e) {
      menuPlaybackPlayPause.Enabled = buttonPlay.Enabled || buttonPause.Enabled;
      menuPlaybackStop.Enabled      = buttonStop.Enabled;
      menuPlaybackGoToFirst.Enabled = buttonGoToFirst.Enabled;
      menuPlaybackGoToLast.Enabled  = buttonGoToLast.Enabled;
      menuPlaybackBackward.Enabled  = buttonBackward.Enabled;
      menuPlaybackForward.Enabled   = buttonForward.Enabled;
    }

    private void menuPlaybackPlayPause_Click(object sender,EventArgs e) {
      if(_inputSource.playbackStatus == TPlaybackStatus.PLAYING)
        buttonPause_Click(null,null);
      else
        buttonPlay_Click(null,null);
    }

    private void menuSettingsPDM_Click(object sender, EventArgs e) {
      buttonPause_Click(sender,e);
      openFileDialog.FileName = "";
      openFileDialog.Filter   = "Model Files (*.pdm)|*.pdm";
      DialogResult result     = openFileDialog.ShowDialog();
      if(result == DialogResult.Cancel)
        return;

      File.Copy(openFileDialog.FileName,_pdmPath,true);
      CPointDistributionModel newPDM = CPointDistributionModel.open(openFileDialog.FileName);
      if(newPDM == null) {
        System.Windows.Forms.MessageBox.Show("Model File Not Found or Corrupted!","Cannot Open File!");
      }else{
        _asmEngine.PDMData = newPDM;
      }
      buttonPlay_Click(sender,e);
    }

    private void menuSettings_DropDownOpened(object sender,EventArgs e) {
      menuSettingsFPS.Enabled = (_inputSource.inputType == TInputType.VIDEO);
    }

    private void menuSettingsEDM_DropDownOpened(object sender,EventArgs e) {
      menuSettingsEDMNone.Checked       = false;
      menuSettingsEDMCanny.Checked      = false;
      menuSettingsEDMDifference.Checked = false;
      menuSettingsEDMHomogenity.Checked = false;
      menuSettingsEDMSobel.Checked      = false;
      switch(_detectionMethod) {
        case TDetectionMethod.NONE :
          menuSettingsEDMNone.Checked       = true;
          break;
        case TDetectionMethod.CANNY :
          menuSettingsEDMCanny.Checked      = true;
          break;
        case TDetectionMethod.DIFFERENCE :
          menuSettingsEDMDifference.Checked = true;
          break;
        case TDetectionMethod.HOMOGENITY :
          menuSettingsEDMHomogenity.Checked = true;
          break;
        case TDetectionMethod.SOBEL :
          menuSettingsEDMSobel.Checked      = true;
          break;
      }
    }

    private void menuSettingsEDMNone_Click(object sender,EventArgs e) {
      _edgeDetector    = null;
      _detectionMethod = TDetectionMethod.NONE;
    }

    private void menuSettingsEDMHomogenity_Click(object sender,EventArgs e) {
      _edgeDetector = new HomogenityEdgeDetector();
      _detectionMethod = TDetectionMethod.HOMOGENITY;
      cameraWindow.Invalidate();
    }

    private void menuSettingsEDMDifference_Click(object sender,EventArgs e) {
      _edgeDetector = new DifferenceEdgeDetector();
      _detectionMethod = TDetectionMethod.DIFFERENCE;
      cameraWindow.Invalidate();
    }

    private void menuSettingsEDMSobel_Click(object sender,EventArgs e) {
      _edgeDetector = new SobelEdgeDetector();
      _detectionMethod = TDetectionMethod.SOBEL;
      cameraWindow.Invalidate();
    }

    private void menuSettingsEDMCanny_Click(object sender,EventArgs e) {
      _edgeDetector = new CannyEdgeDetector();
      _detectionMethod = TDetectionMethod.CANNY;
      cameraWindow.Invalidate();
    }

    private void menuSettingsFPS_DropDownOpened(object sender,EventArgs e) {
      menuSettingsFPSDefault.Checked  = false;
      menuSettingsFPSNoLimit.Checked  = false;
      menuSettingsFPSIVTCFilm.Checked = false;
      menuSettingsFPSFilm.Checked     = false;
      menuSettingsFPSPal.Checked      = false;
      menuSettingsFPSNTSC.Checked     = false;
      menuSettingsFPSCustom.Checked   = false;
      switch(_fpsLimitMode) {
        case TFPSLimitMode.DEFAULT :
          menuSettingsFPSDefault.Checked  = true;
          break;
        case TFPSLimitMode.NOLIMIT :
          menuSettingsFPSNoLimit.Checked  = true;
          break;
        case TFPSLimitMode.IVTCFILM :
          menuSettingsFPSIVTCFilm.Checked = true;
          break;
        case TFPSLimitMode.FILM :
          menuSettingsFPSFilm.Checked     = true;
          break;
        case TFPSLimitMode.PAL :
          menuSettingsFPSPal.Checked      = true;
          break;
        case TFPSLimitMode.NTSC :
          menuSettingsFPSNTSC.Checked     = true;
          break;
        case TFPSLimitMode.CUSTOM :
          menuSettingsFPSCustom.Checked   = true;
          break;
      }
    }

    private void menuSettingsFPSDefault_Click(object sender,EventArgs e) {
      _isLimit      = true;
      _fpsLimit     = -1;
      _fpsLimitMode = TFPSLimitMode.DEFAULT;
      _inputSource.setFps(_isLimit,_fpsLimit);
    }

    private void menuSettingsFPSNoLimit_Click(object sender,EventArgs e) {
      _isLimit      = false;
      _fpsLimit     = 0;
      _fpsLimitMode = TFPSLimitMode.NOLIMIT;
      _inputSource.setFps(_isLimit,_fpsLimit);
    }

    private void menuSettingsFPSIVTCFilm_Click(object sender,EventArgs e) {
      _isLimit      = true;
      _fpsLimit     = 23.976f;
      _fpsLimitMode = TFPSLimitMode.IVTCFILM;
      _inputSource.setFps(_isLimit,_fpsLimit);
    }

    private void menuSettingsFPSFilm_Click(object sender,EventArgs e) {
      _isLimit      = true;
      _fpsLimit     = 24;
      _fpsLimitMode = TFPSLimitMode.FILM;
      _inputSource.setFps(_isLimit,_fpsLimit);
    }

    private void menuSettingsFPSPal_Click(object sender,EventArgs e) {
      _isLimit      = true;
      _fpsLimit     = 25;
      _fpsLimitMode = TFPSLimitMode.PAL;
      _inputSource.setFps(_isLimit,_fpsLimit);
    }

    private void menuSettingsFPSNTSC_Click(object sender,EventArgs e) {
      _isLimit      = true;
      _fpsLimit     = 29.97f;
      _fpsLimitMode = TFPSLimitMode.NTSC;
      _inputSource.setFps(_isLimit,_fpsLimit);
    }

    private void menuSettingsFPSCustom_Click(object sender,EventArgs e) {
      if(_fpsForm.ShowDialog() == DialogResult.OK) {
        _isLimit      = true;
        _fpsLimit     = int.Parse(_fpsForm.fpsLimit.Text);
        _fpsLimitMode = TFPSLimitMode.CUSTOM;
        _inputSource.setFps(_isLimit,_fpsLimit);
      }
    }

    private void menuSettingsOptions_Click(object sender, EventArgs e) {
      buttonPause_Click(null,null);
      _settingFrom.textValuePointNum.Text      = _asmEngine.PDMData.numPoints.ToString();
      _settingFrom.textValueResolution.Text    = 
        _asmEngine.PDMData.clippingSize.Width.ToString() + " x " +
        _asmEngine.PDMData.clippingSize.Height.ToString();
      _settingFrom.textMaxMode.Text            = "(Max : " + _asmEngine.PDMData.numPoints.ToString() + ")";
      _settingFrom.inputFreedom.Text           = _asmEngine.PDMData.freedom.ToString();
      _settingFrom.inputCX.Text                = _asmEngine.cx.ToString();
      _settingFrom.inputCY.Text                = _asmEngine.cy.ToString();
      _settingFrom.cbUsePreviousResult.Checked = _asmEngine.usePreviousResult;
      _settingFrom.inputThreshold.Text         = _asmEngine.edgeThreshold.ToString();
      _settingFrom.inputLimit.Text             = _asmEngine.detectionLimit.ToString();
      _settingFrom.inputMaxStep.Text           = _asmEngine.maxStep.ToString();
      _settingFrom.cbShowDetectedEdge.Checked  = _showDetectedEdge;
      _settingFrom.cbShowIterationStep.Checked = (_iterateEvery > 0);
      _settingFrom.inputIterateEvery.Text      = _iterateEvery.ToString();
      _settingFrom.inputIterationDelay.Text    = _iterationTimer.Interval.ToString();
      if(_settingFrom.ShowDialog() == DialogResult.OK) {
        _asmEngine.PDMData.freedom   = int.Parse(_settingFrom.inputFreedom.Text);
        _asmEngine.cx                = int.Parse(_settingFrom.inputCX.Text);
        _asmEngine.cy                = int.Parse(_settingFrom.inputCY.Text);
        _asmEngine.usePreviousResult = _settingFrom.cbUsePreviousResult.Checked;
        _asmEngine.edgeThreshold     = int.Parse(_settingFrom.inputThreshold.Text);
        _asmEngine.detectionLimit    = int.Parse(_settingFrom.inputLimit.Text);
        _asmEngine.maxStep           = int.Parse(_settingFrom.inputMaxStep.Text);
        _showDetectedEdge            = _settingFrom.cbShowDetectedEdge.Checked;
        if(_settingFrom.cbShowIterationStep.Checked) {
          _iterateEvery                = int.Parse(_settingFrom.inputIterateEvery.Text);
          _iterationTimer.Interval     = int.Parse(_settingFrom.inputIterationDelay.Text);
        }else
          _iterateEvery = -1;
        saveSetting();
      }
      buttonPlay_Click(null,null);
    }

    private void menuHelpAbout_Click(object sender, EventArgs e) {
      buttonPause_Click(null,null);
      _aboutForm.ShowDialog();
      buttonPlay_Click(null,null);
    }

    #endregion

    #region "Playback Control Event Handler"

    private void buttonPlay_Click(object sender, EventArgs e) {
      try
      {
        _inputSource.play();
        _fpsTimer.Start();
        buttonPlay.Enabled = false;
        buttonPause.Enabled = true;
        buttonStop.Enabled = true;
      }catch(Exception exc) {
        MessageBox.Show(exc.Message);
      }
    }

    private void buttonPause_Click(object sender, EventArgs e) {
      _inputSource.pause();
      _fpsTimer.Stop();
      buttonPlay.Enabled  = true;
      buttonPause.Enabled = false;
      buttonStop.Enabled  = true;
    }

    private void buttonStop_Click(object sender, EventArgs e) {
      _inputSource.stop();
      _fpsTimer.Stop();
      buttonPlay.Enabled  = true;
      buttonPause.Enabled = false;
      buttonStop.Enabled  = false;
    }

    private void buttonGoToFirst_Click(object sender,EventArgs e) {
      _inputSource.position = 0;
    }

    private void buttonBackward_Click(object sender,EventArgs e) {
      _inputSource.decreaseVideoSpeed();
    }

    private void buttonForward_Click(object sender,EventArgs e) {
      _inputSource.increaseVideoSpeed();
    }

    private void buttonGoToLast_Click(object sender,EventArgs e) {
      _inputSource.position = _inputSource.length;
    }

    #endregion
    
    private void videoProgress_ValueChanged(object sender,decimal value) {
      _inputSource.position = videoProgress.Value;
    }

    private void _fpsTimer_Tick(object sender,EventArgs e) {
      videoStatus.Text = "Playing (FPS : " + _inputSource.fps.ToString("F2") + " @ " + _inputSource.videoSpeed +")";
      if(_inputSource.inputType == TInputType.VIDEO) {
        numFrame.Text = _inputSource.position + "/" + _inputSource.length;
        videoProgress.Value = _inputSource.position;
        if(videoProgress.Value == videoProgress.Maximum)
          buttonPause_Click(null,null);
      }
      Invalidate(true);
    }

    private void _iterationTimer_Tick(object sender, EventArgs e) {
      int i;
      for(i=0;i<_iterateEvery && (_asmEngine.step < _asmEngine.maxStep) && !_asmEngine.isConverge();i++) {
        _asmEngine.doStep();
        numFrame.Text = _asmEngine.step.ToString();
      }
      cameraWindow.Invalidate();
      if(_asmEngine.step >= _asmEngine.maxStep || _asmEngine.isConverge()) _iterationTimer.Stop();
    }

    private void prerendering(ref Bitmap image) {
      if(image == null) return;
      if(_detectionMethod != TDetectionMethod.NONE) {
        Bitmap edges = _edgeDetector.Apply(image);
        if(_inputSource.inputType == TInputType.IMAGE && _iterateEvery > 0) {
          _asmEngine.resetSearch(edges);
          _iterationTimer.Start();
        }else
          _asmEngine.doSearch(edges);
        if(_showDetectedEdge) {
          image.Dispose();        
          image = edges;
        }
      }
    }

    private void postrendering(ref Graphics g) {
      if(g != null && _detectionMethod != TDetectionMethod.NONE) {
        // get zoomRatio
        _zoomRatioX = (float)_inputSource.cameraWindow.Width / _asmEngine.PDMData.clippingSize.Width;
        _zoomRatioY = (float)_inputSource.cameraWindow.Height / _asmEngine.PDMData.clippingSize.Height;

        // draw optimized shape
        CXYVector optimizedShape = _asmEngine.ASMResult;
        int       i,j;
        g.DrawRectangle(Pens.White,(float)_asmEngine.cx*_zoomRatioX-1,(float)_asmEngine.cy*_zoomRatioY-1,3,3);
        for(i=0;i<optimizedShape.size;i++) {
/*          CVector2 movement = CVector2.vNormal(_asmEngine.PDMData.mean[(i + optimizedShape.size - 1) % optimizedShape.size],
                  _asmEngine.PDMData.mean[i],
                  _asmEngine.PDMData.mean[(i + 1) % optimizedShape.size]);
          g.DrawLine(
            Pens.Yellow,
            (float)((_asmEngine.PDMData.mean[i][0]+_asmEngine.cx)*_zoomRatioX),
            (float)((_asmEngine.PDMData.mean[i][1]+_asmEngine.cy)*_zoomRatioY),
            (float)((_asmEngine.PDMData.mean[i][0]+_asmEngine.cx+movement[0]*10)*_zoomRatioX),
            (float)((_asmEngine.PDMData.mean[i][1]+_asmEngine.cy+movement[1]*10)*_zoomRatioY));*/
          for(j=0;j<i;j++)
            if(_asmEngine.isConnected(i,j)) {
/*              g.DrawLine(
                Pens.White,
                (float)((_asmEngine.lastResult[i][0])*_zoomRatioX),(float)((_asmEngine.lastResult[i][1])*_zoomRatioY),
                (float)((_asmEngine.lastResult[j][0])*_zoomRatioX),(float)((_asmEngine.lastResult[j][1])*_zoomRatioY));
              g.DrawLine(
                Pens.Red,
                (float)((_asmEngine.lastResult[i][0]-_asmEngine.movement[i][0])*_zoomRatioX),(float)((_asmEngine.lastResult[i][1]-_asmEngine.movement[i][1])*_zoomRatioY),
                (float)((_asmEngine.lastResult[i][0]+_asmEngine.movement[i][0])*_zoomRatioX),(float)((_asmEngine.lastResult[i][1]+_asmEngine.movement[i][1])*_zoomRatioY));
              g.DrawLine(
                Pens.Yellow,
                (float)((_asmEngine.detectedEdge[i][0])*_zoomRatioX),(float)((_asmEngine.detectedEdge[i][1])*_zoomRatioY),
                (float)((_asmEngine.detectedEdge[j][0])*_zoomRatioX),(float)((_asmEngine.detectedEdge[j][1])*_zoomRatioY));
              g.DrawLine(
                Pens.Green,
                (float)((_asmEngine.newModelInImageParameter[i][0])*_zoomRatioX),(float)((_asmEngine.newModelInImageParameter[i][1])*_zoomRatioY),
                (float)((_asmEngine.newModelInImageParameter[j][0])*_zoomRatioX),(float)((_asmEngine.newModelInImageParameter[j][1])*_zoomRatioY));
              g.DrawLine(
                Pens.Pink,
                (float)((_asmEngine.alignedModel[i][0])*_zoomRatioX),(float)((_asmEngine.alignedModel[i][1])*_zoomRatioY),
                (float)((_asmEngine.alignedModel[j][0])*_zoomRatioX),(float)((_asmEngine.alignedModel[j][1])*_zoomRatioY));
  */            g.DrawLine(
                Pens.Blue,
                (float)((optimizedShape[i][0])*_zoomRatioX),(float)((optimizedShape[i][1])*_zoomRatioY),
                (float)((optimizedShape[j][0])*_zoomRatioX),(float)((optimizedShape[j][1])*_zoomRatioY));
            }
        }
      }        
    }

    private void loadSetting() {
      if(!File.Exists(CSettings.APPDIR + "\\" + CSettings.INIFILE)) return;

      StreamReader tsFile = File.OpenText(CSettings.APPDIR + "\\" + CSettings.INIFILE);
      while(!tsFile.EndOfStream) {
          string curLine = tsFile.ReadLine().Trim();
          if(curLine == "" || curLine[0] == '#') continue;
          string[] word = curLine.Split(' ');

          switch(word[0]) {
            case "degOfFreedom" :
              _asmEngine.PDMData.freedom = int.Parse(word[1]);
              break;
            case "cx" :
              _asmEngine.cx = int.Parse(word[1]);
              break;
            case "cy" :
              _asmEngine.cy = int.Parse(word[1]);
              break;
            case "usePreviousResult" :
              _asmEngine.usePreviousResult = (int.Parse(word[1])!=0);
              break;
            case "edgeThreshold" :
              _asmEngine.edgeThreshold = int.Parse(word[1]);
              break;
            case "edgeLimit" :
              _asmEngine.detectionLimit = int.Parse(word[1]);
              break;
            case "maxStep" :
              _asmEngine.maxStep = int.Parse(word[1]);
              break;
            case "showEdge" :
              _showDetectedEdge = (int.Parse(word[1]) != 0);
              break;
            case "showEvery" :
              _iterateEvery = int.Parse(word[1]);
              break;
            case "delay" :
              _iterationTimer.Interval = int.Parse(word[1]);
              break;
          }
        }
        tsFile.Close();
        tsFile.Dispose();
        tsFile = null;
    }

    private void saveSetting() {
      StreamWriter tsFile = null;
      if(File.Exists(CSettings.APPDIR + "\\" + CSettings.INIFILE))
        File.Delete(CSettings.APPDIR + "\\" + CSettings.INIFILE);
        
      tsFile = File.CreateText(CSettings.APPDIR + "\\" + CSettings.INIFILE);
      tsFile.WriteLine("# Number of Variation Used");
      tsFile.WriteLine("degOfFreedom " + _asmEngine.PDMData.freedom);

      tsFile.WriteLine("# Initial Guess Position");
      tsFile.WriteLine("cx " + _asmEngine.cx);
      tsFile.WriteLine("cy " + _asmEngine.cy);

      tsFile.WriteLine("# Use Previous As Guess");
      if(_asmEngine.usePreviousResult)
        tsFile.WriteLine("usePreviousResult 1");
      else
        tsFile.WriteLine("usePreviousResult 0");
            
      tsFile.WriteLine("# Threshold");
      tsFile.WriteLine("edgeThreshold " + _asmEngine.edgeThreshold);

      tsFile.WriteLine("# Limit");
      tsFile.WriteLine("edgeLimit " + _asmEngine.detectionLimit);

      tsFile.WriteLine("# Maximum Iteration");
      tsFile.WriteLine("maxStep " + _asmEngine.maxStep);

      tsFile.WriteLine("# Show Detected Edge");
      if(_showDetectedEdge)
        tsFile.WriteLine("showEdge 1");
      else
        tsFile.WriteLine("showEdge 0");

      tsFile.WriteLine("# Show Iteration");
      tsFile.WriteLine("showEvery " + _iterateEvery);

      tsFile.WriteLine("# Delay");
      tsFile.WriteLine("delay " + _iterationTimer.Interval);

      tsFile.Close();
      tsFile.Dispose();
      tsFile = null;
    }

    private void reset() {
      statusInputType.Text  = "NONE";
      videoStatus.Text      = "Stopped";
      numFrame.Text         = "";
      videoProgress.Minimum = 0;
      videoProgress.Maximum = 0;
      videoProgress.Value   = 0;
    }
  }
}