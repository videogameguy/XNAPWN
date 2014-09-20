using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_GUI
{
    public class UIManager
    {

        public static SpriteFont font { get; private set; }
        public static Texture2D square { get; private set; }

        private static List<Component> components = new List<Component>();
        private static List<Component> removes = new List<Component>();
        
        private UIManager() { }

        public static void Init(GraphicsDevice graphics, SpriteFont font)
        {
            UIManager.square = new Texture2D(graphics, 1, 1);
            UIManager.square.SetData(new Color[] { Color.White });
            UIManager.font = font;
        }

        public static void Add(Component uiElement)
        {
            components.Add(uiElement);
        }

        public static void Update()
        {
            foreach (Component c in components)
                c.Update();

            if (removes.Count > 0)
            {
                foreach (Component r in removes)
                    components.Remove(r);

                removes.Clear();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component c in components)
                c.Draw(spriteBatch);
        }

        public static void Unload(Component c)
        {
            removes.Add(c);
        }
    }
}
