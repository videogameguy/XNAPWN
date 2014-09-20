using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XNA_GUI;

namespace WeakSven
{
    public class ImageButton : Button
    {
        Texture2D image = null;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Rect, Color.White);
        }

        public void Load(ContentManager content, string imageName)
        {
            image = content.Load<Texture2D>(imageName);
        }
    }
}
