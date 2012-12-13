using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  abstract class Model
  {

    //position of the displayable in the window
    public Point position{ get; set; }
    public Velocity velocity { get; set; }
    //dimensions of the displayable in the window
    public Dimension dimensions{ get; set; }

    private Point target;
    public Model(Point p, Dimension d)
    {
      position = new Point(p);
      dimensions = new Dimension(d);
      velocity = new Velocity(0,0);
    }
    public Model(Model m)
    {
      position = new Point(m.position);
      dimensions = new Dimension(m.dimensions);
      velocity = new Velocity(m.velocity);
      if (target != null)
      {
        target = new Point(m.target);
      }
    }
    public void setVelocity(Velocity v)
    {
      velocity = new Velocity(v);
    }
    public Point move()
    {
      if (target != null)
      {
        if (target.x == position.x && target.y == position.y)
        {
          target = null;
          this.stop();
        }
      }
      position = velocity.move(position);
      return position;
    }
    public void moveTo(Point p, float speed)
    {
      float x = p.x - position.x;
      float y = p.y - position.y;
      velocity = new Velocity(x/speed, y/speed);
      target = new Point(p);
    }
    public void stop()
    {
      velocity.x = 0;
      velocity.y = 0;
    }
  }
}
