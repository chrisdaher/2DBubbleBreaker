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
  abstract class Drawable : Microsoft.Xna.Framework.DrawableGameComponent
  {
    //the file where the bubble sprite is located
    public string file { get; set; }

    //x and y location of this specific bubble in the image file
    public int sourceX { get; set; }
    public int sourceY { get; set; }

    //dimensions of the sprite in the image file
    public Dimension dimensions{ get; set; }
    
    //xna required
    public SpriteBatch spriteBatch { get; set; }
    public GraphicsDeviceManager graphics { get; set; }
    public Texture2D texture { get; set; }
    public Rectangle section { get; set; }
    public Vector2 origin { get; set; }

    //the displayable object that the drawable will be holding
    public Model displayable { get; set; }

    public Drawable(Game game,Texture2D t, string f, int sx, int sy, Model d)
      :base(game)
    {
      displayable = d;
      file = f;
      sourceX = sx;
      sourceY = sy;
      dimensions = displayable.dimensions;
      section = new Rectangle(sourceX, sourceY, dimensions.width, dimensions.height);
      origin = new Vector2(section.Width / 2, section.Height / 2);
      texture = t;
      spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
    }

    public Drawable(Game game, Texture2D t, string f, int sx, int sy, int w, int h, Model d)
      :base(game)
    {
      displayable = d;
      file = f;
      sourceX = sx;
      sourceY = sy;
      dimensions = new Dimension(w, h);
      section = new Rectangle(sourceX, sourceY, dimensions.width, dimensions.height);
      origin = new Vector2(section.Width / 2, section.Height / 2);
      texture = t;
      spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
    }

    public Drawable(Drawable d, Model m)
      : base(d.Game)
    {
      displayable = m;
      file = d.file;
      sourceX = d.sourceX;
      sourceY = d.sourceY;
      dimensions = new Dimension(d.dimensions);
      section = new Rectangle(sourceX, sourceY, dimensions.width, dimensions.height);
      origin = new Vector2(section.Width / 2, section.Height / 2);
      texture = d.texture;
      spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
    }
    public void setPosition(Point p)
    {
      displayable.position = new Point(p);
    }
    public Point getPosition()
    {
      return displayable.position;
    }

    public void setDimensions(Dimension d)
    {
      dimensions = d;
    }
    public Dimension getDimensions()
    {
      return dimensions;
    }

    public void setDisplayableDimensions(Dimension d)
    {
      displayable.dimensions = new Dimension(d); ;
    }
    public Dimension getDisplayableDimensions()
    {
      return displayable.dimensions;
    }


    public override void Initialize()
    {
      base.Initialize();
    }
    public override void Update(GameTime gameTime)
    {
      displayable.move();
      base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
      base.Draw(gameTime);
    }
    public void setVelocity(Velocity v)
    {
      this.displayable.setVelocity(v);
    }
    public Velocity getVelocity()
    {
      return this.displayable.velocity;
    }
    public void move()
    {
      this.displayable.move();
    }
    public void moveTo(Point p, float speed)
    {
      this.displayable.moveTo(p,speed);
    }
    public void stop()
    {
      displayable.stop();
    }
  }
}
