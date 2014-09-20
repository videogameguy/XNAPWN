using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WeakSven
{
    public class Level
    {
        int player1score = 0;
        int player2score = 0;

        public List<Tile> Tiles { get; private set; }
        public Dictionary<char, Texture2D> Textures { get; private set; }
        private ContentManager content = null;
        public MainMenu mainMenu = null;

        public Rectangle rect = new Rectangle(25, 50, 750, 400);

        SpriteFont font = null;

        private Texture2D backgroundImage = null;

        public int CurrentLevel { get; private set; }

        public Level(ContentManager content)
        {
            Tiles = new List<Tile>();
            Textures = new Dictionary<char, Texture2D>();
            this.content = content;
        }

        public void LoadTextures(ContentManager Content)
        {
            Textures.Add('z', Content.Load<Texture2D>("Tiles/Block"));
            Textures.Add('x', Content.Load<Texture2D>("Tiles/Grass"));
            Textures.Add('c', Content.Load<Texture2D>("Tiles/Concrete"));
            Textures.Add('v', Content.Load<Texture2D>("Tiles/Bricks"));
            Textures.Add('b', Content.Load<Texture2D>("Tiles/Chips"));
            Textures.Add('n', Content.Load<Texture2D>("Tiles/Pizza"));
            Textures.Add('m', Content.Load<Texture2D>("Tiles/Popcorn"));
            Textures.Add('a', Content.Load<Texture2D>("Tiles/Steak"));
            Textures.Add('s', Content.Load<Texture2D>("Tiles/Waffles"));
            Textures.Add('d', Content.Load<Texture2D>("Tiles/RedCar"));
            Textures.Add('f', Content.Load<Texture2D>("Tiles/BlueCar"));
            Textures.Add('g', Content.Load<Texture2D>("Tiles/GreenCar"));
            Textures.Add('h', Content.Load<Texture2D>("Tiles/YellowCar"));
            Textures.Add('j', Content.Load<Texture2D>("Tiles/Log"));
            Textures.Add('k', Content.Load<Texture2D>("Tiles/Skull"));

            font = Content.Load<SpriteFont>("Segoe");
        }

        private void Unload()
        {
            Tiles.Clear();
        }

        public void Next(ContentManager Content)
        {
            Load(CurrentLevel + 1);
        }

        //public void Menu(ContentManager Content)
        //{
        //    Load(CurrentLevel = 1, Content);
        //}

        public string GetLevelFile(int level)
        {
            return "Content/Levels/Level" + level + ".txt";
        }
       
        protected void DrawText(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Player 1:" + player1score, new Vector2(50, 0), Color.White);
            spriteBatch.DrawString(font, "Player 2:" + player2score, new Vector2(650, 0), Color.White);
        }

        public void Update(GameTime gameTime, Player player1, Player player2)
        {
            if (CheckBullets(player1, player2))
                player1score++;

            if (CheckBullets(player2, player1))
                player2score++;

            if (player1score == 2 || player2score == 2)
            {
                player1score = 0;
                player2score = 0;
                Load(1);
            }
                           
            foreach (Tile t in Tiles)
            {
                if (t.Rect.Intersects(player1.rect))
                {
                    player1.MoveBack();
                    break;
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Rect.Intersects(player2.rect))
                {
                    player2.MoveBack();
                    break;
                }
            }

            foreach (Tile t in Tiles)
            {
                for (int i = 0; i < player1.Bullets.Count; i++)
                {
                    if (player1.Bullets[i].rect.Intersects(t.Rect))
                    {
                        player1.Bullets.RemoveAt(i--);
                    }
                }             
            }

            foreach (Tile t in Tiles)
            {
                for (int i = 0; i < player2.Bullets.Count; i++)
                {
                    if (player2.Bullets[i].rect.Intersects(t.Rect))
                    {
                        player2.Bullets.RemoveAt(i--);
                    }
                }

            }

        }

        private bool CheckBullets(Player attacker, Player other)
        {
            for (int i = 0; i < attacker.Bullets.Count; i++)
            {
                if (attacker.Bullets[i].rect.Intersects(other.rect))
                {
                    attacker.Bullets.RemoveAt(i--);
                    other.Die(attacker, other);
                    return true;
                    //score++;
                }

            }

            return false;
        }

        public void Load(int level)
        {
            if (!File.Exists(GetLevelFile(level)))
                level = 1;

            backgroundImage = null;

            CurrentLevel = level;

            Unload();

            int y = 0;
            bool first = true;
            foreach (string line in File.ReadLines(GetLevelFile(level)))
            {
                if (first)
                {
                    backgroundImage = content.Load<Texture2D>(line);
                    first = false;
                    continue;
                }

                for (int i = 0; i < line.Length; i++)
                {
                    if (Textures.ContainsKey(line[i]))
                        Tiles.Add(new Tile(Textures[line[i]], i * 25, y));
                }

                y += 25;
            }

            if (level == 1 && mainMenu != null)
                mainMenu.Load(content, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (backgroundImage != null)
                spriteBatch.Draw(backgroundImage, rect, Color.White);

            foreach (Tile t in Tiles)
                t.Draw(spriteBatch);

            DrawText(spriteBatch);
        }
    }
}
