// Handling Video File
// Base On :

// Motion Detector
//
// Copyright © Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//
namespace VideoSource {
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.IO;
	using System.Threading;

	using Tiger.Video.VFW;

	/// <summary>
	/// VideoFileSource
	/// </summary>
	public class VideoFileSource : IVideoSource {
		private AVIReader	aviReader;
		private string    source;
		private object    userData = null;
		private int       framesReceived;
    private int       _videoSpeed;
    private bool      _isLimitFps;
    private float     _fpsLimit,_embededFps;
    private DateTime  _fpsMark;

		private Thread           thread = null;
		private ManualResetEvent stopEvent = null;

		// new frame event
		public event CameraEventHandler NewFrame;

		// VideoSource property
		public virtual string VideoSource {
			get { return source; }
			set { source = value; }
		}
		// Login property
		public string Login {
			get { return null; }
			set { }
		}
		// Password property
		public string Password {
			get { return null; }
			set { }
		}
		// FramesReceived property
		public int FramesReceived {
			get {
				int frames = framesReceived;
				framesReceived = 0;
        _fpsMark = DateTime.Now;
				return frames;
			}
		}
		// BytesReceived property
		public int BytesReceived {
			get { return 0; }
		}
		// UserData property
		public object UserData {
			get { return userData; }
			set { userData = value; }
		}
		
    // Get state of the video source thread
		public bool Running {
			get
			{
				if (thread != null) {
					if (thread.Join(0) == false)
						return true;

					// the thread is not running, so free resources
					Free();
				}
				return false;
			}
		}

    public int position {
      get { 
        if(aviReader == null)
          return 0;
        return aviReader.CurrentPosition; }
      set {
        System.Console.WriteLine("Setting Camera Position : " + value);

        if(aviReader != null) {
          aviReader.CurrentPosition = value;
          if(!Running) {
					  Bitmap	bmp = aviReader.GetNextFrame();
					  if (NewFrame != null)
						  NewFrame(this, new CameraEventArgs(bmp));
          }
        }
      }
    }

    public int length {
      get { return aviReader.Length; }
    }

    public float fps {
      get { 
        TimeSpan ts     = DateTime.Now.Subtract(_fpsMark);
        int      frames = framesReceived;
        framesReceived  = 0;
        _fpsMark        = DateTime.Now;

        return (float)((1000 / ts.TotalMilliseconds)*frames);
      }
    }

    public int videoSpeed {
      get { return _videoSpeed; }
    }

		// Constructor
		public VideoFileSource() {
      _isLimitFps = false;
      _videoSpeed = 1;
		}

		// Start work
		public void Start() {
			if (thread == null) {
				framesReceived = 0;

				// create events
				stopEvent	= new ManualResetEvent(false);
				
				// open file
        try
        {
          aviReader = new AVIReader();
				  aviReader.Open(source);
          _embededFps = aviReader.FrameRate;

				  // create and start new thread
				  thread = new Thread(new ThreadStart(WorkerThread));
				  thread.Name = source;
				  thread.Start();
          _fpsMark = DateTime.Now;
        } catch (Exception ex) {
			  	System.Diagnostics.Debug.WriteLine("exception : " + ex.Message);
			  }
			}
		}

		// Signal thread to stop work
		public void SignalToStop() {
			// stop thread
			if (thread != null) {
				// signal to stop
				stopEvent.Set();
			}
		}

		// Wait for thread stop
		public void WaitForStop() {
			if (thread != null) {
				// wait for thread stop
				thread.Join();

				Free();
			}
		}

		// Abort thread
		public void Stop() {
			if (this.Running)
			{
				thread.Abort();
				WaitForStop();
			}
		}

		// Free resources
		private void Free() {
			aviReader.Dispose();
			aviReader = null;

			thread = null;

			// release events
			stopEvent.Close();
			stopEvent = null;
		}

    public void decreaseVideoSpeed() {
      if(_videoSpeed > -128) _videoSpeed--;
      if(_videoSpeed == 0) _videoSpeed = -1;
    }

    public void increaseVideoSpeed() {
      if(_videoSpeed < 128) _videoSpeed++;
      if(_videoSpeed == 0) _videoSpeed = 1;
    }

		// Thread entry point
		public void WorkerThread() {
			try
			{
				while (true) {
					// start time
					DateTime	start = DateTime.Now;

					// get next frame
          if((aviReader.CurrentPosition + _videoSpeed - 1) < aviReader.Length)
            aviReader.CurrentPosition += (_videoSpeed - 1);
          else
            aviReader.CurrentPosition = aviReader.Length-1;
					Bitmap	bmp = aviReader.GetNextFrame();

					framesReceived++;

					// need to stop ?
					if (stopEvent.WaitOne(0, false))
						break;

					if (NewFrame != null)
						NewFrame(this, new CameraEventArgs(bmp));

					// free image
					bmp.Dispose();

					// end time
					TimeSpan	span = DateTime.Now.Subtract(start);

					// fps control
					int			m = (int) span.TotalMilliseconds;

					if (_isLimitFps && _fpsLimit != 0) {
            float fps = _fpsLimit;
            if(fps < 0) fps = _embededFps;
            int sleepTime = (int)(1000 / fps);
						if(m < sleepTime) Thread.Sleep(sleepTime-m);
          }
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("exception : " + ex.Message);
			}
		}

    // set fps
    public void setFps(bool isLimit,float fps) {
      _isLimitFps = isLimit;
      _fpsLimit   = fps;
    }
	}
}
