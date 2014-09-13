using Microsoft.Xna.Framework;
namespace WeakSven
{
	public class InteractiveCharacter : Character
	{
		public int Health { get; protected set; }
		public int Attack { get; protected set; }


		public InteractiveCharacter()
			: base()
		{
            Health = 100;
            Attack = 100;
		}

        public InteractiveCharacter(Vector2 startPosition)
            : base(startPosition)
        {
            Health = 100;
            Attack = 100;
        }
	}
}