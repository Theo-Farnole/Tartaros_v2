namespace Tartaros.Entities
{
	using UnityEngine;

	public interface IEntityBehaviourData
	{
		void SpawnRequiredComponents(GameObject entityRoot);
	}
}