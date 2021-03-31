namespace Tartaros.Wave
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[System.Serializable]
	public class WavesSpawnerData : SerializedScriptableObject
	{
		[SerializeField]
		private WaveData[] _waves;
		[SerializeField]
		private float _secondsBetweenWaves = 0;

		public WaveData[] Waves => _waves;
		public float FinalWaveIndex => _waves.Length - 1;
		public float SecondsBetweenWaves => _secondsBetweenWaves;
	}
}