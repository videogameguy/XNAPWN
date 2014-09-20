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
        public List<Tile> Tiles { get; private set; }
        public Dictionary<char, Texture2D> Textures { get; private set; }

        public Rectangle rect = new Rectangle(25, 50, 750, 400);

        private Texture2D backgroundImage = null;

        public int CurrentLevel { get; private set; }

        public Level()
        {
            Tiles = new List<Tile>();
            Textures = new Dictionary<char, Texture2D>();
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
            Textures.Add('k', Content.Load<Texture2D>("Tiles/Ammo"));
        }

        private void Unload()
        {
            Tiles.Clear();
        }

        public void Next(ContentManager Content)
        {
            Load(CurrentLevel + 1, Content);
        }

        public string GetLevelFile(int level)
        {
            return "Content/Levels/Level" + level + ".txt";
        }

        public void Update(GameTime gameTime, Player player1, Player player2)
        {
            CheckBullets(player1, player2);
            CheckBullets(player2, player1);

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

        private void CheckBullets(Player attacker, Player other)
        {
            for (int i = 0; i < attacker.Bullets.Count; i++)
            {
                if (attacker.Bullets[i].rect.Intersects(other.rect))
                {
                    attacker.Bullets.RemoveAt(i--);
                    other.Die(attacker, other);
                }

            }
        }



        public void Load(int level, ContentManager Content)
        {
            if (!File.Exists(GetLevelFile(level)))
                level = 1;

            CurrentLevel = level;

            Unload();

            int y = 0;
            bool first = true;
            foreach (string line in File.ReadLines(GetLevelFile(level)))
            {
                if (first)
                {
                    backgroundImage = Content.Load<Texture2D>(line);
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


        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundImage, rect, Color.White);
            foreach (Tile t in Tiles)
                t.Draw(spriteBatch);

        }
    }
}
