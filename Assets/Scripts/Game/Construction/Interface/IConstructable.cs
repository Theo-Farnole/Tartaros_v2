
namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using Tartaros.UI;
	using UnityEngine;

	public interface IConstructable : IPortraiteable
	{
		GameObject PreviewPrefab { get; }
		GameObject GameplayPrefab { get; }
		GameObject WallLModel { get; }
		GameObject WallLGameplay { get; }
		GameObject WallTModel { get; }
		GameObject WallTGameplay { get; }
		GameObject WallXModel { get; }
		GameObject WallXGameplay { get; }
		ISectorResourcesWallet Price { get; }
		Vector2 Size { get; }
		bool IsWall { get; }
		IConstructionRule[] Rules { get; }
	}
}