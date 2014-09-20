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

        public Player player1 = new Player(new Vector2(300, 75));
        public Player player2 = new Player(new Vector2(500, 350));
        public MainMenu mainMenu = new MainMenu();
        //public Enemy enemy = new Enemy(new Vector2(400, 60));

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
            //UIManager.Init(GraphicsDevice, Content.Load<SpriteFont>("Segoe"));
            //button.Text = "Click me!";

            //button.onClick += button_onClick;

            mainMenu.Load(Content, level);

            level.LoadTextures(Content);
            level.Load(1, Content);

			player1.Load(Content, "Characters/Zero");
            player2.Load(Content, "Characters/MegamanX");
            Projectile.StaticLoad(Content, new string[] { "Effects/SkullUp", "Effects/SkullDown", "Effects/SkullLeft", "Effects/SkullRight" });
                       
        }

        void button_onClick(Component sender)
        {
           // ((Button)sender).Text = "Clicked!";
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {         

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

            UIManager.Update();

            player1.Update(gameTime);
            player2.Update(gameTime);
            level.Update(gameTime, player1, player2);

            //Singleton Stuff
			//Player.Instance.Update(gameTime);
            //Player2.Instance.Update(gameTime);
           

                if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                    previousKeyboard.IsKeyUp(Keys.Space))
                {
                    level.Next(Content);
                    player1.Position = new Vector2(25, 50);
                    player2.Position = new Vector2(700, 350);
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

            //Stingleton Stuff
			//Player.Instance.Draw(spriteBatch);
            //Player2.Instance.Draw2(spriteBatch);

            UIManager.Draw(spriteBatch);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
