namespace Tartaros.Economy
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	[System.Serializable]
	public class PlayerSectorResourcesData : SerializedScriptableObject
	{
		[SerializeField]
		private ISectorResourcesWallet _startingWallet = null;

		public PlayerSectorResourcesData(ISectorResourcesWallet wallet)
		{
			_startingWallet = wallet;
		}

		public ISectorResourcesWallet StartingIncome => _startingWallet;
	}
}