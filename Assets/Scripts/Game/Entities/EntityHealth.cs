namespace Tartaros.Entities.Health
{
	using System;
	using UnityEngine;

	public class EntityHealth : MonoBehaviour, IAttackable
	{
		#region Fields
		private float _currentHealth = 0;

		private Coroutine _healthRegenerationCoroutine = null;
		private EntityHealthData _entityHealthData = null;
		#endregion




		#region Properties
		Transform IAttackable.Transform => transform;
		public EntityHealthData EntityHealthData { get => _entityHealthData; set => _entityHealthData = value; }
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
			}
		}
		#endregion Properties




		#region Events
		public class DamageTakenArgs : EventArgs
		{

		}

		public event EventHandler<DamageTakenArgs> DamageTaken = null;
		#endregion

		#region Methods

		private void Awake()
		{
			_currentHealth = EntityHealthData.Health;
		}

		void IAttackable.TakeDamage(int damage)
		{
			CurrentHealth -= damage;

			DamageTaken?.Invoke(this, new DamageTakenArgs());

			if (IsDead)
			{
				GetComponent<Entity>().Kill();
			}
		}


		#endregion
	}

}