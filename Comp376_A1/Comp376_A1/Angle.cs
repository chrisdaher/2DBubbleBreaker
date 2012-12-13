using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  class Angle
  {
    public float degrees { get; set; }

    public Angle(float degree)
    {
      this.degrees = degree;
    }
    public Angle()
    {
      degrees = 0;
    }
    public void addAngle(float degree)
    {
      this.degrees += degree;
    }

    public Velocity getVelocity()
    {
      float x = (float) Math.Cos(degrees);
      float y = (float) Math.Sin(degrees);
      Velocity v = new Velocity(x, y);
      return v;
    }

    public Velocity getVelocity(float distance)
    {
      float x = (float)Math.Sin(toRadians(degrees))*distance;
      float y = (float)Math.Cos(toRadians(degrees))*distance;
      Velocity v = new Velocity(x, -y);
      return v;
    }
    public static float toDegrees(float radians)
    {
      return (float) (radians * (180 / Math.PI));
    }
    public float getAngle()
    {
      return toDegrees(degrees);
    }
    public static float toRadians(float degrees)
    {
      return (float)(degrees * (Math.PI / 180));
    }
  }
}
