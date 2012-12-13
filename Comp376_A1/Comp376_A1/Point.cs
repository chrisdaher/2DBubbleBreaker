using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  class Point
  {
    public float x { get; set; }
    public float y { get; set; }

    public Point(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    public Point(Point p)
    {
      this.x = p.x;
      this.y = p.y;
    }
    public override bool Equals(Object obj)
    {
      Point p = (Point)obj;
      return (x == p.x && y == p.y);
    }
  }
}
