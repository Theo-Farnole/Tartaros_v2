namespace Tartaros.Entities
{
	using Tartaros.Entities.Health;
	using UnityEngine;

	public class EntityHealthData : IEntityBehaviourData
	{

		#region Fields
		[SerializeField]
		private int _health = 0;
		[SerializeField]
		private float _healthPointsRegenerationPerSeconds = 0;
		[SerializeField]
		private float _regenerationDelayWithoutTakingDamage = 0;
		[SerializeField]
		private float _sizeRadius = 1;

		public EntityHealthData(int health, float healthPointsRegenerationPerSeconds, float regenerationDelayWithoutTakingDamage, float sizeRadius)
		{
			_health = health;
			_healthPointsRegenerationPerSeconds = healthPointsRegenerationPerSeconds;
			_regenerationDelayWithoutTakingDamage = regenerationDelayWithoutTakingDamage;
			_sizeRadius = sizeRadius;
		}

		public int Health => _health;
		public float HealthPointsRegenerationPerSeconds => _healthPointsRegenerationPerSeconds;
		public float RegenerationDelayWithoutTakingDamage => _regenerationDelayWithoutTakingDamage;
		public float SizeRadius => _sizeRadius;
		#endregion

		#region Methods
#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.GetOrAddComponent<EntityHealth>();			
		} 
#endif
		#endregion
	}

}