using System;
using System.Collections.Generic;
using System.Text;

using VideoSource;
using System.Windows.Forms;

namespace InputSource {
  public class RGB {
    public static int B = 0,
    G = 1,
    R = 2;
  };
  public enum TInputType {
    UNKNOWN = 0,
    NONE,
    IMAGE,
    VIDEO,
    DEVICE
  };
  public enum TPlaybackStatus {
    STOPPED = 0,
    PAUSED,
    PLAYING
  };

  public class CInputSource {
		// fps count
    private Timer     _timer = new Timer();
		private const int	_statLength = 15;
		private int		  	_statIndex = 0, _statReady = 0;
		private int[]		  _statCount = new int[_statLength];
    private float     _fps;

    // Camera Window
    private CCameraWindow _cameraWindow;

    // Attributes
    private TInputType      _inputType      = TInputType.NONE;
    private TPlaybackStatus _playbackStatus = TPlaybackStatus.STOPPED;
    private int             _positionBuffer  = 0;

    // Event
    public PreRendering  preRenderingEvent;
    public PostRendering postRenderingEvent;

    public CCameraWindow cameraWindow {
      get { return _cameraWindow; }
      set {
        if(_cameraWindow != null && _cameraWindow.camera != null) {
          CCamera buff = _cameraWindow.camera;
          _cameraWindow.camera = null;
          buff.signalToStop();
          buff.waitForStop();
          buff = null;
          _cameraWindow.Dispose();
        }
        _cameraWindow = value;
      }
    }

    public float fps {
      get { return _fps; }
    }

    public int videoSpeed {
      get {
        if(_cameraWindow != null && _cameraWindow.camera != null)
          return _cameraWindow.camera.videoSpeed;
        return 0;
      }
    }

    public TInputType inputType {
      get { return _inputType; }
    }

    public TPlaybackStatus playbackStatus {
      get { return _playbackStatus; }
    }

    public int position {
      get {
        if(_cameraWindow != null && _cameraWindow.camera != null)
          return _cameraWindow.camera.position;
        return 0;
      }
      set {
        if(_cameraWindow != null && _cameraWindow.camera != null)
          _cameraWindow.camera.position = value;
      }
    }

    public int length {
      get {
        if(_cameraWindow != null && _cameraWindow.camera != null)
          return _cameraWindow.camera.length;
        return 0;
      }
    }

    public CInputSource(CCameraWindow cameraWindow) {
      _cameraWindow = cameraWindow;
			_timer.Interval = 1000;
      _timer.Tick += new EventHandler(_timer_Tick);
    }

		// Open video source
		public bool openInputSource(string identifier,TInputType type,bool isAutoPlay) {
      IVideoSource source;
      switch(type) {
        case TInputType.IMAGE :
          source = new ImageSource();
          break;
        case TInputType.VIDEO :
          source = new VideoFileSource();
          break;
        case TInputType.DEVICE :
          source = new CaptureDevice();
          break;
        default :
          return false;
      }
      source.VideoSource = identifier;

			// close previous file
			closeInputSource();

			// create camera
			CCamera camera = new CCamera(source);

			// attach camera to camera window
      _cameraWindow.postRenderingEvent = postRenderingEvent;
			_cameraWindow.camera = camera;
      _cameraWindow.camera.preRenderingEvent = preRenderingEvent;

      _inputType = type;
      if(isAutoPlay) play();
      else {
        //getFirstFrame();
      }

			// reset statistics
			_statIndex = _statReady = 0;

      return true;
		}

		// Close current file
		public void closeInputSource() {
			if (cameraWindow != null && cameraWindow.camera != null) {
        pause();
				cameraWindow.camera = null;
        _inputType = TInputType.NONE;
			}
		}

    public void play() {
      if(_cameraWindow != null && _cameraWindow.camera != null) {
        // start camera
			  _cameraWindow.camera.start();
        _cameraWindow.camera.position = _positionBuffer;
        // start timer
			  _timer.Start();
        _playbackStatus = TPlaybackStatus.PLAYING;
      }
    }

    public void pause() {
      if(_cameraWindow != null && _cameraWindow.camera != null && _playbackStatus == TPlaybackStatus.PLAYING) {
			  // signal camera to stop
			  cameraWindow.camera.signalToStop();
        _positionBuffer = _cameraWindow.camera.position;
			  // wait for the camera
			  cameraWindow.camera.waitForStop();
        _playbackStatus = TPlaybackStatus.PAUSED;
      }
    }

    public void stop() {
      pause();
      _positionBuffer = 0;
      _playbackStatus = TPlaybackStatus.STOPPED;
    }

    public void decreaseVideoSpeed() {
      if(_cameraWindow != null && _cameraWindow.camera != null && _playbackStatus == TPlaybackStatus.PLAYING)
        _cameraWindow.camera.decreaseVideoSpeed();
    }

    public void increaseVideoSpeed() {
      if(_cameraWindow != null && _cameraWindow.camera != null && _playbackStatus == TPlaybackStatus.PLAYING)
        _cameraWindow.camera.increaseVideoSpeed();
    }

    public void setFps(bool isLimit,float fpsLimit) {
      if(_inputType == TInputType.VIDEO)
        cameraWindow.camera.setFps(isLimit,fpsLimit);
    }

		// On timer event - count fps
    private void _timer_Tick(object sender,EventArgs e) {
			CCamera	camera = cameraWindow.camera;
		
			if (camera != null)
        if(_inputType == TInputType.VIDEO) {
          _fps = camera.fps;
        }else if(_inputType != TInputType.IMAGE) {
				// get number of frames for the last second
				_statCount[_statIndex] = camera.framesReceived;

				// increment indexes
				if (++_statIndex >= _statLength)
					_statIndex = 0;
				if (_statReady < _statLength)
					_statReady++;

				float	fps = 0;

				// calculate average value
				for (int i = 0; i < _statReady; i++)
					fps += _statCount[i];
				fps /= _statReady;

				_statCount[_statIndex] = 0;

				_fps = fps;
			}
    }
  }
}
