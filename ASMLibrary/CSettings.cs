using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ASMLibrary {
  public class CSettings {
    public static string      INIFILE = "asm.ini";
    public static bool        ISSAVED;
    public static Size        MAXCLIPSIZE;
    public static int         MAXPOINT;
    public static string      APPDIR;
    public static string      CACHEDIR;
    public static int         FILENAMECOUNTER=0;
    public static CStatusForm status = new CStatusForm();

    public static long currentTimeMillis() {
      DateTime baseTime = new DateTime(2004, 11, 20, 0, 0, 0);
      DateTime nowInUTC = DateTime.UtcNow;
      TimeSpan timeSpan = (nowInUTC - baseTime);
      return (timeSpan.Ticks / 10000);
    }
  }
}
