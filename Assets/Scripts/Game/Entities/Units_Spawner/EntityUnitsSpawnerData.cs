namespace Tartaros.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Economy;
	using UnityEngine;

	public class EntityUnitsSpawnerData : IEntityBehaviourData
	{
		#region Fields
		[SerializeField]
		private Dictionary<ISpawnable, SpawnSettings> _unitsSpawnable = new Dictionary<ISpawnable, SpawnSettings>();
		#endregion Fields

		#region Properties
		public ISpawnable[] SpawnablePrefabs => _unitsSpawnable.Keys.ToArray();
		#endregion Properties

		#region Methods
		public ISectorResourcesWallet GetSpawnPrice(ISpawnable gameObject)
		{
			if (_unitsSpawnable.TryGetValue(gameObject, out SpawnSettings value))
			{
				return value.SpawnPrice;
			}
			else
			{
				throw new NotSupportedException("Unit cannot spawn {0}.".Format(gameObject));
			}
		}

#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.GetOrAddComponent<EntityUnitsSpawner>();
		} 
#endif
		#endregion Methods
	}
}
