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
  class Bubble : Drawable
  { 
    /*
    private static string[] files =  
    {
      "blue_bubble",
      "brown_bubble",
      "green_bubble",
      "orange_bubble",
      "red_bubble",
      "teal_bubble",
      "yellow_bubble"
    };
     * */
    private static string[] files =  
    {
      "Bubbles",
      "Bubbles",
      "Bubbles",
      "Bubbles",
      "Bubbles",
      "Bubbles",
      "Bubbles"
    };
    //x and y locations of all the items in the image file
    private static int[] locationX = { 0, 22, 44, 66, 88, 110, 132, 154 };
    private static int[] locationY = { 0, 0, 0, 0, 0, 0, 0, 0 };

    public bool isPopped;
    public Bubble(Game g, Texture2D t, BubbleColor c)
      :base(g,t, files[(int)c], locationX[(int)c], locationY[(int)c], new ModelBubble(c))
    {
      isPopped = false;
    }
    public Bubble(Game g, Texture2D t, BubbleColor c, Point p)
      :base(g,t, files[(int)c], locationX[(int)c], locationY[(int)c], new ModelBubble(c, p))
    {
      isPopped = false;
    }
    public Bubble(Bubble b)
      : base(b, new ModelBubble((ModelBubble)b.displayable))
    {
      isPopped = false;
    }
    public BubbleColor getColor()
    {
      return ((ModelBubble) displayable).color;
    }

    public override void Draw(GameTime gameTime)
    {
      spriteBatch.Draw(texture, new Vector2(displayable.position.x, displayable.position.y), section, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
      base.Draw(gameTime);
    }
    public override bool Equals(Object obj)
    {
      Bubble p = (Bubble)obj;
      return (getPosition().Equals(p.getPosition()));
    }

    public void popBubble()
    {
      changeColor(BubbleColor.popped);
      isPopped = true;
    }
    public void changeColor(BubbleColor color)
    {
      ModelBubble b = (ModelBubble)this.displayable;
      b.setColor(color);
      section = new Rectangle(locationX[(int)color], locationY[(int)color], dimensions.width, dimensions.height);
    }
  }
}
