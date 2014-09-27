using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace WeakSven
{
	public class AudioBGM : Audio
	{
		public Song Music { get; set; }

		public string BGM()
		{
			return Music.Name;
		}
	}
}