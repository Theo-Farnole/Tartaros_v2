namespace Tartaros.FogOfWar
{
	using UnityEngine;

	public class FogOfWarData : ScriptableObject
	{
		#region Fields
		[SerializeField]
		private float _sizePerCell = 0.5f;
		#endregion Fields

		#region Properties
		public float SizePerCell => _sizePerCell;
		#endregion Properties
	}
}
