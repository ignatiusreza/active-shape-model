// Namespace : Input Source 
// received input from image, video, and other image aquisition device
// base on :

// Motion Detector
//
// Copyright © Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Drawing;
using System.Threading;

using VideoSource;

namespace InputSource {
  public delegate void PreRendering(ref Bitmap image);

	/// <summary>
	/// Camera class
	/// </summary>
	public class CCamera	{
		private IVideoSource _videoSource = null;
		private Bitmap       _lastFrame = null;
		private int          _width = -1, _height = -1;
    public  PreRendering preRenderingEvent;

		public event EventHandler	NewFrame;

		public Bitmap lastFrame {
      get { return _lastFrame; }
    }

    public int width {
      get { return _width; }
    }

    public int height {
      get { return _height; }
    }

    public int framesReceived {
			get { return (_videoSource == null) ? 0 : _videoSource.FramesReceived; }
		}

    public int bytesReceived {
			get { return (_videoSource == null) ? 0 : _videoSource.BytesReceived; }
		}

    public bool Running {
			get { return (_videoSource == null) ? false : _videoSource.Running; }
		}

    public int position {
      get { return _videoSource.position; }
      set { _videoSource.position = value; }
    }

    public int length {
      get { return _videoSource.length; }
    }

    public float fps {
      get {
        if(_videoSource is VideoFileSource)
          return ((VideoFileSource)_videoSource).fps;
        return 1;
      }
    }

    public int videoSpeed {
      get {
        if(_videoSource is VideoFileSource)
          return ((VideoFileSource)_videoSource).videoSpeed;
        return 1;
      }
    }

		// Constructor
		public CCamera(IVideoSource source) {
      _videoSource = source;
			_videoSource.NewFrame += new CameraEventHandler(video_NewFrame);
    }

    public void decreaseVideoSpeed() {
      if(_videoSource is VideoFileSource)
        ((VideoFileSource)_videoSource).decreaseVideoSpeed();
    }

    public void increaseVideoSpeed() {
      if(_videoSource is VideoFileSource)
        ((VideoFileSource)_videoSource).increaseVideoSpeed();
    }

    // set fps
    public void setFps(bool isLimit,float fps) {
      if(_videoSource is VideoFileSource)
        ((VideoFileSource)_videoSource).setFps(isLimit,fps);
    }

		// Start video source
		public void start() {
			if (_videoSource != null)
				_videoSource.Start();
		}

		// Signal video source to stop
		public void signalToStop() {
			if (_videoSource != null)
				_videoSource.SignalToStop();
		}

		// Wait video source for stop
		public void waitForStop() {
			// lock
			Monitor.Enter(this);

			if (_videoSource != null)
				_videoSource.WaitForStop();
			// unlock
			Monitor.Exit(this);
		}

		// Abort camera
		public void stop() {
			// lock
			Monitor.Enter(this);

			if (_videoSource != null)
				_videoSource.Stop();

      // unlock
			Monitor.Exit(this);
		}

		// Lock it
		public void lockCamera() {
			Monitor.Enter(this);
		}

		// Unlock it
		public void unlockCamera() {
			Monitor.Exit(this);
		}

		// On new frame
		private void video_NewFrame(object sender, CameraEventArgs e) {
			try
			{
				// lock
				Monitor.Enter(this);

				// dispose old frame
				if (_lastFrame != null)
					_lastFrame.Dispose();

				_lastFrame = (Bitmap) e.Bitmap.Clone();
        // kalo ada prerendering event, panggil pointer to functionnya
        if(preRenderingEvent != null)
          preRenderingEvent(ref _lastFrame);
        
				_width  = _lastFrame.Width;
				_height = _lastFrame.Height;
			} catch (Exception) {
			} finally {
				// unlock
				Monitor.Exit(this);
			}

			// notify client
			if (NewFrame != null)
				NewFrame(this, new EventArgs());
		}
	}
}
