using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static KeyboardState previousKeyboard;

        Level level = new Level();
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

			IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            level.LoadTextures(Content);
            level.Load(1);

			Player1.Instance.Load(Content, "Characters/Player");
            Player2.Instance.Load(Content, "Characters/Player2");
            Projectile.StaticLoad(Content, "Effects/ShootUp");
            Projectile.StaticLoad(Content, "Effects/ShootDown");
            Projectile.StaticLoad(Content, "Effects/ShootLeft");
            Projectile.StaticLoad(Content, "Effects/ShootRight");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

			Player1.Instance.Update(gameTime);
            Player2.Instance.Update(gameTime);
           

                if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                    previousKeyboard.IsKeyUp(Keys.Space))
                {
                    level.Next();
                }
           

            previousKeyboard = Keyboard.GetState();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
			spriteBatch.Begin();

			Player1.Instance.Draw(spriteBatch);
            Player2.Instance.Draw2(spriteBatch);

            level.Draw(spriteBatch);


			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
