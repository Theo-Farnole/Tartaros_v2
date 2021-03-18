namespace Tartaros.Utilities
{
	using UnityEngine;

	[System.Serializable]
	public struct Bounds1D
	{
		#region Fields
		[SerializeField]
		public float min;

		[SerializeField]
		public float max;
		#endregion Fields

		#region Properties
		public Bounds1D(float min, float max)
		{
			this.min = min;
			this.max = max;
		} 
		#endregion Properties
	}
}