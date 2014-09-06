using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState previousKeyboard;

        Level level = new Level();
        //LevelCreator builder = new LevelCreator();

        //private bool builderMode = false;

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

            //builder.LoadTextures(Content);

            level.LoadTextures(Content);
            level.Load(1);

			Player1.Instance.Load(Content, "Characters/Player");
            Player2.Instance.Load(Content, "Characters/Player2");
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

            //if (builderMode)
               // builder.Update(gameTime, previousKeyboard);
            //else
           // {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                    previousKeyboard.IsKeyUp(Keys.Space))
                {
                    level.Next();
                }
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Tab) &&
             //   previousKeyboard.IsKeyUp(Keys.Tab))
           // {
            //    builderMode = !builderMode;
           // }

            previousKeyboard = Keyboard.GetState();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			Player1.Instance.Draw(spriteBatch);
            Player2.Instance.Draw2(spriteBatch);

            //if (builderMode)
             //   builder.Draw(spriteBatch);
           // else
                level.Draw(spriteBatch);


			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
