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
		#endregion Fields

		#region Properties
		public SectorStyle Village => _village;
		public SectorStyle Hephaistos => _hephaistos;
		public SectorStyle Poseidon => _poseidon;
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
