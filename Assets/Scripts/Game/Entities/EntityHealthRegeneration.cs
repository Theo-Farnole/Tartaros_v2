namespace Tartaros.Entities.Health
{
	using System.Collections;
	using UnityEngine;

	public class EntityHealthRegeneration : MonoBehaviour
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
			if (_entityHealth.IsAlive)
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
			_entityHealth.CurrentHealth += _entityHealthData.HealthPointsRegenerationPerSeconds;
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
