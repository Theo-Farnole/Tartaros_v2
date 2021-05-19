namespace Tartaros.Wave
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections;
	using System.IO;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;

	using UnityEngine;


	public partial class EnemiesWavesManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[InlineEditor]
		private WavesSpawnerData _waveSpawnerData = null;

		[ShowInRuntime]
		private WaveSpawnerFSM _waveFSM = null;
		private int _currentWaveIndex = -1;
		private ISpawnPoint[] _spawnPoints = null;
		private IWaveSpawnable[] _spawnedEnemies = null;
		private IAttackable _enemiesTarget = null;
		#endregion Fields

		#region Properties
		public WavesSpawnerData WaveSpawnerData => _waveSpawnerData;
		public ISpawnPoint[] SpawnPoints => _spawnPoints;
		public int CurrentWaveIndex => _currentWaveIndex;
		public int LastWaveIndex => _waveSpawnerData.LastWaveIndex;
		public bool IsInWaveCooldown => _waveFSM.CurrentState is WaveCooldownState;
		public float PassedSecondsBeforeWave
		{
			get
			{
				if (_waveFSM.CurrentState is WaveCooldownState cooldownState)
				{
					return cooldownState.PassedSeconds;
				}
				else
				{
					throw new System.NotSupportedException("The system is not in wave cooldown. Please, ensure IsInWaveCooldown property equals true before getting this property.");
				}
			}
		}
		public float SecondsUntilWaveSpawn => SecondsBetweenWaves - PassedSecondsBeforeWave;
		public float SecondsBetweenWaves => _waveSpawnerData.SecondsBetweenWaves;
		public IWaveSpawnable[] SpawnedEnemies => _spawnedEnemies;
		public WaveSpawnerFSM WaveFSM => _waveFSM;
		public IAttackable EnemiesTarget => _enemiesTarget;
		#endregion Properties

		#region Events
		public class WaveSpawningStartArgs : EventArgs
		{

		}

		public class WaveSpawningFinishedArgs : EventArgs
		{

		}

		public class WaveStartCooldownArgs : EventArgs
		{

		}

		public class EveryWaveAreFinishedArgs : EventArgs
		{

		}


		public event EventHandler<WaveSpawningStartArgs> WaveSpawnStart;
		public event EventHandler<WaveSpawningFinishedArgs> WaveSpawnFinished;
		public event EventHandler<WaveStartCooldownArgs> WaveStartCooldown;
		public event EventHandler<EveryWaveAreFinishedArgs> WavesFinish;
		// public event EventHandler<KilledArgs> Killed;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_spawnPoints = ObjectsFinder.FindObjectsOfInterface<ISpawnPoint>();
			_waveFSM = new WaveSpawnerFSM();
		}

		private void Start()
		{
			FindEnemiesTarget();
			WaveFSM.CurrentState = new WaveCooldownState(this);
		}

		private void Update()
		{
			_waveFSM.OnUpdate();
		}

		public bool IsThereWavesToSpawn()
		{
			return _currentWaveIndex <= _waveSpawnerData.LastWaveIndex;
		}

		public void StartNewWave()
		{
			if (IsThereWavesToSpawn() == true)
			{				
				_waveFSM.CurrentState = new WaveSpawningState(this);
			}
			else
			{
				Debug.LogError("Trying to start a new wave while there is no waves to spawn.");
			}
		}

		public void InvokeWaveSpawn()
		{
			WaveSpawnStart?.Invoke(this, new WaveSpawningStartArgs());
		}

		public void InvokeWaveStartCooldown()
		{
			_currentWaveIndex++;
			WaveStartCooldown?.Invoke(this, new WaveStartCooldownArgs());
		}

		public void InvokeSpawningWaveFinished()
		{
			WaveSpawnFinished?.Invoke(this, new WaveSpawningFinishedArgs());
		}

		public void InvokeWavesFinished()
		{
			WavesFinish?.Invoke(this, new EveryWaveAreFinishedArgs());
		}

		private void FindEnemiesTarget()
		{
			WavesEnemiesTarget target = GameObject.FindObjectOfType<WavesEnemiesTarget>();

			if (target == null)
			{
				Debug.LogError("A WavesEnemiesTarget is missing in the scene. Please add one in the scene.");
			}
			else
			{

				if (target.TryGetComponent(out IAttackable attackable))
				{
					_enemiesTarget = attackable;
				}
				else
				{
					Debug.LogError("Missing a component IAttackable on the enemies target \"{0}\".".Format(target), target);
				}
			}
		}
		#endregion Methods
	}

#if UNITY_EDITOR
	public partial class EnemiesWavesManager
	{
		private const string path = "Assets/Databases/Waves/";

		[ShowIf("@_waveSpawnerData == null")]
		[Button]
		public void CreateWaveSpawnerData()
		{
			var waveData = ScriptableObject.CreateInstance<WavesSpawnerData>();

			string filename = "WaveData-{0}.asset".Format(gameObject.scene.name);
			string filePath = path + filename;


			string dataPath = Application.dataPath;
			string dataPathWithoutAsset = dataPath.Remove(dataPath.Length - "Assets".Length);
			Debug.Log(dataPathWithoutAsset + path);

			Directory.CreateDirectory(dataPathWithoutAsset + path);

			UnityEditor.AssetDatabase.CreateAsset(waveData, filePath);

			UnityEditor.AssetDatabase.SaveAssets();

			_waveSpawnerData = waveData;

			Debug.LogFormat("Creating wave data at path {0}.", filePath);
		}
	}
#endif
}