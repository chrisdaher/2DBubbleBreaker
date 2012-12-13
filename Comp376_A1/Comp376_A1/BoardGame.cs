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
  class BoardGame : Board
  {
    Board playerBoard;
    Board bubbleBoard;

    public BoardGame(Game game, Texture2D bubble, Texture2D arrowTexture)
      : base(game)
    {
      playerBoard = new BoardPlayer(game, bubble, arrowTexture);
    }

  }
}
