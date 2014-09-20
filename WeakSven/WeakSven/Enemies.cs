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

        Player target = null;

        public Enemy() : base() { Speed = 0.0001f; }

        public Enemy(Vector2 startPosition) : base(startPosition) { }

        public void EnemyFollow(Player player)
        {
            target = player;
        }

        public override void Load(ContentManager Content, string imageFile)
        {
            img=Content.Load<Texture2D>(imageFile);
            rect.Width = img.Width;
            rect.Height = img.Height;
            //bing.Sound = Content.Load<SoundEffect>("Audio/SFX/bing");
        }

        public override void Update(GameTime gameTime)
        {
            if (target != null)
            {
                Velocity = (target.Position - Position);
                Velocity.Normalize();
                Velocity *= Speed / 2;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, rect, Color.Azure);
        }

    }
}
