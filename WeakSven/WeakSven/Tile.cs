using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakSven
{
    public class Tile
    {
            private Texture2D img = null;
            public Rectangle Rect { get; private set; }

            public Tile(Texture2D tileTexture, int x, int y)
            {
                img = tileTexture;
                Rect = new Rectangle(x, y, 25, 25);
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(img, Rect, Color.White);
            }        
    }
}
