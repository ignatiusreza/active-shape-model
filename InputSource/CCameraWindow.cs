// Namespace : Input Source 
// received input from image, video, and other image aquisition device
// base on :

// Motion Detector
//
// Copyright © Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace InputSource {
  public delegate void PostRendering(ref Graphics image);

	/// <summary>
	/// Summary description for CameraWindow.
	/// </summary>
	public class CCameraWindow : System.Windows.Forms.Control	{
		private CCamera       _camera;
    public  PostRendering postRenderingEvent;

		// Camera property
		[Browsable(false)]
		public CCamera camera {
			get { return _camera; }
			set {
				// lock
				Monitor.Enter(this);

				// detach event
        PreRendering buff = null;
				if (_camera != null) {
          _camera.NewFrame -= new EventHandler(camera_NewFrame);
          buff = _camera.preRenderingEvent;
          _camera.preRenderingEvent = null;
        }

				_camera = value;

				// atach event
				if (_camera != null) {
          _camera.NewFrame += new EventHandler(camera_NewFrame);
          _camera.preRenderingEvent = buff;
        }

				// unlock
				Monitor.Exit(this);
			}
		}

		// Constructor
		public CCameraWindow() {
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
				ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
		}

		// Paint control
		protected override void OnPaint(PaintEventArgs pe) {
			// lock
			Monitor.Enter(this);

			Graphics  g   = pe.Graphics;
			Rectangle rc  = this.ClientRectangle;
			Pen       pen = new Pen(Color.Black, 1);

			// draw rectangle
			g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);

			if (_camera != null) {
				try 
        {
					_camera.lockCamera();

					// draw frame
					if (_camera.lastFrame != null)
						g.DrawImage(_camera.lastFrame, rc.X + 1, rc.Y + 1, rc.Width - 2, rc.Height - 2);
					else {
						// Create font and brush
						Font drawFont = new Font("Arial", 12);
						SolidBrush drawBrush = new SolidBrush(Color.White);

						g.DrawString("Connecting ...", drawFont, drawBrush, new PointF(5, 5));

						drawBrush.Dispose();
						drawFont.Dispose();
					}

        // kalo ada postrendering event, panggil pointer to functionnya
        if(postRenderingEvent != null)
          postRenderingEvent(ref g);
				} catch (Exception) {
				} finally {
					_camera.unlockCamera();
				}
			}

			pen.Dispose();

			// unlock
			Monitor.Exit(this);

			base.OnPaint(pe);
		}

  	// On new frame ready
		private void camera_NewFrame(object sender, System.EventArgs e) {
			Invalidate();
		}
	}
}
