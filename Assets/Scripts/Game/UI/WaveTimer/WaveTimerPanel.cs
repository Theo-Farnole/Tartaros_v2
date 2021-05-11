namespace Tartaros.UI
{
	using Tartaros.ServicesLocator;
	using Tartaros.Wave;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class WaveTimerPanel : MonoBehaviour
	{
		#region Fields
		[SerializeField] private TextMeshProUGUI _currentWaveLabel = null;
		[SerializeField] private Image _waveGaugeFill = null;

		private EnemiesWavesManager _enemiesWavesManager = null;
		#endregion Fields

		#region Methods
		void Awake()
		{
			_enemiesWavesManager = Services.Instance.Get<EnemiesWavesManager>();
		}

		private void Start()
		{
			UpdateCurrentWaveLabel();
		}

		private void Update()
		{
			UpdateGauge();
		}

		private void OnEnable()
		{
			_enemiesWavesManager.WaveSpawnFinished -= WaveSpawnFinished;
			_enemiesWavesManager.WaveSpawnFinished += WaveSpawnFinished;

			_enemiesWavesManager.WaveStartCooldown -= WaveStartCooldown;
			_enemiesWavesManager.WaveStartCooldown += WaveStartCooldown;
		}


		private void OnDisable()
		{
			_enemiesWavesManager.WaveStartCooldown -= WaveStartCooldown;
			_enemiesWavesManager.WaveSpawnFinished -= WaveSpawnFinished;
		}

		private void WaveSpawnFinished(object sender, EnemiesWavesManager.WaveSpawningFinishedArgs e)
		{
			UpdateCurrentWaveLabel();
		}


		private void WaveStartCooldown(object sender, EnemiesWavesManager.WaveStartCooldownArgs e)
		{
			UpdateCurrentWaveLabel();
		}

		private void UpdateCurrentWaveLabel()
		{
			_currentWaveLabel.text = "{0}/{1}".Format(_enemiesWavesManager.CurrentWaveIndex + 1, _enemiesWavesManager.LastWaveIndex + 1);
		}

		private void UpdateGauge()
		{
			if (_enemiesWavesManager.IsInWaveCooldown == true)
			{
				float secondsUntilWaveSpawn = _enemiesWavesManager.SecondsUntilWaveSpawn;
				float secondsBetweenWaves = _enemiesWavesManager.SecondsBetweenWaves;
				_waveGaugeFill.fillAmount = secondsUntilWaveSpawn / secondsBetweenWaves;
			}
			else
			{
				_waveGaugeFill.fillAmount = 0;
			}
		}
		#endregion Methods
	}
}
