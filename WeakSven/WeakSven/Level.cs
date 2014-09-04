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
            Textures.Add('b', Content.Load<Texture2D>("Block"));
            Textures.Add('g', Content.Load<Texture2D>("Grass"));
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
            return "Content/Level" + level + ".txt";
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
                        Tile.Add(new Tile(Textures[line[i]], i * 25, y));
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
