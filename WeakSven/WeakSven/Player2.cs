using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        public List<Projectile> bullets = new List<Projectile>(10);


        public override void Load(ContentManager Content, string imageFile)
        {
            base.Load(Content, imageFile);

            bing.Sound = Content.Load<SoundEffect>("Audio/SFX/bing");
        }

        public override void Update(GameTime gameTime)
        {
            if (((int)gameTime.TotalGameTime.TotalSeconds) % 3 == 0)
                bing.Play(gameTime);

            animation.sequenceStart = 0;
            animation.sequenceEnd = animation.sequenceStart + animation.FrameCountX * 2;

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

            // projectile directions
            

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad8) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad8))
            {
                bullets.Add(new Projectile(Position2, -Vector2.UnitY));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad5) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad5))
            {
                bullets.Add(new Projectile(Position2, Vector2.UnitY));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad4) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad4))
            {
                bullets.Add(new Projectile(Position2, -Vector2.UnitX));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad6) && Game1.previousKeyboard.IsKeyUp(Keys.NumPad6))
            {
                bullets.Add(new Projectile(Position2, Vector2.UnitX));
            }

            foreach (Projectile b in bullets)
                b.Update(gameTime);

            base.Update(gameTime);
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw2(spriteBatch);

            foreach (Projectile b in bullets)
                b.Draw2(spriteBatch);
        }
    }
}