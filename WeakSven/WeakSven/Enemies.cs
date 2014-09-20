using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
    public class Enemy : Character
    {
        Vector2 Destination = new Vector2();
        Texture2D img = null;

        Player target = null;

        public Enemy() : base() { }

        public Enemy(Vector2 startPosition) : base(startPosition) { }

        public void EnemyFollow(Player player)
        {
            target = player;
        }

        public override void Load(ContentManager Content, string imageFile)
        {
            base.Load(Content, imageFile);

            //bing.Sound = Content.Load<SoundEffect>("Audio/SFX/bing");
        }

        public override void Update(GameTime gameTime)
        {
            if (target != null)
            {
                Velocity = (target.Position - Position);
                Velocity.Normalize();
                Velocity *= Speed;
            }

            base.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, rect, Color.Black);
        }

    }
}
