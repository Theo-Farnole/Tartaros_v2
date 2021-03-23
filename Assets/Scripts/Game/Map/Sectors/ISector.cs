namespace Tartaros.Sectors
{
	using Tartaros.Math;
	using UnityEngine;

	public interface ISector
	{
		GameObject[] ObjectsInSector { get; }
		ConvexPolygon Polygon { get; }
		bool CanCapture();
		void Capture();
	}
}
