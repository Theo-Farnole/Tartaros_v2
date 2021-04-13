
namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using Tartaros.UI;
	using UnityEngine;

	public interface IConstructable : IPortraiteable
	{
		GameObject PreviewPrefab { get; }
		GameObject GameplayPrefab { get; }
		GameObject WallCornerModel { get; }
		GameObject WallCornerGameplay { get; }
		ISectorResourcesWallet Price { get; }
		Vector2 Size { get; }
		bool IsWall { get; }
		IConstructionRule[] Rules { get; }
	}
}