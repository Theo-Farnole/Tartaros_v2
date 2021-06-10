namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections;
	using Tartaros.Map;
	using Tartaros.OrderGiver;
	using Tartaros.Orders;
	using Tartaros.SoundsSystem;
	using Tartaros.Wave;
	using UnityEngine;
	using UnityEngine.AI;
	using UnityEngine.UI;

	[SelectionBase]
	[RequireComponent(typeof(SectorObject))]
	[DisallowMultipleComponent]
	public partial class Entity : MonoBehaviour, ITeamable, IOrderStopReceiver, IWaveSpawnable, IOrderable
	{
		#region Fields
		[Title("Settings")]
		[SerializeField] private Team _team = Team.Player;
		[SerializeField] private EntityType _entityType = EntityType.Unit;

		[Title("References")]
		[SerializeField] private EntityData _entityData = null;
		[SerializeField] private AudioSourceList _deathSound = null;

		private EntityFSM _entityFSM = null;
		private bool _destroyWithKillMethod = false;
		private bool _applicationIsQuiting = false;
		private bool _isKilled = false;
		#endregion Fields

		#region Properties
		public EntityData EntityData => _entityData;
		public Team Team => _team;
		public EntityType EntityType => _entityType;
		Team ITeamable.Team => _team;
		#endregion Properties

		#region Events
		public class EntitySpawnedArgs : EventArgs
		{
			public readonly Entity entity = null;

			public EntitySpawnedArgs(Entity entity)
			{
				this.entity = entity;
			}
		}

		public static event EventHandler<EntitySpawnedArgs> AnyEntitySpawned = null;

		public class EntityKilledArgs : EventArgs
		{
			public readonly Entity entity = null;

			public EntityKilledArgs(Entity entity)
			{
				this.entity = entity;
			}
		}

		public static event EventHandler<EntityKilledArgs> AnyEntityKilled = null;

		public event EventHandler<KilledArgs> EntityKilled = null;
		event EventHandler<KilledArgs> IWaveSpawnable.Killed { add => EntityKilled += value; remove => EntityKilled -= value; }
		#endregion Events

		#region Methods
		private void Awake()
		{
			gameObject.GetOrAddComponent<SectorObject>();
			//NavMesh.pathfindingIterationsPerFrame = Mathf.Infinity;
		}

		private void Start()
		{
			AnyEntitySpawned?.Invoke(this, new EntitySpawnedArgs(this));
			_entityFSM = GetComponent<EntityFSM>();
		}

		private void OnDestroy()
		{
			if (_applicationIsQuiting == false && _destroyWithKillMethod == false)
			{
				Debug.LogErrorFormat("The entity {0} has been destroyed without calling Kill() method. You should call it instead of GameObject.Destroy method.", name);
			}
		}

		private void OnApplicationQuit()
		{
			_applicationIsQuiting = true;
		}

		public void Kill(bool playSound = true)
		{
			if (_isKilled == true)
			{
				Debug.LogWarning("Cannot call Kill if the entity is already dead.");
				return;
			}

			StartCoroutine(Kill_Coroutine());

			if (playSound == true && _deathSound != null)
			{
				_deathSound.PlayClipWithoutInstance();
			}

			_destroyWithKillMethod = true;
			_isKilled = true;
		}

		private IEnumerator Kill_Coroutine()
		{
			if (_isKilled == true) throw new NotSupportedException("Cannot start Kill_Coroutine if the entity is already dead.");

			EntityKilled?.Invoke(this, new KilledArgs());
			AnyEntityKilled?.Invoke(this, new EntityKilledArgs(this));

			yield return new WaitForEndOfFrame();

			Destroy(gameObject);
		}

		public void Initialize(Team team, EntityType entityType)
		{
			_team = team;
			_entityType = entityType;
		}



		public T GetBehaviourData<T>() where T : class
		{
			return _entityData.GetBehaviour<T>();
		}

		#region Interfaces
		void IOrderStopReceiver.Stop()
		{
			_entityFSM.Stop();
		}

		void IWaveSpawnable.Attack(IAttackable attackable, Vector3[] waypoints, NavMeshPath[] paths)
		{
			//GetComponent<IOrderAttackReceiver>().Attack(attackable);

			var position = attackable.Transform.position;
			_entityFSM.SetStateGoalPattern(position, attackable, waypoints, paths);


		}

		Order[] IOrderable.GenerateOrders()
		{
			return new Order[]
			{
				new SelfKillOrder(this)
			};
		}
		#endregion IOrders
		#endregion Methods
	}

#if UNITY_EDITOR
	public partial class Entity
	{
		[Button]
#pragma warning disable IDE0051 // Remove unused private members
		void GenerateRequiredComponents()
#pragma warning restore IDE0051 // Remove unused private members
		{
			gameObject.GetOrAddComponent<EntityFSM>();
			gameObject.GetOrAddComponent<Selection.Selectable>();
			gameObject.GetOrAddComponent<SectorObject>();

			if (_team == Team.Player)
			{
				Selection.InstantiateGameObjectOnSelection instantiateGameObjectOnSelection = gameObject.GetOrAddComponent<Selection.InstantiateGameObjectOnSelection>();
				TryConfigurePrefabOnSelection(instantiateGameObjectOnSelection);
			}

			if (_entityData != null)
			{
				_entityData.SpawnComponents(gameObject);
			}
		}

		private static void TryConfigurePrefabOnSelection(Selection.InstantiateGameObjectOnSelection instantiateGameObjectOnSelection)
		{
			if (instantiateGameObjectOnSelection.PrefabToInstantiateOnSelection == null)
			{
				instantiateGameObjectOnSelection.PrefabToInstantiateOnSelection = Tartaros.Editor.AssetsDatabaseHelper.FindAsset<GameObject>("SelectionCircle");
			}
		}
	}
#endif
}