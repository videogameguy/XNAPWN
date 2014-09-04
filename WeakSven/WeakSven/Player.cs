using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
	// sealed
	class Player : InteractiveCharacter
	{
		#region Singleton Stuff
		private static Player instance = null;
		public static Player Instance
		{
			get
			{
				if (instance == null)
					instance = new Player();

				return instance;
			}
		}

		private Player() : base() { }
		#endregion

		public AudioSFX bing = new AudioSFX();

		public void SetName(string name) { Name = name; }

		public override void Load(ContentManager Content, string imageFile)
		{
			base.Load(Content, imageFile);

			bing.Sound = Content.Load<SoundEffect>("Audio/SFX/bing");
		}

		public override void Update(GameTime gameTime)
		{
			if (((int)gameTime.TotalGameTime.TotalSeconds) % 3 == 0)
				bing.Play(gameTime);

			// TODO:  Change player controls to fit your game

			if (Keyboard.GetState().IsKeyDown(Keys.W))
			{
				Velocity.Y = -Speed;
			}
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Velocity.Y = +Speed;
            }
			else if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				Velocity.X = -Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				Velocity.X = +Speed;
			}
			else
				Velocity = Vector2.Zero;

            // projectile directions

            if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                Velocity.Y = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                Velocity.Y = +Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.G))
            {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.J))
            {
                Velocity.X = +Speed;
            }

			base.Update(gameTime);
		}
	}
}