using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Runtime.InteropServices;
namespace Comp376_A1
{
  public class Game1 : Microsoft.Xna.Framework.Game
  {
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);

    public static Texture2D wall;

    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    KeyboardState oldState;
    Texture2D sprite;
    Texture2D arrowSprite;

    int spriteWidth = 20;
    int spriteHeight = 20;
    Rectangle sourceRect;
    Vector2 origin;

    BoardMain main;
    BoardPlayer player;

    int CurrentLevel;
    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      oldState = Keyboard.GetState();
      CurrentLevel = 1;
      BubbleHolder.initGrid();
    }

    protected override void Initialize()
    {
      base.Initialize();
    }

    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);
      Services.AddService(typeof(SpriteBatch),spriteBatch);
      sprite = Content.Load<Texture2D>("Bubbles");
      BubbleCreator.setXNA(this, sprite);
      main = new BoardMain(this, sprite, CurrentLevel);
      arrowSprite = Content.Load<Texture2D>("Arrow");
      player = new BoardPlayer(this, sprite, arrowSprite);

      wall = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
      wall.SetData(new[] { Color.White });

      Components.Add(main);
      Components.Add(player);
    }

    protected override void UnloadContent()
    {
    }

    protected override void Update(GameTime gameTime)
    {
      int gameStatus= BubbleHolder.checkGameStatus();
      if(gameStatus == 0)
      {
        Console.WriteLine("You have won the game");//win
        MessageBox(new IntPtr(0), "You have won the game! with score:"+BubbleHolder.score, "Winner!", 0);
        if (CurrentLevel == 1)
        {
          changeLevel();
        }
        else
        {
          Exit();
        }
      }
      else if (gameStatus == 1)
      {
        Console.WriteLine("You have lost the game!!");//lose
        MessageBox(new IntPtr(0), "You have lost the game!", "Loser!", 0);
        Exit();
      }
      else
      {
        handleKeyboard();

        sourceRect = new Rectangle(0, 0, spriteWidth, spriteHeight);
        origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

        base.Update(gameTime);
      }
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      base.Draw(gameTime);
      spriteBatch.End();
    }
    protected void handleKeyboard()
    {
      KeyboardState keyState = Keyboard.GetState();

      if (keyState.IsKeyDown(Keys.Escape) && !oldState.IsKeyDown(Keys.Escape))
        this.Exit();
      if (keyState.IsKeyDown(Keys.Left) && !oldState.IsKeyDown(Keys.Left))
        player.changeAngle(-1);
      if (keyState.IsKeyDown(Keys.Right) && !oldState.IsKeyDown(Keys.Right))
        player.changeAngle(1);
      if (keyState.IsKeyDown(Keys.Up) && !oldState.IsKeyDown(Keys.Up))
        player.shoot();
      if (keyState.IsKeyDown(Keys.Z) && !oldState.IsKeyDown(Keys.Z))
      {
        MessageBox(new IntPtr(0), "Your score is: "+BubbleHolder.score, "Score", 0);
      }
      /*
      MouseState mouse = Mouse.GetState();
      player.setAngle(mouse.X, mouse.Y);
      if(mouse.LeftButton == ButtonState.Pressed)
      {
        player.shoot();
      }
       */
      oldState = keyState;
    }

    public static void DrawLine(SpriteBatch batch, Texture2D blank,
              float width, Color color, Vector2 point1, Vector2 point2)
    {
      float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
      float length = Vector2.Distance(point1, point2);

      batch.Draw(blank, point1, null, color,
                 angle, Vector2.Zero, new Vector2(length, width),
                 SpriteEffects.None, 0);
    }
    public void changeLevel()
    {
      Components.Remove(main);
      Components.Remove(player);
      CurrentLevel = 2;
      sprite = Content.Load<Texture2D>("Bubbles");
      BubbleCreator.setXNA(this, sprite);
      main = new BoardMain(this, sprite, CurrentLevel);
      arrowSprite = Content.Load<Texture2D>("Arrow");
      player = new BoardPlayer(this, sprite, arrowSprite);
      BubbleHolder.score = 0;
      Components.Add(main);
      Components.Add(player);
    }
  }
}
