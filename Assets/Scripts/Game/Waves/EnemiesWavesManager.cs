namespace Tartaros.Wave
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections;
	using System.IO;
	using Tartaros.Entities;
	using Tartaros.Utilities;
	using UnityEngine;


	public partial class EnemiesWavesManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[InlineEditor]
		private WavesSpawnerData _waveSpawnerData = null;

		[ShowInRuntime]
		private WaveSpawnerFSM _waveFSM = null;
		private int _currentWaveIndex = 0;
		private ISpawnPoint[] _spawnPoints = null;
		private IWaveSpawnable[] _spawnedEnemies = null;
		private IAttackable _enemiesTarget = null;
		#endregion Fields

		#region Properties
		public WavesSpawnerData WaveSpawnerData => _waveSpawnerData;
		public ISpawnPoint[] SpawnPoints => _spawnPoints;
		public int CurrentWaveIndex => _currentWaveIndex;
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

		public event EventHandler<WaveSpawningStartArgs> WaveSpawnStart;
		public event EventHandler<WaveSpawningFinishedArgs> WaveSpawnFinished;
		// public event EventHandler<KilledArgs> Killed;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_spawnPoints = ObjectsFinder.FindObjectsOfInterface<ISpawnPoint>();
			_waveFSM = new WaveSpawnerFSM();
			//TODO: WaveFSM registerService & Call it
		}

		private void Start()
		{
			FindEnemiesTarget();
			WaveFSM.CurrentState = new WaveSpawningState(this);
		}

		private void Update()
		{
			_waveFSM.OnUpdate();
		}

		public bool IsThereWavesToSpawn()
		{
			return _currentWaveIndex < _waveSpawnerData.FinalWaveIndex;
		}

		public void StartNewWave()
		{
			if (IsThereWavesToSpawn() == true)
			{
				_currentWaveIndex++;
				_waveFSM.CurrentState = new WaveSpawningState(this);
			}
			else
			{
				Debug.Log("Trying to start a new wave while there is no waves to spawn.");
			}
		}

		public void InvokeWaveSpawn()
		{
			WaveSpawnStart?.Invoke(this, new WaveSpawningStartArgs());
		}

		public void InvokeWaveFinished()
		{
			WaveSpawnFinished?.Invoke(this, new WaveSpawningFinishedArgs());
		}

		private void FindEnemiesTarget()
		{
			WavesEnemiesTarget target = GameObject.FindObjectOfType<WavesEnemiesTarget>();

			if (target == null)
			{
				Debug.LogErrorFormat("A WavesEnemiesTarget is missing in the scene. Please add one in the scene.");
			}
			else
			{

				if (target.TryGetComponent(out IAttackable attackable))
				{
					_enemiesTarget = attackable;
				}
				else
				{
					Debug.LogErrorFormat("Missing a component IAttackable on {0}, the enemies target.", target);
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