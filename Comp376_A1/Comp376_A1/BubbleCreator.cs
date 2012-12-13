﻿using System;
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
  class BubbleCreator
  {
    static Random random;

    static Game game;
    static Texture2D texture;

    static BubbleColor[] bubbleColors = {BubbleColor.blue, 
                                               BubbleColor.brown, 
                                               BubbleColor.green, 
                                               BubbleColor.orange, 
                                               BubbleColor.red, 
                                               BubbleColor.teal, 
                                               BubbleColor.yellow};
    public static void setXNA(Game g, Texture2D t)
    {
      game = g;
      texture = t;
    }
    public static Bubble createRandomBubble()
    {
      Bubble newBubble;
      if (random == null)
      {
        random = new Random();
      }
      int bColor = random.Next(1, 7);
      newBubble = new Bubble(game, texture, bubbleColors[bColor]);

      return newBubble;
    }
    public static Bubble createRandomBubble(Point p)
    {
      Bubble newBubble;
      if(random == null)
      {
        random = new Random();
      }
      int bColor = random.Next(1,7);
      newBubble = new Bubble(game, texture, bubbleColors[bColor], new Point(p));

      return newBubble;
    }
  }
}
