namespace Tartaros.Math
{
	using UnityEngine;

	public class Bounds3D
	{
		#region Fields
		[SerializeField]
		public Bounds1D boundsX;

		[SerializeField]
		public Bounds1D boundsY;

		[SerializeField]
		public Bounds1D boundsZ;
		#endregion Fields

		#region Properties
		public float MinX => boundsX.min;
		public float MaxX => boundsX.max;
		public float MinY => boundsY.min;
		public float MaxY => boundsY.max;
		public float MinZ => boundsZ.min;
		public float MaxZ => boundsZ.max;
		#endregion Properties
	}
}
