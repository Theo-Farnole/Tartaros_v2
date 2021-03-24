namespace Tartaros.FogOfWar
{
	public interface IFogCoverable
	{
		bool IsCovered { get; set; }
		IContainable Volume { get; }
	}
}