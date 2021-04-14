namespace Tartaros.Entities
{
	using System.Collections;
	using Tartaros.Economy;
	using UnityEngine;

	public class EntityWallToGateData : IEntityBehaviourData
	{
		[SerializeField]
		private GameObject _gatePrefab = null;
		[SerializeField]
		private ISectorResourcesWallet _gatePrice = null;

		public GameObject GatePrefab => _gatePrefab;
		public ISectorResourcesWallet GatePrice => _gatePrice;

#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.GetOrAddComponent<EntityWallToGate>();
			entityRoot.GetOrAddComponent<NeigboorWallManager>();
		} 
#endif
	}
}