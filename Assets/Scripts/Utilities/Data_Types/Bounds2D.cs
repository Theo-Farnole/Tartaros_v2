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
		public int MinX { get => boundsX.min; set => boundsX.min = value; }
		public int MaxX { get => boundsX.max; set => boundsX.max = value; }

		public int MinY { get => boundsY.min; set => boundsY.min = value; }
		public int MaxY { get => boundsY.max; set => boundsY.max = value; }
		#endregion Properties

		#region Ctor
		public Bounds2D(int minX, int maxX, int minY, int maxY)
		{
			boundsX = new Bounds1D(minX, maxX);
			boundsY = new Bounds1D(minY, maxY);
		}

		public Bounds2D(Bounds1D boundsX, Bounds1D boundsY)
		{
			this.boundsX = boundsX;
			this.boundsY = boundsY;
		}
		#endregion Ctor
	}

}