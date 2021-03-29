namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class PlayerGloryWallet : MonoBehaviour, IPlayerGloryWallet
    {
        private IGloryWallet _gloryWallet = null;


        private void Awake()
        {
            _gloryWallet = new GloryWallet();

            Services.Instance.RegisterService(this);
        }

        private void Update()
        {
            Debug.Log(_gloryWallet.GetAmount());
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