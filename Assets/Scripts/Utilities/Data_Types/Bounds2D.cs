namespace Tartaros.Utilities
{
	using UnityEngine;

	public class Bounds2D
	{
		#region Fields
		[SerializeField]
		public Bounds1D boundsY;

		[SerializeField]
		public Bounds1D boundsX;
		#endregion Fields

		#region Properties
		public float MinX { get => boundsX.min; set => boundsX.min = value; }
		public float MaxX { get => boundsX.max; set => boundsX.max = value; }

		public float MinY { get => boundsY.min; set => boundsY.min = value; }
		public float MaxY { get => boundsY.max; set => boundsY.max = value; }
		public float Width => boundsX.max - boundsX.min;
		public float Height => boundsY.max - boundsY.min;
		#endregion Properties

		#region Ctor
		public Bounds2D(float minX, float maxX, float minY, float maxY)
		{
			boundsX = new Bounds1D(minX, maxX);
			boundsY = new Bounds1D(minY, maxY);
		}

		public Bounds2D(Bounds1D boundsX, Bounds1D boundsY)
		{
			this.boundsX = boundsX;
			this.boundsY = boundsY;
		}

		public bool CountainsPoint(Vector3 cursor, Bounds2D bounds)
		{
			float cursorX = cursor.x;
			float cursorY = cursor.y;

			return (cursorX >= bounds.boundsX.min
				&& cursorX <= bounds.boundsX.max
				&& cursorY >= bounds.boundsY.min
				&& cursorY <= bounds.boundsY.max);
		}
		#endregion Ctor
	}

}