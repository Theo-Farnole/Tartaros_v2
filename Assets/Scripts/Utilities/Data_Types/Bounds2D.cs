namespace Tartaros
{
	using UnityEngine;

	[System.Serializable]
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
		public float Width => boundsX.Size;
		public float Height => boundsY.Size;
		public float CenterX => boundsX.Center;
		public float CenterY => boundsY.Center;
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

		public void DrawGizmos()
		{
			Vector3 center = new Vector3(CenterX, 0, CenterY);
			Vector3 size = new Vector3(Width, 0, Height);

			Gizmos.DrawWireCube(center, size);
		}
		#endregion Ctor
	}

}