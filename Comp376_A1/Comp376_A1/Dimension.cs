using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  class Dimension
  {
    public int height { get; set; }
    public int width{ get; set; }

    public Dimension(int w, int h)
    {
      width= w;
      height = h;
    }

    public Dimension(Dimension d)
    {
      width = d.width;
      height = d.height;
    }
  }
}
