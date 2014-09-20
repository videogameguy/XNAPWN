using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using XNA_GUI;

namespace WeakSven
{  
    public class Menu
    {
        protected List<Component> components = new List<Component>();

        public Menu() { }

        public virtual void Load(ContentManager content) { }

        public virtual void Unload()
        {
            foreach (Component c in components)
                c.Unload();
        }
    }
}
