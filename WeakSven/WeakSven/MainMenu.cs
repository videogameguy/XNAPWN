using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using XNA_GUI;

namespace WeakSven
{
    public class MainMenu : Menu
    {

        public MainMenu() { }

        public override void Load(ContentManager Content)
        {
            base.Load(Content);
        }

        public void Load(ContentManager Content, Level level)
        {
            ImageButton b1 = new ImageButton(new Rectangle(75,25, 300, 200));
            b1.Load(Content, "Level_Images/Level1Image");
            b1.onClick += delegate(Component sender)
            {
                // Go to level i + 1
                level.Load(2);
                Unload();
            };
            components.Add(b1);

            ImageButton b2 = new ImageButton(new Rectangle(425, 25, 300, 200));
            b2.Load(Content, "Level_Images/Level2Image");
            b2.onClick += delegate(Component sender)
            {
                // Go to level i + 1
                level.Load(3);
                Unload();
            };
            components.Add(b2);

            ImageButton b3 = new ImageButton(new Rectangle(75, 250, 300, 200));
            b3.Load(Content, "Level_Images/Level3Image");
            b3.onClick += delegate(Component sender)
            {
                // Go to level i + 1
                level.Load(4);
                Unload();
            };
            components.Add(b3);

            ImageButton b4 = new ImageButton(new Rectangle(425, 250, 300, 200));
            b4.Load(Content, "Level_Images/Level4Image");
            b4.onClick += delegate(Component sender)
            {
                // Go to level i + 1
                level.Load(5);
                Unload();
            };
            components.Add(b4);


        }
    }
}
