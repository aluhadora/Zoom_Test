using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoom__Testing
{
  public struct Rect
  {
    /// <summary>
    /// Position of left edge
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
    public int left;

    /// <summary>
    /// Position of top edge
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
    public int top;

    /// <summary>
    /// Position of right edge
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
    public int right;

    /// <summary>
    /// Position of bottom edge
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
    public int bottom;

    public Rect(int width, int height)
    {
      left = 0;
      top = 0;
      right = width;
      bottom = height;
    }

    public override bool Equals(object obj)
    {
      Rect r = (Rect)obj;
      return (r.left == left && r.right == right && r.top == top && r.bottom == bottom);
    }

    public override int GetHashCode()
    {
      // Attempting a minor degree of "hash-ness" here
      return ((left ^ top) ^ right) ^ bottom;
    }

    public static bool operator ==(Rect a, Rect b)
    {
      return (a.left == b.left && a.right == b.right && a.top == b.top && a.bottom == b.bottom);
    }

    public static bool operator !=(Rect a, Rect b)
    {
      return !(a == b);
    }

  }

}
