using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using XNA_GUI;

namespace WeakSven
{
    public class MainMenu : Menu
    {

		//public AudioBGM level1 = new AudioBGM();
		//public AudioSFX level2 = new AudioSFX();
		//public AudioSFX level3 = new AudioSFX();
		//public AudioSFX level4 = new AudioSFX();
		//public AudioSFX level5 = new AudioSFX();
		
        public MainMenu() { }

        public override void Load(ContentManager Content)
        {			
            base.Load(Content);

			

			//level1.Music = Content.Load<Song>("Music/StageSelect");
			//level2.Sound = Content.Load<SoundEffect>("Music/Castle");
			//level3.Sound = Content.Load<SoundEffect>("Music/Battle");
			//level4.Sound = Content.Load<SoundEffect>("Music/Brawl");
			//level5.Sound = Content.Load<SoundEffect>("Music/Fight");

	
        }

        public void Load(ContentManager Content, Level level)
        {
			Song stageSelect = Content.Load<Song>("Music/StageSelect");
			Song Castle = Content.Load<Song>("Music/Castle");
			Song Battle = Content.Load<Song>("Music/Battle");
			Song Brawl = Content.Load<Song>("Music/Brawl");
			Song Fight = Content.Load<Song>("Music/Fight");


            ImageButton b1 = new ImageButton(new Rectangle(75,25, 300, 200));
            b1.Load(Content, "Level_Images/Level1Image");
            b1.onClick += delegate(Component sender)
            {
                // Go to level i + 1
				MediaPlayer.Play(Castle);
                level.Load(2);
				Unload();
				
				
            };
            components.Add(b1);

            ImageButton b2 = new ImageButton(new Rectangle(425, 25, 300, 200));
            b2.Load(Content, "Level_Images/Level2Image");
            b2.onClick += delegate(Component sender)
            {
                // Go to level i + 1
				MediaPlayer.Play(Battle);
                level.Load(3);
                Unload();
            };
            components.Add(b2);

            ImageButton b3 = new ImageButton(new Rectangle(75, 250, 300, 200));
            b3.Load(Content, "Level_Images/Level3Image");
            b3.onClick += delegate(Component sender)
            {
                // Go to level i + 1
				MediaPlayer.Play(Brawl);
                level.Load(4);
                Unload();
            };
            components.Add(b3);

            ImageButton b4 = new ImageButton(new Rectangle(425, 250, 300, 200));
            b4.Load(Content, "Level_Images/Level4Image");
            b4.onClick += delegate(Component sender)
            {
                // Go to level i + 1
				MediaPlayer.Play(Fight);
                level.Load(5);
                Unload();
            };
            components.Add(b4);


        }
    }
}
