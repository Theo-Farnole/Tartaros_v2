namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using System;
	using System.Linq;
	using Tartaros.OrderGiver;
	using Tartaros.Orders;
	using Tartaros.Wave;
	using UnityEngine;
	using UnityEngine.UI;

	public partial class Entity : MonoBehaviour, ITeamable, IOrderStopReceiver, IWaveSpawnable
	{
		#region Fields
		[SerializeField]
		private EntityData _entityData = null;

		[SerializeField]
		private Team _team = Team.Player;

		private EntityType _entityType = EntityType.Unit;

		private EntityFSM _entityFSM = null;
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

		event EventHandler<KilledArgs> EntityKilled = null;
		event EventHandler<KilledArgs> IWaveSpawnable.Killed { add => EntityKilled += value; remove => EntityKilled -= value; }
		#endregion Events

		#region Methods
		private void Start()
		{
			AnyEntitySpawned?.Invoke(this, new EntitySpawnedArgs(this));
		}

		private void OnDestroy()
		{
			EntityKilled?.Invoke(this, new KilledArgs());
			AnyEntityKilled?.Invoke(this, new EntityKilledArgs(this));
		}

		public void Kill()
		{
			Destroy(gameObject);
		}

		public void Initialize(Team team, EntityType entityType)
		{
			_team = team;
			_entityType = entityType;
		}

		public Order[] GenerateAvailablesOrders()
		{
			return GetComponents<IEntityOrderable>()
				.Where(x => (x as MonoBehaviour).enabled == true)
				.SelectMany(x => x.GenerateOrders(this))
				.ToArray();
		}

		public T GetBehaviourData<T>() where T : class
		{
			return _entityData.GetBehaviour<T>();
		}

		#region IOrders
		void IOrderStopReceiver.Stop()
		{
			_entityFSM.Stop();
		}

		void IWaveSpawnable.Attack(IAttackable attackable)
		{
			GetComponent<IOrderAttackReceiver>().Attack(attackable);
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