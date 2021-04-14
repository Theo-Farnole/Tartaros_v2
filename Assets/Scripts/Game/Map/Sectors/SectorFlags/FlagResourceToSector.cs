namespace Tartaros.Map
{
	using Tartaros.Economy;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject))]
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
		private void Awake()
		{
			gameObject.GetOrAddComponent<SectorObject>();
		}

		private void OnDrawGizmos()
		{
			_type.DrawIcon(transform.position);
		}
		#endregion Methods
	}
}
