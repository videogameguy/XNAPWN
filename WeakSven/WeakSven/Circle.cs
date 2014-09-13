using Microsoft.Xna.Framework;

namespace WeakSven
{
	public class Circle
	{
		public Vector2 center = Vector2.Zero;
		public float radius = 0.0f;

		public Circle() { }
		public Circle(int x, int y, float rad)
		{
			center = new Vector2(x, y);
			radius = rad;
		}

		public Circle(Vector2 xy, float radius)
		{
			center = xy;
			this.radius = radius;
		}

		public bool Contains(int x, int y)
		{
			Vector2 other = new Vector2(x, y);

			if ((other - center).Length() < radius)
				return true;

			return false;
		}

		public bool Intersects(Circle other)
		{
			float maxRadius = other.radius > radius ? other.radius : radius;

			if ((other.center - center).Length() <= radius)
				return true;

			return false;
		}
	}
}