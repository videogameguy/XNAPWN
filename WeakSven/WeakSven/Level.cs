using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WeakSven
{
    class Level
    {
        public List<Tile> Tiles { get; private set; }
        public Dictionary<char, Texture2D> Textures { get; private set; }

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

        public void Next()
        {
            Load(CurrentLevel + 1);
        }

        public string GetLevelFile(int level)
        {
            return "Content/Levels/Level" + level + ".txt";
        }

        public void Load(int level)
        {
            if (!File.Exists(GetLevelFile(level)))
                level = 1;

            CurrentLevel = level;

            Unload();

            int y = 0;
            foreach (string line in File.ReadLines(GetLevelFile(level)))
            {
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
            foreach (Tile t in Tiles)
                t.Draw(spriteBatch);
        }
    }
}
