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
		public Vector2 Max => rect.max;
		public Vector2 Min => rect.min;
		public Vector2 TopLeft => new Vector2(MinX, MaxY);
		public Vector2 BottomRight => new Vector2(MaxX, MinY);
		#endregion Properties

		#region Ctor
		public Rectangle(Vector2 position, Vector2 size)
		{
			rect = new Rect(position, size);
		}
		#endregion Ctor
	}
}
