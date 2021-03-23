namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using UnityEngine;

	public class FlagResourceToSector : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private SectorRessourceType _type = SectorRessourceType.Food;
		#endregion Fields

		#region Properties
		public SectorRessourceType Type { get => _type; set => _type = value; }
		#endregion Properties

		#region Methods
		private void OnDrawGizmos()
		{
			_type.DrawIcon(transform.position);
		}
		#endregion Methods
	}
}
