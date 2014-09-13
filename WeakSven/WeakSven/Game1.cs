using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA_GUI;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Button button = new Button(new Rectangle(0, 0, 200, 50));

        public Player player1 = new Player(new Vector2(2, 25));
        public Player player2 = new Player(new Vector2(730, 410));

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

            player2.shootUp = Keys.NumPad8;
            player2.shootDown = Keys.NumPad5;
            player2.shootLeft = Keys.NumPad4;
            player2.shootRight = Keys.NumPad6;
           
            player2.moveUp = Keys.Up;
            player2.moveDown = Keys.Down;
            player2.moveLeft = Keys.Left;
            player2.moveRight = Keys.Right;
        }          

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            UIManager.Init(GraphicsDevice, Content.Load<SpriteFont>("Segoe"));
            button.Text = "Click me!";

            button.onClick += button_onClick;

            level.LoadTextures(Content);
            level.Load(1,Content);

			player1.Load(Content, "Characters/Player");
            player2.Load(Content, "Characters/Player2");
            Projectile.StaticLoad(Content, "Effects/ShootUp");
            Projectile.StaticLoad(Content, "Effects/ShootDown");
            Projectile.StaticLoad(Content, "Effects/ShootLeft");
            Projectile.StaticLoad(Content, "Effects/ShootRight");
        }

        void button_onClick(Component sender)
        {
            ((Button)sender).Text = "Clicked!";
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {

           // Player1.Instance.rect.Intersects

          

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();
            UIManager.Update();

            player1.Update(gameTime);
            player2.Update(gameTime);
            level.Update(gameTime, player1, player2);
			//Player.Instance.Update(gameTime);
            //Player2.Instance.Update(gameTime);
           

                if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                    previousKeyboard.IsKeyUp(Keys.Space))
                {
                    level.Next(Content);
                    player1.Position = new Vector2(2, 25);
                    player2.Position = new Vector2(730, 410);
                }
           

            previousKeyboard = Keyboard.GetState();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
          
            GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();

            level.Draw(spriteBatch);

            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);

			//Player.Instance.Draw(spriteBatch);
            //Player2.Instance.Draw2(spriteBatch);

            UIManager.Draw(spriteBatch);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
