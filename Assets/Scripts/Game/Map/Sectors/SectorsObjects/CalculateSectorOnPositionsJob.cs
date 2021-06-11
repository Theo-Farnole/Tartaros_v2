namespace Tartaros.Map
{
	using Tartaros.Math;
	using Unity.Burst;
	using Unity.Collections;
	using Unity.Jobs;
	using UnityEngine;

	[BurstCompile]
	struct CalculateSectorOnPositionsJob : IJobParallelFor
	{
		[ReadOnly] public NativeArray<Vector2> objectsPosition;
		[ReadOnly] public PolygonsContainer polygons;

		public NativeArray<int> objectsSectorIndexes;

		void IJobParallelFor.Execute(int index)
		{
			if (OverlapPolygons(objectsPosition[index], out int sectorIndex) == true)
			{
				objectsSectorIndexes[index] = sectorIndex;
			}
			else
			{
				objectsSectorIndexes[index] = -1;
			}
		}

		bool OverlapPolygons(Vector2 position, out int sectorIndex)
		{
			for (int i = 0, length = polygons.PolygonsCount; i < length; i++)
			{
				NativeSlice<Vector2> polygon = polygons.GetPolygonVertices(i);

				if (DoPolygonOverlapPoint(polygon, position.x, position.y) == true)
				{
					sectorIndex = i;
					return true;
				}
			}

			sectorIndex = -1;
			return false;
		}

		public static bool DoPolygonOverlapPoint(NativeSlice<Vector2> vertices, float px, float py)
		{
			bool collision = false;

			// go through each of the vertices, plus the next
			// vertex in the list
			int next = 0;
			for (int current = 0; current < vertices.Length; current++)
			{

				// get next vertex in list
				// if we've hit the end, wrap around to 0
				next = current + 1;
				if (next == vertices.Length) next = 0;

				// get the PVectors at our current position
				// this makes our if statement a little cleaner
				Vector2 vc = vertices[current];    // c for "current"
				Vector2 vn = vertices[next];       // n for "next"

				// compare position, flip 'collision' variable
				// back and forth
				if (((vc.y > py && vn.y < py) || (vc.y < py && vn.y > py)) &&
					 (px < (vn.x - vc.x) * (py - vc.y) / (vn.y - vc.y) + vc.x))
				{
					collision = !collision;
				}
			}
			return collision;
		}
	}
}
