namespace Tartaros.Orders
{
    using System;
    using System.Collections;
    using Tartaros.Construction;
	using Tartaros.ServicesLocator;
	using UnityEngine;
    public class OpenDoorsOrder : Order
    {
        private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.OpenDoorIcon;
        public OpenDoorsOrder(Gate gate) : base(Icon, OpenDoorsAction(gate))
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