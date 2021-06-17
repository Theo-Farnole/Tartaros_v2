namespace Tartaros.Wave
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	[System.Serializable]
	public class WavesSpawnerData : SerializedScriptableObject
	{
		[SerializeField] private WaveData[] _waves;
		[SerializeField] private float _secondsBetweenWaves = 0;
		[SerializeField] private bool _playWaveAtStart = false;

		public WaveData[] Waves => _waves;
		public int LastWaveIndex => _waves.Length - 1;
		public float SecondsBetweenWaves => _secondsBetweenWaves;
		public bool PlayWaveAtStart => _playWaveAtStart;
	}
}