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
  class BoardMain : Board
  {
    Texture2D bubbleTexture;
    Game game;
    Point boardPosition;
    List<Vector2[]> walls;
    static float[] verteces = { 209, 386, 26, 226 };
    public SpriteBatch spriteBatch { get; set; }

    int currentLevel;

    public BoardMain(Game g, Texture2D bTexture, int currentLevel)
      : base(g)
    {
      this.currentLevel = currentLevel;
      bubbleTexture = bTexture;
      game = g;
      boardPosition = new Point(200,20);
      spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
      Initialize();
    }

    public override void Initialize()
    {
      if (currentLevel == 2)
      {
        /*
        for (int j = 0; j < 4; j++)
        {
          for (int i = 0; i < 8; i++)
          {
            BubbleHolder.grid[i, j].bubble = BubbleCreator.createRandomBubble(BubbleHolder.grid[i, j].point);
            childComponents.Add(BubbleHolder.grid[i, j].bubble);
          }
        }
         * */
        createLevel2();
      }
      else
      {
        /*
        int[] coordinates = new int[]{ 0, 0 };
        BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, BubbleColor.red, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
        childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

        coordinates = new int[] { 0, 1 };
        BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, BubbleColor.red, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
        childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

        coordinates = new int[] { 0, 2 };
        BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, BubbleColor.red, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
        childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);
         * */
        createLevel1();
      }
      walls = new List<Vector2[]>();
      Vector2[] temp = new Vector2[2];
      temp[0] = new Vector2(verteces[0], verteces[2]);
      temp[1] = new Vector2(verteces[0], verteces[3]);
      walls.Add(temp);

      Vector2[] temp1 = new Vector2[2];
      temp1[0] = new Vector2(verteces[0], verteces[2]);
      temp1[1] = new Vector2(verteces[1], verteces[2]);
      walls.Add(temp1);
      
      Vector2[] temp2 = new Vector2[2];
      temp2[0] = new Vector2(verteces[1], verteces[2]);
      temp2[1] = new Vector2(verteces[1], verteces[3]);
      walls.Add(temp2);

      Vector2[] temp3 = new Vector2[2];
      temp3[0] = new Vector2(verteces[0], verteces[3]);
      temp3[1] = new Vector2(verteces[1], verteces[3]);
      walls.Add(temp3);

      base.Initialize();
      
    }

    public override void Update(GameTime gameTime)
    {
      childComponents = new List<GameComponent>();
      List<Bubble> temp = BubbleHolder.getBubbles();
      for (int i = 0; i < temp.Count; i++)
      {
          childComponents.Add(temp[i]);
      }
      base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
      for (int i = 0; i < walls.Count; i++)
      {
          Game1.DrawLine(spriteBatch, Game1.wall, 5, Color.White, walls[i][0], walls[i][1]);
      }
      base.Draw(gameTime);
      BubbleHolder.RemovePopped();
    }
    public static bool checkWallCollision(Bubble bubble)
    {
      if (bubble.getPosition().x < (verteces[0]+10) || bubble.getPosition().x > (verteces[1]-10))
      {
        return true;
      }
      return false;
    }

    public static bool checkReachedLimit(Bubble bubble)
    {
      if (bubble.getPosition().y < verteces[2]+10)
      {
        return true;
      }
      return false;
    }

    public void createLevel2()
    {
      int[] coordinates = new int[] { 0, 0 };
      BubbleColor c = BubbleColor.red;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 0 };
      c = BubbleColor.red;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 0, 1 };
      c = BubbleColor.red;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 0 };
      c = BubbleColor.blue;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 1 };
      c = BubbleColor.blue;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 1 };
      c = BubbleColor.blue;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 0 };
      c = BubbleColor.green;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 0 };
      c = BubbleColor.green;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 1 };
      c = BubbleColor.green;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 0 };
      c = BubbleColor.teal;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 1 };
      c = BubbleColor.teal;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 1 };
      c = BubbleColor.teal;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 0 };
      c = BubbleColor.brown;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 0 };
      c = BubbleColor.brown;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 1 };
      c = BubbleColor.brown;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 1 };
      c = BubbleColor.brown;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      // --------------------------------------- SECOND ROW --------------------------------------------

      coordinates = new int[] { 0, 2 };
      c = BubbleColor.brown;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 2 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 0, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 2 };
      c = BubbleColor.orange;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 2 };
      c = BubbleColor.yellow;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 2 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 2 };
      c = BubbleColor.red;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 2 };
      c = BubbleColor.blue;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 2 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);
    }
    public void createLevel1()
    {
      int[] coordinates = new int[] { 0, 0 };
      BubbleColor c = BubbleColor.red;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 0 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 0, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 0 };
      c = BubbleColor.blue;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 0 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 0 };
      c = BubbleColor.green;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 0 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 0 };
      c = BubbleColor.brown;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 0 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 1 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      // --------------------------------------- SECOND ROW --------------------------------------------

      coordinates = new int[] { 0, 2 };
      c = BubbleColor.blue;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 2 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 0, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 1, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 2 };
      c = BubbleColor.orange;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 2, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 2 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 3, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 2 };
      c = BubbleColor.yellow;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 2 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 4, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 5, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 2 };
      c = BubbleColor.red;
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 2 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 6, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);

      coordinates = new int[] { 7, 3 };
      BubbleHolder.grid[coordinates[0], coordinates[1]].bubble = new Bubble(Game, bubbleTexture, c, BubbleHolder.grid[coordinates[0], coordinates[1]].point);
      childComponents.Add(BubbleHolder.grid[coordinates[0], coordinates[1]].bubble);
    }
  }
}
