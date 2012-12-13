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
  class BoardPlayer : Board
  {
    const float angleIncrement = 0.1f;
    const float velocityIncrement = 10;
    const float angleLimit = 45;

    const float intervalToShoot=500;
    float currentShootingTime;
    Texture2D bubbleTexture;
    Texture2D arrowTexture;
    Game game;
    Point[] locations;
    Point boardPosition;
    Bubble[] bubbles;
    Angle currentAngle;

    Arrow arrow;

    public BoardPlayer(Game g, Texture2D bTexture, Texture2D aTexture)
      : base(g)
    {
      bubbleTexture = bTexture;
      currentShootingTime = 0;
      arrowTexture = aTexture;
      game = g;
      locations = new Point[3];
      boardPosition = new Point(320, 300);
      bubbles = new Bubble[3];
      currentAngle = new Angle(0);
      Initialize();
    }

    public override void Initialize()
    {
      locations[0] = new Point(boardPosition.x - 10, boardPosition.y-20);
      locations[1] = new Point(boardPosition.x - 50, boardPosition.y);
      locations[2] = new Point(boardPosition.x - 80, boardPosition.y);

      bubbles[0] = BubbleCreator.createRandomBubble(locations[0]);
      childComponents.Add(bubbles[0]);

      bubbles[1] = BubbleCreator.createRandomBubble(locations[1]);
      childComponents.Add(bubbles[1]);

      bubbles[2] = BubbleCreator.createRandomBubble(locations[2]);
      childComponents.Add(bubbles[2]);

      arrow = new Arrow(Game, arrowTexture, new Point(locations[0].x, locations[0].y), new Angle(0));
      childComponents.Add(arrow);
      base.Initialize();
      
    }

    public override void Update(GameTime gameTime)
    {
      currentTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
      if (currentTime > interval)
      {
        currentShootingTime++;
        if(currentShootingTime>intervalToShoot)
        {
          shoot();
          currentShootingTime = 0;
        }
        childComponents = new List<GameComponent>();
        childComponents.Add(arrow);
        childComponents.Add(bubbles[0]);
        childComponents.Add(bubbles[1]);
        childComponents.Add(bubbles[2]);

        currentTime = 0f;
        base.Update(gameTime);
        checkCollisions();
      }
    }

    public override void Draw(GameTime gameTime)
    {
      
      base.Draw(gameTime);
    }

    public void changeAngle(int direction)
    {
      currentAngle.degrees += Angle.toDegrees(angleIncrement * direction);
      if (currentAngle.degrees > angleLimit)
      {
        currentAngle.degrees = angleLimit;
      }
      else if (currentAngle.degrees < -angleLimit)
      {
        currentAngle.degrees = -angleLimit;
      }
      arrow.setAngle(currentAngle);
    }

    public void setAngle(float a)
    {
      currentAngle.degrees = Angle.toDegrees(a);
      if (currentAngle.degrees > angleLimit)
      {
        currentAngle.degrees = angleLimit;
      }
      else if (currentAngle.degrees < -angleLimit)
      {
        currentAngle.degrees = -angleLimit;
      }
      arrow.setAngle(currentAngle);
    }
    public void setAngle(float x, float y)
    {
      float angle = (y - arrow.getPosition().y)/(x-arrow.getPosition().x);
      angle = (float)Math.Atan(angle);
      currentAngle.degrees = 90- Angle.toDegrees(angle);
      if (currentAngle.degrees > angleLimit)
      {
        currentAngle.degrees = angleLimit;
      }
      else if (currentAngle.degrees < -angleLimit)
      {
        currentAngle.degrees = -angleLimit;
      }
      arrow.setAngle(currentAngle);
    }

    public void shoot()
    {
      bubbles[0].setVelocity(currentAngle.getVelocity(velocityIncrement));
    }

    public void checkCollisions()
    {
      if (BubbleHolder.checkColliding(bubbles[0]))
      {
        bubbles[0].stop();
        BubbleHolder.snapToGrid(bubbles[0]);
        changeBubbles();
      }
      if(BoardMain.checkWallCollision(bubbles[0])){
        Velocity temp = bubbles[0].getVelocity();
        bubbles[0].setVelocity(new Velocity(-temp.x, temp.y));
      }
      if (BoardMain.checkReachedLimit(bubbles[0]))
      {
        bubbles[0].stop();
        BubbleHolder.snapToGrid(bubbles[0]);
        bubbles[0].popBubble();
        changeBubbles();
      }
    }

    public void changeBubbles()
    {
      bubbles[1].moveTo(locations[0], interval);
      bubbles[2].moveTo(locations[1], interval);

      bubbles[0] = bubbles[1];
      bubbles[1] = bubbles[2];

      bubbles[2] = BubbleCreator.createRandomBubble(locations[2]);
      childComponents.Add(bubbles[2]);
    }
  }
}
