using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Zoom__Testing
{
  public partial class LensForm : Form
  {
    private const int WS_EX_LAYERED = 0x00080000;
    public LensForm()
    {
      InitializeComponent();

      int initialStyle = GetWindowLong(this.Handle, -20);
      SetWindowLong(Handle, -20, initialStyle | WS_EX_LAYERED | 0x20);
      SetLayeredWindowAttributes(Handle, 0, 255, 0x00000002); 
      
      
      hwndMag = CreateWindow(WC_MAGNIFIER, TEXT("MagnifierWindow"),
     WS_CHILD /*| MS_SHOWMAGNIFIEDCURSOR */| WS_VISIBLE,
     0, 0, m_ScreenX, m_ScreenY,
     hostDlg->GetSafeHwnd(), NULL, hInstance, NULL); 
    }

    [DllImport("user32.dll", SetLastError = true)]
    static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
  }
}
