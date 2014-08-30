
namespace WeakSven
{
	class Entity
	{
		// Every object should have a name
		public string Name { get; protected set; }

		public Entity()
		{
			Name = "Thing";
		}

		public Entity(string name)
		{
			Name = name;
		}
	}
}