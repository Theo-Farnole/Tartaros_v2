namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject))]
	public partial class BuildingSlot : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField] private ISectorResourcesWallet _constructionPrice = null;
		[SerializeField, SuffixLabel("get IConstructable from behaviour")] private EntityData _constructableEntity = null;
		[SerializeField] private bool _isAvailable = true;

		private IConstructable _constructable = null;
		private IPlayerSectorResources _playerWallet = null;
		private Entity _instanciateBuilding = null;
		private ISector _sector = null;

		#endregion Fields

		#region Properties
		public bool IsAvailable { get => _isAvailable; set => _isAvailable = value; }

		public ISector Sector { get => _sector; set => _sector = value; }
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

				
				StartCoroutine(SetInstanciateBuildingEntity(_constructable.TimeToConstruct + 0.5f));
			}
			else
			{
				Debug.LogError("Cannot construct.", this);
			}
		}

		private void _instanciateBuilding_EntityKilled(object sender, Wave.KilledArgs e)
		{
			_isAvailable = true;
			if (_instanciateBuilding != null)
			{
				_instanciateBuilding.EntityKilled -= _instanciateBuilding_EntityKilled;
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

		IEnumerator SetInstanciateBuildingEntity(float time)
		{
			yield return new WaitForSeconds(time + 1);

			Debug.Log(_constructable);
			_instanciateBuilding = _sector.GetConstructableInSector(_constructable);

			if(_instanciateBuilding != null)
			{
				_instanciateBuilding.EntityKilled += _instanciateBuilding_EntityKilled;
			}
		}
		#endregion Methods		
	}

#if UNITY_EDITOR
	public partial class BuildingSlot
	{
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
	}
#endif
}
