using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Comp376_A1
{
  class Arrow : Drawable
  {
    Texture2D texture;
     public Arrow(Game g, Texture2D t)
      :base(g,t, "Arrow", 0, 0, new ModelArrow())
    {
      texture = t;
      origin = new Vector2(section.Width / 2, section.Height);
    }

     public Arrow(Game g, Texture2D t, Point p, Angle a)
       : base(g, t, "Arrow", 0, 0, new ModelArrow(a,p))
     {
       texture = t;
       origin = new Vector2(section.Width / 2, section.Height);
     }

     public override void Draw(GameTime gameTime)
     {
       spriteBatch.Draw(texture, new Vector2(displayable.position.x, displayable.position.y), section, Color.White, Angle.toRadians(getAngle().degrees), origin, 1.0f, SpriteEffects.None, 0);
       base.Draw(gameTime);
     }

    public Angle getAngle()
    {
      return ((ModelArrow)displayable).angle;
    }

    public void setAngle(Angle angle)
    {
      ((ModelArrow)displayable).angle = angle;
    }
  }
}
