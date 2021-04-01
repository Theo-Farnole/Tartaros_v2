namespace Tartaros.Entities
{
	using Tartaros.Economy;
	using UnityEngine;

	public class SpawnSettings
	{
		#region Fields
		[SerializeField]
		private ISectorResourcesWallet _spawnPrice = null;

		[SerializeField]
		private float _spawnTime = 1;
		#endregion Fields

		#region Properties
		public ISectorResourcesWallet SpawnPrice => _spawnPrice;
		public float SpawnTime => _spawnTime;
		#endregion Properties

		#region Ctor
		public SpawnSettings()
		{ }
		#endregion Ctor
	}
}
