namespace Tartaros.Utilities
{
	using UnityEngine;

	[System.Serializable]
	public class BoundsXZ
	{
		#region Fields
		[SerializeField]
		public Bounds1D boundsX;

		[SerializeField]
		public Bounds1D boundsZ;
		#endregion Fields

		#region Properties
		public float MinX { get => boundsX.min; set => boundsX.min = value; }
		public float MaxX { get => boundsX.max; set => boundsX.max = value; }

		public float MinZ { get => boundsZ.min; set => boundsZ.min = value; }
		public float MaxZ { get => boundsZ.max; set => boundsZ.max = value; }
		public float Width => boundsX.Size;
		public float Depth => boundsZ.Size;
		public float CenterX => boundsX.Center;
		public float CenterZ => boundsZ.Center;
		#endregion Properties

		#region Ctor
		public BoundsXZ(float minX, float maxX, float minZ, float maxZ)
		{
			boundsX = new Bounds1D(minX, maxX);
			boundsZ = new Bounds1D(minZ, maxZ);
		}

		public BoundsXZ(Bounds1D boundsX, Bounds1D boundsZ)
		{
			this.boundsX = boundsX;
			this.boundsZ = boundsZ;
		}

		public bool CountainsPoint(Vector3 position, BoundsXZ bounds)
		{
			float cursorX = position.x;
			float cursorY = position.z;

			return (cursorX >= bounds.boundsX.min
				&& cursorX <= bounds.boundsX.max
				&& cursorY >= bounds.boundsZ.min
				&& cursorY <= bounds.boundsZ.max);
		}

		public void DrawGizmos()
		{
			Vector3 center = new Vector3(CenterX, 0, CenterZ);
			Vector3 size = new Vector3(Width, 0, Depth);

			Gizmos.DrawWireCube(center, size);
		}
		#endregion Ctor
	}

}