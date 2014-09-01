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
            else
                Velocity = Vector2.Zero;

            base.Update(gameTime);
        }
    }
}