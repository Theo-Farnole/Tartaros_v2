namespace Tartaros.Orders
{
    using System;
    using System.Collections;
    using Tartaros.Entities;
    using Tartaros.Orders;
    using Tartaros.ServicesLocator;
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
                var userErrorLogger = Services.Instance.Get<UserErrorsLogger>();

                if (wallToGate.CanSpawn() && wallToGate.HaveEnoughSpace())
                {
                    wallToGate.InstanciateGate();
                }
                else
                {
                    userErrorLogger.Log("Cannot spawn wall");
                }
            };
        }
    }
}