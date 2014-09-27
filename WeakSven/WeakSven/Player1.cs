﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    // sealed
    public class Player : InteractiveCharacter
    {
        //notes
        #region Singleton Stuff
        //private static Player1 instance = null;
        //public static Player1 Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new Player1(new Vector2 (5, 25));

        //        return instance;
        //    }
        //}


        #endregion



        public Player() : base() { }
        public Player(Vector2 startPosition) : base(startPosition) { }
        public AudioSFX shoot = new AudioSFX();
		public AudioSFX die = new AudioSFX();

        public void SetName(string name) { Name = name; }

        private List<Projectile> bullets = new List<Projectile>(10);

        public List<Projectile> Bullets { get { return bullets; } }

        public Keys shootUp = Keys.Y;
        public Keys shootDown = Keys.H;
        public Keys shootLeft = Keys.G;
        public Keys shootRight = Keys.J;

        public Keys moveUp = Keys.W;
        public Keys moveDown = Keys.S;
        public Keys moveLeft = Keys.A;
        public Keys moveRight = Keys.D;

        public override void Load(ContentManager Content, string imageFile)
        {
            base.Load(Content, imageFile);

            shoot.Sound = Content.Load<SoundEffect>("Music/ShotSound");
			die.Sound = Content.Load<SoundEffect>("Music/Death");
        }

        public override void Update(GameTime gameTime)
        {
            //animation.sequenceStart = 0;
            //animation.sequenceEnd = animation.sequenceStart + animation.FrameCountX * 2;
            // TODO:  Change player controls to fit your game

            if (Keyboard.GetState().IsKeyDown(moveUp))
            {
                Velocity.Y = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(moveDown))
            {
                Velocity.Y = +Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(moveLeft))
            {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(moveRight))
            {
                Velocity.X = +Speed;
            }
            else
                Velocity = Vector2.Zero;

            // projectile directions

            if (Keyboard.GetState().IsKeyDown(shootUp) && Game1.previousKeyboard.IsKeyUp(shootUp))
            {
                bullets.Add(new Projectile(Position, -Vector2.UnitY) { direction = Projectile.Direction.Up });
                shoot.FireAndForget();
            }
            else if (Keyboard.GetState().IsKeyDown(shootDown) && Game1.previousKeyboard.IsKeyUp(shootDown))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitY) { direction = Projectile.Direction.Down });
				shoot.FireAndForget();
            }
            else if (Keyboard.GetState().IsKeyDown(shootLeft) && Game1.previousKeyboard.IsKeyUp(shootLeft))
            {
                bullets.Add(new Projectile(Position, -Vector2.UnitX) { direction = Projectile.Direction.Left });
				shoot.FireAndForget();
            }
            else if (Keyboard.GetState().IsKeyDown(shootRight) && Game1.previousKeyboard.IsKeyUp(shootRight))
            {
                bullets.Add(new Projectile(Position, Vector2.UnitX) { direction = Projectile.Direction.Right });
				shoot.FireAndForget();
            }

            foreach (Projectile b in bullets)
                b.Update(gameTime);

            base.Update(gameTime);

        }

        public void Die(Player player1, Player player2)
        {
            player1.Position = new Vector2(25, 50);
            player2.Position = new Vector2(730, 410);
			die.FireAndForget();

        }

        public void enemyDeath(Player player,Enemy enemy)
        {
            player.Position = new Vector2(25, 50);
            enemy.Position = new Vector2(300, 700);

        }

        public void enemyDeath2(Player player, Enemy enemy)
        {
            player.Position = new Vector2(730, 410);
            enemy.Position = new Vector2(500, -300);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            foreach (Projectile b in bullets)
                b.Draw(spriteBatch);
        }
    }
}