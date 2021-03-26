namespace Tartaros.FogOfWar
{
	using Tartaros.Math;

	public interface IFogCoverable
	{
		bool IsCovered { get; set; }
		IShape ModelBounds { get; }
	}
}