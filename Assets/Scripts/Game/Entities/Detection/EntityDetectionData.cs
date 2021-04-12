namespace Tartaros.Entities.Detection
{
	using UnityEngine;

	public class EntityDetectionData : IEntityBehaviourData
	{
		[SerializeField]
		private float _detectionRange = 1;
		public float DetectionRange => _detectionRange;

		public EntityDetectionData(float detectionRange)
		{
			_detectionRange = detectionRange;
		}


		public void SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.AddComponent<EntityDetection>().EntityDetectionData = this;
		}
	}
}