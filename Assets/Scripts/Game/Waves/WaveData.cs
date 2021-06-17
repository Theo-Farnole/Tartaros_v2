namespace Tartaros.Wave
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	public class WaveData
	{
		#region Fields
		[SerializeField] private Dictionary<SpawnPointIdentifier, UnitSequence[]> _sequencesBySpawnPoint;
		[SerializeField] private bool _launchDialogueWhenWaveOver = false;
		[SerializeField, ShowIf(nameof(_launchDialogueWhenWaveOver))] private string _dialogue_ID = "default";		
		#endregion Fields


		#region Properties
		public bool LaunchDialogueWhenWaveOver => _launchDialogueWhenWaveOver;
		public string DialogueID => _dialogue_ID; 
		#endregion Properties


		#region Methods
		public UnitSequence[] GetUnitSequences(SpawnPointIdentifier identifier)
		{
			return _sequencesBySpawnPoint[identifier];
		}

		public SpawnPointIdentifier[] GetSpawnPointActiveInTheWave()
		{
			return _sequencesBySpawnPoint.Keys.ToArray();
		}

		public int GetSpawnedEntitiesCount()
		{
			int countOfSpawnedEntities = 0;
			foreach (KeyValuePair<SpawnPointIdentifier, UnitSequence[]> kvp in _sequencesBySpawnPoint)
			{
				for (int i = 0; i < kvp.Value.Length; i++)
				{
					countOfSpawnedEntities += kvp.Value[i].EntitiesCount;
				}
			}
			return countOfSpawnedEntities;

			//return _sequencesBySpawnPoint
			//    .Select(x => x.Value)
			//    .SelectMany(x => x)
			//    .Sum(x => x.EntitiesCount);
		}

		public bool DoSpawnPointsIsMissingInScene(ISpawnPoint[] inSceneSpawnPoints)
		{
			SpawnPointIdentifier[] array = inSceneSpawnPoints.Select(x => x.Identifier).ToArray();

			foreach (var sequence in _sequencesBySpawnPoint)
			{
				if (Array.Exists(array, x => x == sequence.Key) == false)
				{
					return true;
				}
			}

			return false;
		} 
		#endregion Methods
	}
}