namespace Tartaros.Utilities
{
	using UnityEngine;

	public class Bounds2D
	{
		#region Fields
		[SerializeField]
		public Bounds boundsY;

		[SerializeField]
		public Bounds boundsX;
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
			boundsX = new Bounds(minX, maxX);
			boundsY = new Bounds(minY, maxY);
		}

		public Bounds2D(Bounds boundsX, Bounds boundsY)
		{
			this.boundsX = boundsX;
			this.boundsY = boundsY;
		}
		#endregion Ctor
	}

}