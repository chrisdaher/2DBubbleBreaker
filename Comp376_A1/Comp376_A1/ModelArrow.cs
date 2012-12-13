using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  class ModelArrow : Model
  {
    private static int WIDTH = 22;
    private static int HEIGHT = 40;
    //color of the bubble
    public Angle angle{ get; set; }

    public ModelArrow()
      :base(new Point(0,0),new Dimension(WIDTH, HEIGHT))
    {
      angle = new Angle();
    }

    public ModelArrow(Angle a, Point p)
      :base(new Point(p),new Dimension(WIDTH,HEIGHT))
    {
      angle = a;
    }
  }
}
