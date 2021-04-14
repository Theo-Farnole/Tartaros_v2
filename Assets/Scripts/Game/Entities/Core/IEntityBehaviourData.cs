namespace Tartaros.Entities
{
	using UnityEngine;

	public interface IEntityBehaviourData
	{
#if UNITY_EDITOR
		void SpawnRequiredComponents(GameObject entityRoot); 
#endif // UNITY_EDITOR
	}
}