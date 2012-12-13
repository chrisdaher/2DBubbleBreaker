using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  public enum BubbleColor{
    blue = 0,
    brown = 1,
    green = 2,
    orange = 3,
    red = 4,
    teal = 5,
    yellow = 6,
    popped = 7
  }

  class ModelBubble : Model
  {
    private static int WIDTH = 22;
    private static int HEIGHT = 20;
    //color of the bubble
    public BubbleColor color { get; set; }

    public ModelBubble(BubbleColor c)
      :base(new Point(0,0),new Dimension(WIDTH, HEIGHT))
    {
      color = c;
    }

    public ModelBubble(BubbleColor c, Point p)
      :base(new Point(p),new Dimension(WIDTH,HEIGHT))
    {
      color = c;
    }
    public ModelBubble(ModelBubble b)
      : base(b)
    {
      color = b.color;
    }
    public void setColor(BubbleColor color)
    {
      this.color = color;
    }
  }
}
