using Microsoft.Xna.Framework;
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

		public void SetName(string name) { Name = name; }

		public override void Update(GameTime gameTime)
		{
			// TODO:  Change player controls to fit your game

			if (Keyboard.GetState().IsKeyDown(Keys.W) ||
				Keyboard.GetState().IsKeyDown(Keys.Up))
			{
				Velocity.Y = -Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.A) ||
				Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				Velocity.X = -Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.S) ||
				Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				Velocity.Y = Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.D) ||
				Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				Velocity.X = Speed;
			}
			else
				Velocity = Vector2.Zero;

			base.Update(gameTime);
		}
	}
}