using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using ASMLibrary;

namespace Training_Set_Builder {
  public partial class CClippingForm : Form {
    #region "Import GDI DLL"
    [DllImport("gdi32.dll")] 
    private static extern bool BitBlt( 
      IntPtr hdcDest,
      int nXDest,int nYDest,int nWidth,int nHeight,
      IntPtr hdcSrc,
      int nXSrc,int nYSrc,
      System.Int32 dwRop
      );

    [DllImport("User32.dll")] 
    public extern static System.IntPtr GetDC(System.IntPtr hWnd); 
    
    [DllImport("User32.dll")] 
    public extern static int ReleaseDC(System.IntPtr hWnd, System.IntPtr hDC);
    #endregion

    public enum TTools {
      HAND = 0,
      ZOOM
    };

    #region "Attributes"

    private TTools toolsSelected;

    private SolidBrush transparencyBrush;
    private Rectangle  transparencyRect;
    private double     zoomValue = 1, newZoomValue;
    private Point      relative, newRelative;
    private Point      mouseDownPos;
    private bool       isMoving = false,isZooming = false;

    public Graphics  transparencyGraphics;
    public Graphics  clippedGraphics;
    public Image     fullImage;
    public Image     clippedImage;
    public Rectangle clippedRect;
    public Point     clippedLocation;

    #endregion

    #region "Constructor & Destructor"

    public CClippingForm() {
      InitializeComponent();
      toolsSelected = TTools.HAND;
      this.transparencyPanel.Cursor = new Cursor(Training_Set_Builder.Properties.Resources.pointerToolsHand.GetHicon());

      relative = new Point(0,0);
      newRelative = new Point(0,0);
      transparencyRect = new Rectangle(0,0, CSettings.MAXCLIPSIZE.Width, CSettings.MAXCLIPSIZE.Height);
      transparencyBrush = new SolidBrush(Color.FromArgb(98,0,0,0));
    }

    #endregion

    #region "Event Handler"

    private void transparencyPanel_Paint(object sender,PaintEventArgs e) {
      transparencyGraphics = e.Graphics;
      transparencyGraphics.ExcludeClip(clippedRect);
      transparencyGraphics.FillRectangle(transparencyBrush,e.ClipRectangle);
      transparencyGraphics.DrawRectangle(
        Pens.Black,
        new Rectangle(
          clippedRect.X-2,
          clippedRect.Y-1,
          clippedRect.Width+3,
          clippedRect.Height+2));
    }

    private void clippedPanel_Paint(object sender,PaintEventArgs e) {
      clippedGraphics = e.Graphics;

      clippedGraphics.Clear(this.BackColor);
      clippedGraphics.FillRectangle(Brushes.White,clippedRect);
      int currWidth = (int)(fullImage.Width * (zoomValue + newZoomValue));
      int currHeight = (int)(fullImage.Height * (zoomValue + newZoomValue));
      clippedGraphics.DrawImage(
        fullImage,
        new Rectangle(
          clippedLocation.X + relative.X + newRelative.X - (currWidth - fullImage.Width)/2,
          clippedLocation.Y + relative.Y + newRelative.Y - (currHeight - fullImage.Height)/2,
          currWidth,
          currHeight));
    }

    private void btnHandTool_Click(object sender,EventArgs e) {
      this.btnHandTool.Checked = true;
      this.btnZoomTool.Checked = false;
      toolsSelected = TTools.HAND;

      this.transparencyPanel.Cursor = new Cursor(Training_Set_Builder.Properties.Resources.pointerToolsHand.GetHicon());
    }

    private void btnZoomTool_Click(object sender,EventArgs e) {
      this.btnHandTool.Checked = false;
      this.btnZoomTool.Checked = true;
      toolsSelected = TTools.ZOOM;

      this.transparencyPanel.Cursor = new Cursor(Training_Set_Builder.Properties.Resources.pointerToolsZoom.GetHicon());
    }

    private void transparencyPanel_MouseDown(object sender,MouseEventArgs e) {
      mouseDownPos = e.Location;
      
      if(e.X > clippedRect.X && e.X < (clippedRect.X + clippedRect.Width) &&
         e.Y > clippedRect.Y && e.Y < (clippedRect.Y + clippedRect.Height)) {
        if(toolsSelected == TTools.HAND)
          isMoving  = true;
        else
          isZooming = true;
      }
    }

    private void transparencyPanel_MouseMove(object sender,MouseEventArgs e) {
      if(isMoving) {
        newRelative.X = e.Location.X-mouseDownPos.X;
        newRelative.Y = e.Location.Y-mouseDownPos.Y;
        clippedPanel.Refresh();
      }
      if(isZooming) {
        newZoomValue = (mouseDownPos.Y - e.Location.Y)/50.0;
        if((zoomValue + newZoomValue) < 0.25)
          newZoomValue = 0.25 - zoomValue;
        clippedPanel.Refresh();
      }
    }

    private void transparencyPanel_MouseUp(object sender,MouseEventArgs e) {
      if(isMoving) {
        relative.X += newRelative.X;
        relative.Y += newRelative.Y;
        newRelative.X = 0;
        newRelative.Y = 0;
      }
      if(isZooming) {
        zoomValue += newZoomValue;
        newZoomValue = 0;
      }
      isMoving  = false;
      isZooming = false;
    }

    private void btnOK_Click(object sender,EventArgs e) {
      this.DialogResult = DialogResult.OK;
      Bitmap bufferImage = new Bitmap(clippedRect.Width,clippedRect.Height);
      System.IntPtr srcDC=GetDC(this.clippedPanel.Handle); 
      Graphics g=Graphics.FromImage(bufferImage); 
      System.IntPtr bufferImageDC=g.GetHdc(); 
      BitBlt(bufferImageDC,
        0,0,bufferImage.Width,bufferImage.Height,
        srcDC,
        clippedRect.X,clippedRect.Y,
        0x00CC0020 /*SRCCOPY*/); 
      ReleaseDC(this.clippedPanel.Handle, srcDC); 
      g.ReleaseHdc(bufferImageDC); 
      g.Dispose();

      clippedImage = Image.FromHbitmap(bufferImage.GetHbitmap());

      this.Close();
    }

    private void btnCancel_Click(object sender,EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    #endregion
  }
}