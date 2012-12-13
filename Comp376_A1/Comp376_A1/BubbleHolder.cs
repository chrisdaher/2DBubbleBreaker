using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp376_A1
{
  class BubbleHolder
  {
    public static GridSquare[,] grid;
    private static List<Bubble> popped;
    public static int score;
    public static bool checkColliding(Bubble b)
    {
      bool isColliding = false;
      for (int i = 0; i <= grid.GetUpperBound(0); i++)
      {
        for (int j = 0; j <= grid.GetUpperBound(1); j++)
        {
          if (grid[i, j].isColliding(b.getPosition()))
          {
            isColliding = true;
          }
        }
      }
      return isColliding;
    }

    public static void initGrid()
    {
      score = 0;
      int right = 0, down = 0;
      float increment = 20;
      float posX = 200;
      float posY = 20;
      grid = new GridSquare[8, 10];
      for (int j = 0; j <= grid.GetUpperBound(1); j++)
      {
        down++;
        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
          right++;
          if (down % 2 == 0)
          {
            grid[i, j] = new GridSquare(new Point(posX + 10 + (right * 20), posY + (down * increment)));
            grid[i, j].x = i;
            grid[i, j].y = j;
          }
          else
          {
            grid[i, j] = new GridSquare(new Point(posX + (right * 20), posY + (down * increment)));
            grid[i, j].x = i;
            grid[i, j].y = j;
          }

        }
        right = 0;
      }
    }
    public static float getSnappingScore(Bubble b, GridSquare grid)
    {
      return (Math.Abs(b.getPosition().x - grid.point.x) + Math.Abs(b.getPosition().y - grid.point.y) );
    } 
    public static void snapToGrid(Bubble b)
    {
      bool found = false;
      GridSquare best;
      best = grid[0, 0];
      for (int j = 0; j <= grid.GetUpperBound(1); j++)
      {
        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
          if (grid[i, j].enoughToSnap(b.getPosition()))
          {
            best = grid[i,j];

            found = true;
            break;
          }
          else if(grid[i,j].bubble !=null && getSnappingScore(b, grid[i,j]) < getSnappingScore(b, best))
          {
            best = grid[i, j];
          }
        }
        if (found)
        {
          break;
        }
      }
       
      b.setPosition(new Point(best.point));
      best.bubble = b;
      popped = new List<Bubble>();
      checkPopping(best);
      if (popped.Count > 2)
      {
        popBubbles();
      }
    }

    private static void checkPopping(GridSquare tempGrid)
    {
      List<int[]> positions = new List<int[]>();
      if (tempGrid.y % 2 == 1)
      {
        positions.Add(new int[] { tempGrid.x, tempGrid.y - 1 });      //top left
        positions.Add(new int[] { tempGrid.x + 1, tempGrid.y - 1 });  //top right
        positions.Add(new int[] { tempGrid.x - 1, tempGrid.y });      //left
        positions.Add(new int[] { tempGrid.x + 1, tempGrid.y });      //right
        positions.Add(new int[] { tempGrid.x, tempGrid.y + 1 });      //bottom left
        positions.Add(new int[] { tempGrid.x + 1, tempGrid.y + 1 });      //bottom right
      }
      else
      {
        positions.Add(new int[] { tempGrid.x - 1, tempGrid.y - 1 });      //top left
        positions.Add(new int[] { tempGrid.x, tempGrid.y - 1 });  //top right
        positions.Add(new int[] { tempGrid.x - 1, tempGrid.y });      //left
        positions.Add(new int[] { tempGrid.x + 1, tempGrid.y });      //right 
        positions.Add(new int[] { tempGrid.x - 1, tempGrid.y + 1 });      //bottom left
        positions.Add(new int[] { tempGrid.x, tempGrid.y + 1 });      //bottom right
      }

      for (int i = 0; i < positions.Count;i++ )
      {
        if(positions[i][0]>=0 && positions[i][0]<= grid.GetUpperBound(0) && positions[i][1]>=0 && positions[i][1]<=grid.GetUpperBound(1))
        {
          Bubble b = grid[positions[i][0], positions[i][1]].bubble;
          if( b != null && b.getColor()==tempGrid.bubble.getColor() && !popped.Contains(b))
          {
            if(!popped.Contains(tempGrid.bubble))
            {
              popped.Add(tempGrid.bubble);
            }
            popped.Add(b);
            checkPopping(grid[positions[i][0], positions[i][1]]);
          }
        }
      }
    }

    private static void popBubbles()
    {
      for (int i = 0; i < popped.Count;i++ )
      {
        popped[i].popBubble();
        score += 10;
      }
    }

    public static void RemovePopped()
    {
      for (int j = 0; j <= grid.GetUpperBound(1); j++)
      {
        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
          if (grid[i,j].bubble!= null && grid[i, j].bubble.isPopped)
          {
            grid[i, j].bubble = null;
          }
        }
      }
    }

    public static List<Bubble> getBubbles()
    {
      List<Bubble> bubbles = new List<Bubble>();
      for (int j = 0; j <= grid.GetUpperBound(1); j++)
      {
        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
          if (grid[i, j].bubble != null && !grid[i,j].bubble.isPopped)
          {
            bubbles.Add(grid[i, j].bubble);
          }
        }
      }
      return bubbles;
    }

    public static int checkGameStatus()
    {
      if (getBubbles().Count == 0)
      {
        return 0;
      }
      for(int i=0; i < grid.GetUpperBound(0);i++){
        if(grid[i,9].bubble!=null)
        {
          return 1;
        }
      }
      return 2;

    }
  }
}
