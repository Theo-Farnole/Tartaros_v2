namespace Tartaros.Entities
{
	using UnityEngine;

	[System.Serializable]
	public class AgentCollisionMovingData
	{
		[SerializeField] private float _growingTime = 2f;

		[SerializeField] private float _reducedRadius = 0.1f;
		[SerializeField] private float _reducingTime = 0.1f;

		public float GrowingTime => _growingTime;
		public float ReducedRadius => _reducedRadius;
		public float ReducingTime => _reducingTime;
	}
}
