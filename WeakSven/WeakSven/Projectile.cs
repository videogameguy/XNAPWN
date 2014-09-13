﻿using Microsoft.Xna.Framework;
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
        public static Animation sharedAnimation = new Animation();

        public Projectile(Vector2 startPosition, Vector2 direction) 
        {
            Speed = 5.0f;
            Velocity = direction * Speed;
            
            Position = startPosition;
            
            
            rect.X = (int)Position.X;
            rect.Y = (int)Position.Y;
            rect.Width = sharedAnimation.FrameWidth;
            rect.Height = sharedAnimation.FrameHeight;
        }


        public override void Load(ContentManager Content, string imageFile)
        {
            throw new Exception("Don't use this.  Use Projectile.StaticLoad instead.");
        }

        public static void StaticLoad(ContentManager Content, string imageFile)
        {

            sharedAnimation.FrameCountX = 2;
            sharedAnimation.FrameCountY = 2;
            sharedAnimation.FramesPerSec = 8;

			sharedAnimation.SpriteSheet = Content.Load<Texture2D>(imageFile);
    
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            rect.X = (int)Position.X;
            rect.Y = (int)Position.Y;

            
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sharedAnimation.Draw(spriteBatch, Position);
   
        }

       
    }
}
       
        
    

