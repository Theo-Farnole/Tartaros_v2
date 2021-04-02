namespace Tartaros.Orders
{
    using System;
    using System.Collections;
    using Tartaros.Entities;
    using Tartaros.Orders;
    using UnityEngine;

    public class InstanciateGateOrder : Order
    {
        public InstanciateGateOrder(EntityWallToGate wallToGate, Sprite portrait) : base(portrait, InstancaiteGate(wallToGate))
        {
        }

        private static Action InstancaiteGate(EntityWallToGate wallToGate)
        {
            return () =>
            {
                if (wallToGate.CanSpawn())
                {
                    wallToGate.InstanciateGate();
                }
            };
        }
    }
}