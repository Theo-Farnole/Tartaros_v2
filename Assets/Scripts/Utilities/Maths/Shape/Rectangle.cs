namespace Tartaros.Math
{
	using UnityEngine;

	public class Rectangle
	{
		#region Fields
		private Rect rect = default;
		#endregion Fields

		#region Properties
		public float X => rect.x;
		public float Y => rect.y;
		public float Width => rect.width;
		public float Height => rect.height;
		public Vector2 position => rect.position;
		public Vector2 size => rect.size;
		public float MinY => rect.yMin;
		public float MaxY => rect.yMax;
		public float MinX => rect.xMin;
		public float MaxX => rect.xMax;
		#endregion Properties

		#region Ctor
		public Rectangle(Vector2 position, Vector2 size)
		{
			rect = new Rect(position, size);
		}
		#endregion Ctor
	}
}
