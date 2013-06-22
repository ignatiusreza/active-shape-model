using System.Windows.Forms;

namespace Training_Set_Builder {
  public class CDoubleBufferedPanel : Panel{
    public CDoubleBufferedPanel() {
      this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
        ControlStyles.AllPaintingInWmPaint,true);
      this.ResizeRedraw = false;
      this.UpdateStyles();
    }
  }
}
