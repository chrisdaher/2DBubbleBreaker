using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  class GridSquare
  {
    public Bubble bubble;
    public Point point;
    public Dimension dimensions;
    public int x { get; set; }
    public int y { get; set; }
    public GridSquare(Point p, Bubble b)
    {
      point = p;
      bubble = b;
      dimensions = new Dimension(b.dimensions);
    }

    public GridSquare(Point p)
    {
      point = p;
      dimensions = new Dimension(20, 20);
    }

    public bool enoughToSnap(Point p)
    {
      float differenceX = p.x - point.x;
      float differenceY = p.y - point.y;
      differenceX = Math.Abs(differenceX);
      differenceY = Math.Abs(differenceY);

      if(bubble ==null && (differenceX <= (dimensions.width / 2) && differenceY <= (dimensions.height / 2)))
      {
        return true;
      }
      return false;
    }
    public bool isColliding(Point p)
    {
      float differenceX = p.x - point.x;
      float differenceY = p.y - point.y;
      differenceX = Math.Abs(differenceX);
      differenceY = Math.Abs(differenceY);

      if (bubble != null && (differenceX <= (dimensions.width) && differenceY <= (dimensions.height)))
      {
        return true;
      }
      return false;
    }
  }
}
