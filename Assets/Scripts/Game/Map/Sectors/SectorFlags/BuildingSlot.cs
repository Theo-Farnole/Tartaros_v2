namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject))]
	public class BuildingSlot : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField] private ISectorResourcesWallet _constructionPrice = null;
		[SerializeField, SuffixLabel("get IConstructable from behaviour")] private EntityData _constructableEntity = null;

		private IConstructable _constructable = null;
		private bool _isAvailable = true;
		private IPlayerSectorResources _playerWallet = null;
		#endregion Fields

		#region Properties
		public bool IsAvailable => _isAvailable;
		public ISectorResourcesWallet ConstructionPrice => _constructionPrice;

		public IConstructable Constructable { get => _constructable; set => _constructable = value; }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_playerWallet = Services.Instance.Get<IPlayerSectorResources>();

			if (_constructableEntity != null && _constructable == null)
			{
				_constructable = _constructableEntity.GetBehaviour<IConstructable>();
			}
		}

		public bool CanConstruct()
		{
			if (_constructable == null) throw new System.NotSupportedException("Missing constructable in inspector.");

			return _isAvailable == true && _playerWallet.CanBuy(_constructionPrice);
		}

		public void Construct()
		{
			if (_constructable == null) throw new System.NotSupportedException("Missing constructable in inspector.");

			if (CanConstruct() == true)
			{
				_playerWallet.Buy(_constructionPrice);
				_constructable.InstantiateConstructionKit(transform.position, transform.rotation);
				_isAvailable = false;
			}
			else
			{
				Debug.LogError("Cannot construct.", this);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "gear-hammer.png");

			// TODO TF: clean
			var previewMeshFilter = GetPreviewMeshFilterInConstructableEntity();

			if (previewMeshFilter != null)
			{
				var previewMesh = previewMeshFilter.sharedMesh;

				Color yellow = Color.yellow;
				yellow.a = 0.5f;
				Gizmos.color = yellow;

				for (int i = 0; i < previewMesh.subMeshCount; i++)
				{

					Vector3 position = transform.position + previewMesh.bounds.center;
					position.y = transform.position.y;
					Gizmos.DrawMesh(previewMesh, 0, position, transform.rotation);
				}

				UnityEditor.Handles.Label(transform.position + Vector3.right, "preview");
			}
		}

		private MeshFilter GetPreviewMeshFilterInConstructableEntity()
		{
			if (_constructableEntity == null) return null;

			if (_constructableEntity.TryGetBehaviour(out IConstructable constructable) == true)
			{
				if (constructable.PreviewPrefab == null) return null;

				return constructable.PreviewPrefab.GetComponentInChildren<MeshFilter>();
			}
			else
			{
				return null;
			}
		}
		#endregion Methods
	}
}
