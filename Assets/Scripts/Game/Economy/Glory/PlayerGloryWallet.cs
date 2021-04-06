namespace Tartaros.Economy
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class PlayerGloryWallet : MonoBehaviour, IPlayerGloryWallet
	{
		private IGloryWallet _gloryWallet = null;

		event EventHandler<GloryAmountChangedArgs> IGloryWallet.AmountChanged
		{
			add => _gloryWallet.AmountChanged += value;
			remove => _gloryWallet.AmountChanged -= value;
		}


		private void Awake()
		{
			_gloryWallet = new GloryWallet();

			Services.Instance.RegisterService<IPlayerGloryWallet>(this);
		}


		int IGloryWallet.GetAmount() => _gloryWallet.GetAmount();

		void IGloryWallet.Spend(int price) => _gloryWallet.Spend(price);

		bool IGloryWallet.CanSpend(int price) => _gloryWallet.CanSpend(price);

		void IGloryWallet.AddAmount(int amount) => _gloryWallet.AddAmount(amount);

		public override string ToString()
		{
			return _gloryWallet.ToString();
		}
	}
}