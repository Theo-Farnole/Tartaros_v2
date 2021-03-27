namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IGloryWallet
    {
        int GetAmount();
        void AddAmount(int amount);
        bool CanSpend(int price);
        void Spend(int price);
    }
}