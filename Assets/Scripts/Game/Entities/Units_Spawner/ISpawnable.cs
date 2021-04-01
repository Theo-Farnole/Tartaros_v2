namespace Tartaros.Entities
{
	using Tartaros.UI;
	using UnityEngine;

	public interface ISpawnable : IPortraiteable
	{
		GameObject Prefab { get; }
		int PopulationAmount { get; }
	}
}
