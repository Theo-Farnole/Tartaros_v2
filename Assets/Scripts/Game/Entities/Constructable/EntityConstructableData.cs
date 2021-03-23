namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using UnityEngine;

	public class EntityConstructableData : IEntityBehaviourData, IConstructable
	{
		#region Fields

		[SerializeField]
		[PreviewField]
		private Sprite _portrait = null;

		[SerializeField]
		private GameObject _modelPrefab = null;
		[SerializeField]
		private bool _IsChained = false;

		[SerializeField]
		private ISectorResourcesWallet _constructionPrice = null;

		[SerializeField]
		private Vector2 _size = Vector2.one;

		[SerializeField]
		private IConstructionRule[] _rules = new IConstructionRule[0];
		#endregion Fields

		#region Properties
		GameObject IConstructable.ModelPrefab => _modelPrefab;

		ISectorResourcesWallet IConstructable.Price => _constructionPrice;

		Vector2 IConstructable.Size => _size;

		Sprite IPortraiteable.Portrait => _portrait;

		IConstructionRule[] IConstructable.Rules => _rules;
		#endregion Properties

        bool IConstructable.IsChained =>_IsChained;
        #endregion Properties

        #region Methods
        void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			// TODO TF: use carve mesh here
		}

		public override string ToString()
		{
			return _portrait != null ? _portrait.name : base.ToString();
		}
		#endregion Methods
	}
}
