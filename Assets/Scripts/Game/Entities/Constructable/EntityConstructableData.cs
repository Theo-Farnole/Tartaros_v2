namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;
	using UnityEngine.AI;

	[System.Serializable]
	public class EntityConstructableData : IEntityBehaviourData, IConstructable
	{
		#region Fields

		[SerializeField]
		[PreviewField]
		private Sprite _portrait = null;

		[SerializeField]
		private GameObject _modelPrefab = null;

		[SerializeField]
		private GameObject _gameplayPrefab = null;

		[SerializeField]
		[ShowIf(nameof(_IsChained))]
		private GameObject _wallCornerModel = null;

		[SerializeField]
		[ShowIf(nameof(_IsChained))]
		private GameObject _wallCornerGameplay = null;


		[SerializeField]
		private GameObject _constructionKitModel = null;

		[SerializeField]
		private HoverPopupDataSO _hoverPopupData = null;

		[SerializeField]
		private int _timeToConstruct = 1;


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
		GameObject IConstructable.PreviewPrefab => _modelPrefab;

		ISectorResourcesWallet IConstructable.Price => _constructionPrice;

		Vector2 IConstructable.Size => _size;

		Sprite IPortraiteable.Portrait => _portrait;

		IConstructionRule[] IConstructable.Rules => _rules;

		bool IConstructable.IsWall => _IsChained;

		GameObject IConstructable.GameplayPrefab => _gameplayPrefab;

		GameObject IConstructable.WallCornerModel => _wallCornerModel;

		GameObject IConstructable.WallCornerGameplay => _wallCornerGameplay;

		GameObject IConstructable.ConstructionKitModel => _constructionKitModel;

		int IConstructable.TimeToConstruct => _timeToConstruct;

		HoverPopupData IConstructable.HoverPopupData
		{
			get
			{
				return new HoverPopupData(_hoverPopupData.HoverPopupData)
				{
					SectorResourcesCost = _constructionPrice
				};
			}
		}
		#endregion Properties

		#region Methods
#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			var navMeshObstacle = entityRoot.GetOrAddComponent<NavMeshObstacle>();
			navMeshObstacle.carving = true;
			navMeshObstacle.size = new Vector3(_size.x, 1, _size.y);
		}
#endif

		public override string ToString()
		{
			return _portrait != null ? _portrait.name : base.ToString();
		}
		#endregion Methods
	}
}
