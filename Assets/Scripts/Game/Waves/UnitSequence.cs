namespace Tartaros.Wave
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	[System.Serializable]
	public class UnitSequence
	{
		[SerializeField]
		[ChildGameObjectsOnly]
		private GameObject _prefabToSpawn = null;
		[SerializeField]
		private int _entitiesCount = 30;
		[SerializeField]
		private float _secondsBetweenUnits = 0.5f;
		[SerializeField]
		private float _secondsBeforeSpawn = 0;

		public GameObject PrefabToSpawn => _prefabToSpawn;
		public int EntitiesCount => _entitiesCount;
		public float SecondsBetweenUnits => _secondsBetweenUnits;
		public float SecondsBeforeSpawn => _secondsBeforeSpawn;

		public UnitSequence()
		{
#if UNITY_EDITOR
			_prefabToSpawn = Tartaros.Editor.AssetsDatabaseHelper.FindAsset<GameObject>("Entity.Satyr");
#endif
		}
	}
}