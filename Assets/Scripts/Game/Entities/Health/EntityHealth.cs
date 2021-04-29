namespace Tartaros.Entities.Health
{
	using Sirenix.OdinInspector;
	using System;
	using UnityEngine;

	[DisallowMultipleComponent]
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
				_currentHealth = Mathf.Clamp(value, 0, MaxHealth);

				HealthChanged?.Invoke(this, new HealthChangedArgs());
			}
		}

		int IHealthable.CurrentHealth => Mathf.RoundToInt(_currentHealth);

		int IHealthable.MaxHealth => MaxHealth;

		float IAttackable.SizeRadius => _entityHealthData.SizeRadius;
		#endregion Properties

		#region Events
		public class HealArgs : EventArgs { }
		public event EventHandler<HealArgs> Heal = null;

		public class DamageTakenArgs : EventArgs { }
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

		[Button]
		[ShowInRuntime]
		void IAttackable.TakeDamage(int damage)
		{
			CurrentHealth -= damage;

			DamageTaken?.Invoke(this, new DamageTakenArgs());

			if (IsDead)
			{
				Death?.Invoke(this, new DeathArgs());
				GetComponent<Entity>().Kill();
			}
		}

		void IHealthable.Heal(int amount)
		{
			CurrentHealth += amount;

			Heal?.Invoke(this, new HealArgs());
		}
		#endregion
	}

}