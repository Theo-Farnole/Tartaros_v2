namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections.Generic;
	using Tartaros.Map;
	using Tartaros.OrderGiver;
	using Tartaros.Orders;
	using Tartaros.Wave;
	using UnityEngine;
	using UnityEngine.UI;

	[SelectionBase]
	[RequireComponent(typeof(SectorObject))]
	[DisallowMultipleComponent]
	public partial class Entity : MonoBehaviour, ITeamable, IOrderStopReceiver, IWaveSpawnable, IOrderable
	{
		#region Fields
		[SerializeField]
		private EntityData _entityData = null;

		[SerializeField]
		private Team _team = Team.Player;

		[SerializeField]
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
		private void Awake()
		{
			gameObject.GetOrAddComponent<SectorObject>();
		}

		private void Start()
		{
			AnyEntitySpawned?.Invoke(this, new EntitySpawnedArgs(this));
			_entityFSM = GetComponent<EntityFSM>();
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

		

		public T GetBehaviourData<T>() where T : class
		{
			return _entityData.GetBehaviour<T>();
		}

		#region Interfaces
		void IOrderStopReceiver.Stop()
		{
			_entityFSM.Stop();
		}

		void IWaveSpawnable.Attack(IAttackable attackable)
		{
			//GetComponent<IOrderAttackReceiver>().Attack(attackable);

			var position = attackable.Transform.position;
			_entityFSM.SetStateGoalPattern(position);


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