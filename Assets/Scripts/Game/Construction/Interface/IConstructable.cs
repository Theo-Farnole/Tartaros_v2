
namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using Tartaros.UI;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public interface IConstructable : IPortraiteable
	{
		GameObject PreviewPrefab { get; }
		GameObject GameplayPrefab { get; }
		GameObject WallCornerModel { get; }
		GameObject WallCornerGameplay { get; }
		GameObject ConstructionKitModel { get; }
		int TimeToConstruct { get; }
		ISectorResourcesWallet Price { get; }
		Vector2 Size { get; }
		bool IsWall { get; }
		IConstructionRule[] Rules { get; }
		HoverPopupData HoverPopupData { get; }
	}
}