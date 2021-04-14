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
#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.GetOrAddComponent<EntityHealth>();			
		} 
#endif
		#endregion
	}

}