using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace VideoSource {
  class ImageSource : IVideoSource {
    private Image  _image;
    private string _source;
    private object _userData = null;

    public event CameraEventHandler NewFrame;

    public string VideoSource {
      get { return _source;  }
      set { _source = value; }
    }

    public string Login {
      get { return null; }
      set { }
    }

    public string Password {
      get { return null; }
      set { }
    }

    public int FramesReceived {
      get { return 1; }
    }

    public int BytesReceived {
      get { return 0; }
    }

    public object UserData {
      get { return _userData;  }
      set { _userData = value; }
    }

    public bool Running {
      get { return (_source != null); }
    }

    public int position {
      get { return 0; }
      set { }
    }

    public int length {
      get { return -1; }
    }

    public void Start() {
      if(_source != null) {
        try
        {
          _image = Image.FromFile(_source);
          if (NewFrame != null)
						NewFrame(this, new CameraEventArgs((Bitmap)_image));
          _image.Dispose();
        } catch(Exception) {
          _source = null;
        }
      }
    }

    public void SignalToStop() { }

    public void WaitForStop() { }

    public void Stop() { }

    public void setFps(bool isLimit,float fps) { }
  }
}
