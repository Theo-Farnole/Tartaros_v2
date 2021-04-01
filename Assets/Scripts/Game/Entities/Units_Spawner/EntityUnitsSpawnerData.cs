namespace Tartaros.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
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
		public bool CanSpawn(ISpawnable gameObject)
		{
			IPlayerSectorResources playerSectorResources = Services.Instance.Get<IPlayerSectorResources>();

			return _unitsSpawnable.ContainsKey(gameObject) && playerSectorResources.CanBuyWallet(_unitsSpawnable[gameObject].SpawnPrice);
		}

		public ISectorResourcesWallet GetPriceToSpawn(ISpawnable gameObject)
		{
			if (CanSpawn(gameObject) == true)
			{
				return _unitsSpawnable[gameObject].SpawnPrice;
			}
			else
			{
				throw new NotSupportedException("Unit cannot spawn {0}.".Format(gameObject));
			}
		}

		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			var unitsSpawner = entityRoot.GetOrAddComponent<EntityUnitsSpawner>();
			unitsSpawner.Data = this;
		}
		#endregion Methods
	}
}
