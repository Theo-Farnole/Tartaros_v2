namespace Tartaros.Orders
{
    using System;
    using System.Collections;
    using Tartaros.Construction;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;
    public class OpenDoorsOrder : Order
    {
        private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.OpenDoorIcon;
        public OpenDoorsOrder(Gate gate) : base(Icon, OpenDoorsAction(gate), Services.Instance.Get<HoverPopupsDatabase>().Database.OpenGate)
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