namespace Tartaros.Economy
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[System.Serializable]
	public class PlayerIncomeManagerData : SerializedScriptableObject
	{
		#region Fields
		[SerializeField]
		private ISectorResourcesWallet _startingIncome = null;

		[SerializeField]
		private float _tickInvervalInSeconds = 10;
		#endregion Fields

		#region Properties
		public ISectorResourcesWallet StartingIncome => _startingIncome;
		public float TickInvervalInSeconds => _tickInvervalInSeconds;
		#endregion Properties

		#region Ctor
		public PlayerIncomeManagerData(ISectorResourcesWallet wallet, float tickInvervalInSeconds)
		{
			_startingIncome = wallet;
			_tickInvervalInSeconds = tickInvervalInSeconds;
		}
		#endregion Ctor
	}
}