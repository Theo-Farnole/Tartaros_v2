namespace Tartaros.Entities.Health
{
	using System.Collections;
	using UnityEngine;

	public class EntityHealthRegeneration : AEntityBehaviour
	{
		#region Fields
		private Coroutine _healthRegenerationCoroutine = null;

		private EntityHealthData _entityHealthData = null;
		private EntityHealth _entityHealth = null;
		#endregion Fields

		#region Properties
		public EntityHealthData EntityHealthData { get => _entityHealthData; set => _entityHealthData = value; }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_entityHealth = GetComponent<EntityHealth>();
			_entityHealthData = Entity.GetBehaviourData<EntityHealthData>();
		}

		private void OnEnable()
		{
			_entityHealth.DamageTaken -= DamageTaken;
			_entityHealth.DamageTaken += DamageTaken;
		}

		private void OnDisable()
		{
			_entityHealth.DamageTaken -= DamageTaken;
		}

		private void DamageTaken(object sender, EntityHealth.DamageTakenArgs e)
		{
			if (_entityHealth.IsAlive && Entity.Team == Team.Player && Entity.EntityType == EntityType.Unit)
			{
				StartRegenerationCoroutine();
			}
		}

		private void StartRegenerationCoroutine()
		{
			if (_healthRegenerationCoroutine != null)
			{
				StopCoroutine(_healthRegenerationCoroutine);
			}

			_healthRegenerationCoroutine = StartCoroutine(RegenerationCoroutine());
		}

		void RegenerateHealth()
		{
			_entityHealth.CurrentHealth += _entityHealthData.HealthPointsRegenerationPerSeconds * Time.deltaTime;
		}

		IEnumerator RegenerationCoroutine()
		{
			yield return new WaitForSeconds(_entityHealthData.RegenerationDelayWithoutTakingDamage);

			while (true)
			{
				RegenerateHealth();

				if (_entityHealth.IsFullHealth == true)
				{
					break;
				}

				yield return new WaitForEndOfFrame();
			}
		}
		#endregion Methods
	}
}
