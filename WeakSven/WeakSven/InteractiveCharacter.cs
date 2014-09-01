namespace WeakSven
{
	class InteractiveCharacter : Character
	{
		public int Health { get; protected set; }
		public int Attack { get; protected set; }


		public InteractiveCharacter()
			: base()
		{
            Health = 100;
            Attack = 100;
		}
	}
}