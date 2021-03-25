namespace Tartaros.Math
{
	using UnityEngine;

	public class Circle : IShape
	{
		#region Fields
		public Vector2 position = Vector2.zero;
		public float radius = 1;
		#endregion Fields

		#region Ctor
		public Circle(Vector2 position, float radius)
		{
			this.position = position;
			this.radius = radius;
		}
		#endregion Ctor
	}
}
