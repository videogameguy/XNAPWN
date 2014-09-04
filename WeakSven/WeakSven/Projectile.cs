using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakSven
{
    public class Projectile : Character
    {
        Texture2D projectileSpriteM;
        Texture2D projectileSpriteZ;
        Rectangle projectileHitBox;

        /*
        Vector2 projectilePosition;
        Vector2 projectileOrigin;
        float projectileScale;
        float projectileRotation;
        */

        public Projectile(Texture2D spriteTexture, Vector2 projectilePosition) 
        {
            projectileSpriteM = spriteTexture;
            projectileSpriteZ = spriteTexture;
            // insert additional code here, such as creation of hitbox
        }

        Projectile Bullet; // declaration of single bullet
        List<Projectile> Bullets; // to track multiple bullets at once

        public override void Update(GameTime gameTime)
        {
            
            // Creation of new bullet
            Bullet = new Projectile(projectileSpriteM, Player2Position);

            // If you need to add to the list
            Bullets.Add(new Projectile(projectileSpriteM, Player2Position)); // or in this case just add Bullet

            // Creation of new bullet
            Bullet = new Projectile(projectileSpriteZ, Player1Position);

            // If you need to add to the list
            Bullets.Add(new Projectile(projectileSpriteZ, Player1Position)); // or in this case just add Bullet
                       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletTexture, bulletHitBox, Color.White); 
        }

        public override void Draw (GameTime gameTime)
        {
            
            Projectile.Draw(spriteBatch);
                        
        }

        
        // if single projectile
        int Bullet = 0;

        }
}

