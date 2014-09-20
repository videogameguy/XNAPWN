using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XNA_GUI;

namespace XNA_GUI
{
    //    public class ImageButton : Button
    //    {
    //        Texture2D image = null;

<<<<<<< HEAD:WeakSven/WeakSven/ImageButton.cs
    //        public override void Draw(SpriteBatch spriteBatch)
    //        {
    //            spriteBatch.Draw(image, Rect, Color.White);
    //        }

    //        public void Load(ContentManager content, string imageName)
    //        {
    //            image = content.Load<Texture2D>(imageName);
    //        }
    //    }
    //}
}
=======
        public ImageButton(Rectangle whereItsAt) : base(whereItsAt) { }

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
>>>>>>> ddb40c1ec1109078de42c9eb237025622079129a:XNA_GUI/ImageButton.cs
