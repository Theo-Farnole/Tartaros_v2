namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;
	
	public class EntityWaveEnemyData : IEntityBehaviourData
	{
		[SerializeField]
		private float _timeBeforeTargetFlee = 0;

		public float TimeBeforeTargetFlee => _timeBeforeTargetFlee;

#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			throw new System.NotImplementedException();
		}
#endif
	}
}
