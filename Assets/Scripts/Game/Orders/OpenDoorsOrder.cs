namespace Tartaros.Orders
{
    using System;
    using System.Collections;
    using Tartaros.Construction;
    using UnityEngine;
    public class OpenDoorsOrder : Order
    {
        public OpenDoorsOrder(Gate gate, Sprite icon) : base(icon, OpenDoorsAction(gate))
        {
        }


        private static Action OpenDoorsAction(Gate gate)
        {
            return () =>
            {
                gate.OpenGate();
            };
        }
    }
}