namespace Tartaros.Entities.Health
{
	using System;
	using UnityEngine;

	public class EntityHealth : AEntityBehaviour, IAttackable, IHealthable
	{
		#region Fields
		[ShowInRuntime]
		private float _currentHealth = -1;

		private EntityHealthData _entityHealthData = null;
		#endregion

		#region Properties
		Transform IAttackable.Transform => transform;
		bool IAttackable.IsAlive => IsAlive;		
		public EntityHealthData EntityHealthData
		{
			get
			{
				if (_entityHealthData == null)
				{
					throw new MissingDataReference<EntityHealthData>(this);
				}

				return _entityHealthData;
			}

			set
			{
				_entityHealthData = value;
				_currentHealth = EntityHealthData.Health;
			}
		}
		public bool IsAlive => _currentHealth > 0;
		public bool IsDead => IsAlive == false;

		public int MaxHealth => EntityHealthData.Health;

		public bool IsFullHealth => CurrentHealth == MaxHealth;

		public float CurrentHealth
		{
			get => _currentHealth;

			set
			{
				bool doGetDamage = value < _currentHealth;

				_currentHealth = Mathf.Clamp(value, 0, MaxHealth);

				HealthChanged?.Invoke(this, new HealthChangedArgs());

				if (doGetDamage == true)
				{
					DamageTaken?.Invoke(this, new DamageTakenArgs());
				}

				if (IsDead)
				{
					Death?.Invoke(this, new DeathArgs());
					GetComponent<Entity>().Kill();
				}
			}
		}

		int IHealthable.CurrentHealth => Mathf.RoundToInt(_currentHealth);

		int IHealthable.MaxHealth => MaxHealth;
		#endregion Properties

		#region Events
		public class DamageTakenArgs : EventArgs
		{

		}

		public event EventHandler<DamageTakenArgs> DamageTaken = null;

		public class DeathArgs : EventArgs { }
		public EventHandler<DeathArgs> Death = null;

		event EventHandler<HealthChangedArgs> HealthChanged = null;
		event EventHandler<HealthChangedArgs> IHealthable.HealthChanged { add => HealthChanged += value; remove => HealthChanged -= value; }
		#endregion

		#region Methods
		void Awake()
		{
			EntityHealthData = Entity.GetBehaviourData<EntityHealthData>();
		}

		void IAttackable.TakeDamage(int damage)
		{
			CurrentHealth -= damage;
		}
		#endregion
	}

}