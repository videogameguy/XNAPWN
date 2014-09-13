﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
	public class Character : Entity
	{
		public Animation animation = new Animation();

		public Rectangle rect = new Rectangle(0, 0, 0, 0);

		public Vector2 Position { get; set; }

		public Vector2 Velocity = Vector2.Zero;
        

		public float Speed { get; set; }

		public Character() : base() 
        {
            Speed = 2.5f; 
        }

        public Character(Vector2 startPosition)
            : base()
        {
            Speed = 2.5f; 
            Position = startPosition;
        }

		public Character(string name) : base(name) 
        { 
            Speed = 2.5f; 
        }

		public virtual void Load(ContentManager Content, string imageFile)
		{
			animation.FrameCountX = 4;
			animation.FrameCountY = 4;
			animation.FramesPerSec = 33;

			animation.SpriteSheet = Content.Load<Texture2D>(imageFile);

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;
			rect.Width = animation.FrameWidth;
			rect.Height = animation.FrameHeight;


		}

		public virtual void Update(GameTime gameTime)
		{
			Position += Velocity;

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;

			if (Velocity == Vector2.Zero)
			{
				animation.Frame = 1;
				animation.Paused = true;
			}
			else
				animation.Paused = false;

			animation.Update(gameTime);

		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			animation.Draw(spriteBatch, Position);
		}


	}
}