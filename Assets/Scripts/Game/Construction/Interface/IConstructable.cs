
namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using Tartaros.UI;
	using UnityEngine;

	public interface IConstructable : IPortraiteable
	{
		GameObject PreviewPrefab { get; }
		GameObject GameplayPrefab { get; }
		ISectorResourcesWallet Price { get; }
		Vector2 Size { get; }

		bool IsChained { get; }
		IConstructionRule[] Rules { get; }
	}
}