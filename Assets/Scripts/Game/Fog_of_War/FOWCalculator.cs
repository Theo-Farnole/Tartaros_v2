namespace Tartaros.FogOfWar
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using Unity.Burst;
	using Unity.Collections;
	using Unity.Jobs;
	using UnityEngine;
	using UnityEngine.Assertions;

	[BurstCompile]
	struct CalculateFogVisibilityJob : IJobParallelFor
	{
		[ReadOnly] public NativeArray<Circle> visionsCircle;
		[ReadOnly] public NativeArray<Vector2> coverablesPosition;

		[ReadOnly] public int polygonCount;
		[ReadOnly] public NativeList<Vector2> visionsPolygonVertices;
		[ReadOnly] public NativeArray<int> visionsPolygonStartIndexes;
		[ReadOnly] public NativeArray<int> visionsPolygonLength;

		public NativeArray<bool> isCoverResult;

		void IJobParallelFor.Execute(int index)
		{
			Vector2 coverablePoint = coverablesPosition[index];

			if (OverlapCircles(coverablePoint) == true || OverlapPolygons(coverablePoint) == true)
			{
				isCoverResult[index] = false;
			}
			else
			{
				isCoverResult[index] = true;
			}
		}

		private bool OverlapCircles(Vector2 coverablePoint)
		{
			for (int i = 0, length = visionsCircle.Length; i < length; i++)
			{
				bool overlap = CollisionOverlapCalculator.DoPointOverlapCircle(coverablePoint.x, coverablePoint.y, visionsCircle[i].position.x, visionsCircle[i].position.y, visionsCircle[i].radius);

				if (overlap == true)
				{
					return true;
				}
			}

			return false;
		}

		private bool OverlapPolygons(Vector2 coverablePoint)
		{
			for (int i = 0, length = polygonCount; i < length; i++)
			{
				NativeSlice<Vector2> vertices = new NativeSlice<Vector2>(visionsPolygonVertices, visionsPolygonStartIndexes[i], visionsPolygonLength[i]);

				bool overlap = DoPolygonOverlapPoint(vertices, coverablePoint.x, coverablePoint.y);

				if (overlap == true)
				{
					return true;
				}
			}

			return false;
		}

		private bool DoPolygonOverlapPoint(NativeSlice<Vector2> vertices, float px, float py)
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

	class FOWCalculator
	{
		#region Fields
		private NativeList<Circle> visionsCircle;
		private NativeArray<Vector2> coverablesPosition;
		private NativeArray<bool> isCoverResult;

		private NativeList<Vector2> visionsPolygonVertices;
		private NativeList<int> visionsPolygonStartIndexes;
		private NativeList<int> visionsPolygonLength;
		private int polygonCount;

		private JobHandle handle;
		#endregion Fields

		#region Methods
		public void Update(List<IFogVision> _visions, List<IFogCoverable> coverables)
		{
			isCoverResult = new NativeArray<bool>(coverables.Count, Allocator.TempJob);

			CreateContainer_Circles(_visions);
			CreateContainer_CoverablesPosition(coverables);
			CreateContainer_PolygonVisions(_visions);

			CalculateFogVisibilityJob job = new CalculateFogVisibilityJob
			{
				visionsCircle = visionsCircle,
				visionsPolygonVertices = visionsPolygonVertices,
				visionsPolygonStartIndexes = visionsPolygonStartIndexes,
				visionsPolygonLength = visionsPolygonLength,
				coverablesPosition = coverablesPosition,
				isCoverResult = isCoverResult,
				polygonCount = polygonCount
			};


			handle = job.Schedule(coverablesPosition.Length, 64);
		}

		public void LateUpdate(List<IFogCoverable> coverables)
		{
			handle.Complete();

			for (int i = 0, length = isCoverResult.Length; i < length; i++)
			{
				coverables[i].IsCovered = isCoverResult[i];
			}

			visionsCircle.Dispose();
			coverablesPosition.Dispose();
			isCoverResult.Dispose();
			visionsPolygonVertices.Dispose();
			visionsPolygonStartIndexes.Dispose();
			visionsPolygonLength.Dispose();
		}

		private void CreateContainer_Circles(List<IFogVision> _visions)
		{
			visionsCircle = new NativeList<Circle>(_visions.Count, Allocator.TempJob);

			for (int i = 0, length = _visions.Count; i < length; i++)
			{
				if (_visions[i].VisionShape is Circle circle)
				{
					visionsCircle.Add(circle);
				}
			}
		}

		private void CreateContainer_PolygonVisions(List<IFogVision> _visions)
		{
			visionsPolygonVertices = new NativeList<Vector2>(0, Allocator.TempJob);
			visionsPolygonStartIndexes = new NativeList<int>(polygonCount, Allocator.TempJob);
			visionsPolygonLength = new NativeList<int>(polygonCount, Allocator.TempJob);

			polygonCount = 0;

			int polygonSum = 0;

			for (int i = 0, length = _visions.Count; i < length; i++)
			{
				if (_visions[i].VisionShape is ConvexPolygon polygon)
				{
					int verticesCount = polygon.vertices.Count;

					visionsPolygonStartIndexes.Add(polygonSum);
					visionsPolygonLength.Add(verticesCount);

					polygonSum += verticesCount;

					for (int j = 0; j < verticesCount; j++)
					{
						visionsPolygonVertices.Add(polygon.vertices[j]);
					}

					polygonCount++;
				}
			}

			Assert.AreEqual(visionsPolygonStartIndexes.Length, polygonCount);
			Assert.AreEqual(visionsPolygonLength.Length, polygonCount);
		}

		private void CreateContainer_CoverablesPosition(List<IFogCoverable> coverables)
		{
			coverablesPosition = new NativeArray<Vector2>(coverables.Count, Allocator.TempJob);

			for (int i = 0, length = coverables.Count; i < length; i++)
			{
				coverablesPosition[i] = coverables[i].Position;
			}
		}
		#endregion
	}
}
