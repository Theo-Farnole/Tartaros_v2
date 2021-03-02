namespace Tartaros.Utilities
{
	using UnityEngine;

	[System.Serializable]
	public struct Bounds
	{
		#region Fields
		[SerializeField]
		public int min;

		[SerializeField]
		public int max;
		#endregion Fields

		#region Properties
		public Bounds(int min, int max)
		{
			this.min = min;
			this.max = max;
		} 
		#endregion Properties
	}
}