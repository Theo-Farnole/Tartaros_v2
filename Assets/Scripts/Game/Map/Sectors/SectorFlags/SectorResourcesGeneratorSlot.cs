namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using UnityEngine;

	public class SectorResourcesGeneratorSlot : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField] private ISectorResourcesWallet _constructionPrice = null;

		private bool _isAvailable = false;
		#endregion Fields

		#region Properties
		public bool IsAvailable => _isAvailable;
		public ISectorResourcesWallet ConstructionPrice => _constructionPrice;
		#endregion Properties

		#region Methods
		public void CanConstruct()
		{
			throw new System.NotImplementedException();
		}

		public void Construct()
		{
			throw new System.NotImplementedException();
		}
		#endregion Methods
	}
}
