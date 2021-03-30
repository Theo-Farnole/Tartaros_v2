namespace Tartaros.Wave
{
    using System.Collections;
	using System.Linq;
	using UnityEngine;
    public class UnitSequence
    {
        [SerializeField]
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