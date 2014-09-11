using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    // sealed
    class Player2 : InteractiveCharacter
    {
        
        #region Singleton Stuff
        private static Player2 instance = null;
        public static Player2 Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player2();

                return instance;
            }
        }

        private Player2() : base() { }
        
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
                    
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Velocity.Y = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Velocity.Y = +Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Velocity.X = +Speed;
            }

            // projectile directions

            /*
            if (Keyboard.GetState().IsKeyDown(Keys.Y) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad8))
            {
                bullets.Add(new Projectile(Position, -Vector2.UnitY));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.H) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad5))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitY));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.G) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad4))
            {
                bullets.Add(new Projectile(Position, -Vector2.UnitX));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.J) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad6))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitX));
            }
            base.Update(gameTime);
            */
        }
    }
}