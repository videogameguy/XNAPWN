using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakSven
{
    class Projectile : Character
    {
        Texture2D projectileSprite;

        Rectangle projectileHitBox;

        /*
        Vector2 projectilePosition;
        Vector2 projectileOrigin;
        float projectileScale;
        float projectileRotation;
        */

        public Projectile(Texture2D projectileSprite, Vector2 projectilePosition)
        {
            

            // insert additional code here, such as creation of hitbox
        }

        Projectile Bullet; // declaration of single bullet
        List<Projectile> Bullets; // to track multiple bullets at once

        public override void Update(GameTime gameTime)
        {

            // Creation of new bullet
            Bullet = new Projectile(projectileSprite, Player2.Instance.Position);

            // If you need to add to the list
            Bullets.Add(new Projectile(projectileSprite, Player2.Instance.Position)); // or in this case just add Bullet

            // Creation of new bullet
            Bullet = new Projectile(projectileSprite, Player1.Instance.Position);

            // If you need to add to the list
            Bullets.Add(new Projectile(projectileSprite, Player1.Instance.Position)); // or in this case just add Bullet

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(projectileSprite, projectileHitBox, Color.White);
        }

        /*public override void Draw (GameTime gameTime)
        {
            
            Projectile.Draw(spriteBatch);
                        
        } */
    }
}
       
        
    

