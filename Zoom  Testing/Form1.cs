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
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      MagInitialize();
      Closing += (sender, args) => MagUninitialize();
    }

    [DllImport("Magnification.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool MagUninitialize();

    [DllImport("Magnification.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool MagInitialize();

    public bool SetZoom(float magnificationFactor)
    {
      return MagSetWindowSource((IntPtr)(-1), new Rect(300, 400));
    }
    //public bool SetZoom(float magnificationFactor)
    //{
    //  if (magnificationFactor < 1.0)
    //  {
    //    return false;
    //  }
    //  return MagSetFullscreenTransform(magnificationFactor, Left, Top);
    //}

    private float GetSystemMetrics(int value)
    {
      var screen = Screen.AllScreens.First();
      if (value == 1) return screen.WorkingArea.Width;
      return screen.WorkingArea.Height;
    }
    [DllImport("Magnification.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool MagSetFullscreenTransform(float magLevel, int xOffset, int yOffset);
    
    [DllImport("Magnification.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool MagGetFullscreenTransform(out float magLevel, out int xOffset, out int yOffset);

    [DllImport("Magnification.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool MagSetWindowSource(IntPtr hwnd, Rect rect);

    private void button1_Click(object sender, EventArgs e)
    {
      SetZoom(2);
    }
  }
}
