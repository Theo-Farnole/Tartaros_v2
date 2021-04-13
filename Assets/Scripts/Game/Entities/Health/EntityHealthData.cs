namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Entities;
	using System;
	using Tartaros.Entities.Health;

	public class EntityHealthData : IEntityBehaviourData
	{

		#region Fields
		[SerializeField]
		private int _health = 0;
		[SerializeField]
		private float _healthPointsRegenerationPerSeconds = 0;
		[SerializeField]
		private float _regenerationDelayWithoutTakingDamage = 0;

		public EntityHealthData(int health, float healthPointsRegenerationPerSeconds, float regenerationDelayWithoutTakingDamage)
		{
			_health = health;
			_healthPointsRegenerationPerSeconds = healthPointsRegenerationPerSeconds;
			_regenerationDelayWithoutTakingDamage = regenerationDelayWithoutTakingDamage;
		}

		public int Health => _health;
		public float HealthPointsRegenerationPerSeconds => _healthPointsRegenerationPerSeconds;
		public float RegenerationDelayWithoutTakingDamage => _regenerationDelayWithoutTakingDamage;
		#endregion



		#region Methods
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			var entityHealth = entityRoot.GetOrAddComponent<EntityHealth>();
			entityHealth.EntityHealthData = this;
		}


		#endregion
	}

}