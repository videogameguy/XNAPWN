using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace WeakSven
{
	public class AudioSFX : Audio
	{
		public SoundEffect Sound { get; set; }
		

		public bool FireAndForget()
		{
			return Sound.Play();
		}

		public bool Play(GameTime gameTime)
		{
			if (startTime == 0 ||
				gameTime.TotalGameTime.TotalSeconds - startTime >= Sound.Duration.TotalSeconds)
			{
				Sound.Play();
				startTime = gameTime.TotalGameTime.TotalSeconds;
				return true;
			}

			return false;
		}
		
	}
}