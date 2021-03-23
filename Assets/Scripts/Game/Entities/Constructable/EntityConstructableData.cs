namespace Tartaros.UI
{
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using UnityEngine;

	public class EntityConstructableData : IEntityBehaviourData, IConstructable
	{
		#region Fields
		[SerializeField]
		private GameObject _modelPrefab = null;

		[SerializeField]
		private ISectorResourcesWallet _constructionPrice = null;

		[SerializeField]
		private Vector2 _size = Vector2.one;

		[SerializeField]
		private Sprite _portrait = null;
		#endregion Fields

		#region Properties
		GameObject IConstructable.ModelPrefab => _modelPrefab;

		ISectorResourcesWallet IConstructable.Price => _constructionPrice;

		Vector2 IConstructable.Size => _size;

		Sprite IPortraiteable.Portrait => _portrait;
		#endregion Properties

		#region Methods
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			// TODO TF: use carve mesh here
		}
		#endregion Methods
	}
}
