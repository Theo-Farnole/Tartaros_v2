namespace Tartaros.Map
{
	using UnityEngine;

	public static class SectorMeshGenerator
	{
		public static Mesh GenerateMesh(SectorData sectorData)
		{
			return PolygonMeshGenerator.GenerateMesh(sectorData.ConvexPolygon);
		}
	}
}