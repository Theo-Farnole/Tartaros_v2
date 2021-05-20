namespace Tartaros.UI.Sectors.Orders
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using UnityEngine;

	public class SectorStylesDatabase : ScriptableObject
	{
		#region Fields
		[SerializeField, SuffixLabel("icon is set automacally")] private SectorStyle _sectorResource = null;
		[SerializeField] private SectorStyle _village = null;
		[SerializeField] private SectorStyle _hephaistos = null;
		[SerializeField] private SectorStyle _poseidon = null;
		[SerializeField] private SectorStyle _defaultSector = null;
		#endregion Fields

		#region Properties
		public SectorStyle Village => new SectorStyle(_village);
		public SectorStyle Hephaistos => new SectorStyle(_hephaistos);
		public SectorStyle Poseidon => new SectorStyle(_poseidon);
		public SectorStyle DefaultSector => new SectorStyle(_defaultSector);
		#endregion Properties

		#region Methods
		public SectorStyle GetResourceStyle(SectorRessourceType resourceType)
		{
			SectorStyle output = new SectorStyle(_sectorResource); // make a copy to prevent modification on database
			output.Icon = resourceType.GetIcon();

			return output;
		}
		#endregion Methods
	}
}
