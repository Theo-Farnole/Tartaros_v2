﻿namespace Tartaros.Orders
{
    using System;
    using System.Collections;
    using Tartaros.Construction;
	using Tartaros.ServicesLocator;
	using UnityEngine;

    public class CloseDoorsOrder : Order
    {
        private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.CloseDoorIcon;
        public CloseDoorsOrder(Gate gate) : base(Icon, CloseDoorsAction(gate))
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