namespace Tartaros.Orders
{
    using System;
    using System.Collections;
    using Tartaros.Construction;
    using UnityEngine;

    public class CloseDoorsOrder : Order
    {
        public CloseDoorsOrder(Gate gate, Sprite icon) : base(icon, CloseDoorsAction(gate))
        {
        }


        private static Action CloseDoorsAction(Gate gate)
        {
            return () =>
            {
                gate.CloseGate();
            };
        }
    }
}