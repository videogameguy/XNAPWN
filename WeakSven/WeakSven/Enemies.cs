using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WeakSven
{
    class Enemy : Character
    {
        Vector2 Destination = new Vector2();


        public Enemy() : base() { }

        public Enemy(Vector2 startPosition) : base(startPosition) { }

        public void Follow()
        {
            

        }
        

    }
}
