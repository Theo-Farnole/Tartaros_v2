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
	public class CaptureBuilding : SerializedMonoBehaviour
	{
		[SerializeField] private EntityData _constructableEntity = null;
		[SerializeField] private bool _isTemple = false;
		[SerializeField] [ShowIf(nameof(_isTemple))] private Transform[] _spawnPointsForVillagers = null;

		private IConstructable _constructable = null;
		private bool _isAvailable = true;

		public bool IsAvailable => _isAvailable;
		public IConstructable Constructable { get => _constructable; set => _constructable = value; }

		private void Awake()
		{

			if (_constructableEntity != null && _constructable == null)
			{
				_constructable = _constructableEntity.GetBehaviour<IConstructable>();
			}
		}

		public bool CanCapture()
		{
			if (_constructable == null) throw new System.NotSupportedException("Missing constructable in inspector.");

			return _isAvailable == true;
		}

		public void Capture()
		{
			if (_constructable == null) throw new System.NotSupportedException("Missing constructable in inspector.");

			if (CanCapture() == true)
			{
				InstanciateGameplayModel();
				_isAvailable = false;
				Destroy(this.gameObject);
			}
			else
			{
				Debug.LogError("Cannot construct.", this);
			}
		}

		private void InstanciateGameplayModel()
		{
			GameObject captureGameplay = GameObject.Instantiate(_constructable.GameplayPrefab, transform.position, transform.rotation);

			if(_isTemple == true && _spawnPointsForVillagers != null) 
			{
				captureGameplay.GetComponent<VillagerSpawnerManager>().SetSpawnPoint(_spawnPointsForVillagers);
			}
		}
	}
}