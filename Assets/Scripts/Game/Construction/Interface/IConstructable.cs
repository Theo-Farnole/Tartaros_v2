
namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using Tartaros.UI;
	using UnityEngine;

	public interface IConstructable : IPortraiteable
	{
		GameObject ModelPrefab { get; }
		ISectorResourcesWallet Price { get; }
		Vector2 Size { get; }
	}
}