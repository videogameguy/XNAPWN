using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    // sealed
    class Player1 : InteractiveCharacter
    {
        #region Singleton Stuff
        private static Player1 instance = null;
        public static Player1 Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player1();

                return instance;
            }
        }

        private Player1() : base() { }
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

            if (Keyboard.GetState().IsKeyDown(Keys.Y) && Game1.previousKeyboard.IsKeyUp(Keys.Y))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitY));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.H) && Game1.previousKeyboard.IsKeyUp(Keys.H))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitY));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.G) && Game1.previousKeyboard.IsKeyUp(Keys.G))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitX));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.J) && Game1.previousKeyboard.IsKeyUp(Keys.J))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitX));
            }
            
            foreach (Projectile b in bullets)
                b.Update(gameTime);

            base.Update(gameTime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            foreach (Projectile b in bullets)
                b.Draw(spriteBatch);
        }
    }
}