namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GloryWallet : IGloryWallet
    {
        private int _gloryAmount = 0;

        void IGloryWallet.AddAmount(int amount)
        {
            _gloryAmount += amount;
        }

        void IGloryWallet.Spend(int price)
        {
            if (_gloryAmount - price < 0)
            {
                _gloryAmount -= price;
            }
        }

        bool IGloryWallet.CanSpend(int price)
        {
            return _gloryAmount - price >= 0;
        }

        int IGloryWallet.GetAmount()
        {
            return _gloryAmount;
        }
    }
}