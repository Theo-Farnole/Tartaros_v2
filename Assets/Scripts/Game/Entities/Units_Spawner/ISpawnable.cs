namespace Tartaros.Entities
{
	using Tartaros.UI;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public interface ISpawnable : IPortraiteable
	{
		GameObject Prefab { get; }
		int PopulationAmount { get; }
		HoverPopupData HoverPopupData { get; }
	}
}
