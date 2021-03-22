namespace Tartaros.Sectors
{
	using Tartaros.Math;

	public interface ISector
	{
		ConvexPolygon Polygon { get; }
		bool CanCapture();
		void Capture();
	}
}
