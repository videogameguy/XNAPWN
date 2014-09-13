using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WeakSven
{
    public class Projectile : Character
    {
        public static Texture2D sharedUp = null;
        public static Texture2D sharedDown = null;
        public static Texture2D sharedLeft = null;
        public static Texture2D sharedRight = null;

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Direction direction = Direction.Up;

        public Projectile(Vector2 startPosition, Vector2 direction) 
        {
            Speed = 5.0f;
            Velocity = direction * Speed;
            
            Position = startPosition;
            
            rect.X = (int)Position.X;
            rect.Y = (int)Position.Y;
            rect.Width = sharedUp.Width;
            rect.Height = sharedUp.Height;
        }


        public override void Load(ContentManager Content, string imageFile)
        {
            throw new Exception("Don't use this.  Use Projectile.StaticLoad instead.");
        }

        public static void StaticLoad(ContentManager Content, string[] imageFile)
        {
            sharedUp = Content.Load<Texture2D>(imageFile[0]);
            sharedDown = Content.Load<Texture2D>(imageFile[1]);
            sharedLeft = Content.Load<Texture2D>(imageFile[2]);
            sharedRight = Content.Load<Texture2D>(imageFile[3]);
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            rect.X = (int)Position.X;
            rect.Y = (int)Position.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (direction == Direction.Up)
                spriteBatch.Draw(sharedUp, rect, Color.White);
            else if (direction == Direction.Down)
                spriteBatch.Draw(sharedDown, rect, Color.White);
            else if (direction == Direction.Left)
                spriteBatch.Draw(sharedLeft, rect, Color.White);
            else if (direction == Direction.Right)
                spriteBatch.Draw(sharedRight, rect, Color.White);
        }
    }
}