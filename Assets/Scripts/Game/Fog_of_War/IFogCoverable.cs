namespace Tartaros.FogOfWar
{
	using UnityEngine;

	public interface IFogCoverable
	{
		bool IsCovered { get; set; }
		Vector2 Position { get; }
	}
}