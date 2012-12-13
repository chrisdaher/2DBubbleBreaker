using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  class Velocity
  {
    public float x { get; set; }
    public float y { get; set; }

    public Velocity(float x, float y)
    {
      this.x = x;
      this.y = y;
    }
    public Velocity(Velocity v)
    {
      x = v.x;
      y = v.y;
    }

    public Point move(Point p)
    {
      Point toRet = new Point(p.x+x, p.y+y);
      return toRet;
    }
    
  }
}
