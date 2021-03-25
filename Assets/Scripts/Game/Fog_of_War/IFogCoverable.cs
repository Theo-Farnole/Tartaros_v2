namespace Tartaros.FogOfWar
{
	using Tartaros.Utilities;

	public interface IFogCoverable
	{
		bool IsCovered { get; set; }
		BoundsXZ ModelBounds { get; }
	}
}