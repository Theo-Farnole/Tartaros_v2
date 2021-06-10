namespace Tartaros.FogOfWar
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using Unity.Burst;
	using Unity.Collections;
	using Unity.Jobs;
	using UnityEngine;

	[BurstCompile]
	struct CalculateFogVisibilityJob : IJobParallelFor
	{
		[ReadOnly] public NativeArray<Circle> visionsCircle;
		[ReadOnly] public NativeArray<Vector2> coverables;

		[ReadOnly] public int polygonCount;
		[ReadOnly] public NativeList<Vector2> visionsPolygon;
		[ReadOnly] public NativeArray<int> visionsPolygonStartIndexes;
		[ReadOnly] public NativeArray<int> visionsPolygonEndIndexes;

		public NativeArray<bool> isCoverResult;

		void IJobParallelFor.Execute(int index)
		{
			Vector2 coverablePoint = coverables[index];

			if (CheckCircleCollisions(coverablePoint) == true || CheckPolygonCollisions(coverablePoint) == true)
			{
				isCoverResult[index] = false;
			}
			else
			{
				isCoverResult[index] = true;
			}
		}

		private bool CheckCircleCollisions(Vector2 coverablePoint)
		{
			for (int i = 0, length = visionsCircle.Length; i < length; i++)
			{
				bool isVisible = CollisionOverlapCalculator.DoPointOverlapCircle(coverablePoint.x, coverablePoint.y, visionsCircle[i].position.x, visionsCircle[i].position.y, visionsCircle[i].radius);

				if (isVisible == true)
				{
					return true;
				}
			}

			return false;
		}

		private bool CheckPolygonCollisions(Vector2 coverablePoint)
		{
			for (int i = 0, length = polygonCount; i < length; i++)
			{
				NativeSlice<Vector2> vertices = new NativeSlice<Vector2>(visionsPolygon, visionsPolygonStartIndexes[i], visionsPolygonEndIndexes[i]);

				bool isVisible = DoPolygonOverlapPoint(vertices, coverablePoint.x, coverablePoint.y);

				if (isVisible == true)
				{
					return true;
				}
			}

			return false;
		}

		public bool DoPolygonOverlapPoint(NativeSlice<Vector2> vertices, float px, float py)
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
		private NativeArray<Circle> visionsCircle;
		private NativeArray<Vector2> coverablesPosition;
		private NativeArray<bool> isCoverResult;

		private NativeList<Vector2> visionsPolygon;
		private NativeArray<int> visionsPolygonStartIndexes;
		private NativeArray<int> visionsPolygonEndIndexes;

		private JobHandle handle;

		public void Update(List<IFogVision> _visions, List<IFogCoverable> coverables)
		{
			IEnumerable<IShape> visions = _visions.Select(x => x.VisionShape);

			Circle[] circles = visions.OfType<Circle>().ToArray();

			visionsCircle = new NativeArray<Circle>(circles, Allocator.TempJob);
			isCoverResult = new NativeArray<bool>(coverables.Count, Allocator.TempJob);

			CreateCoverablesPosition(coverables);
			CreateContainer_PolygonVisions(visions);

			CalculateFogVisibilityJob job = new CalculateFogVisibilityJob
			{
				visionsCircle = visionsCircle,
				visionsPolygon = visionsPolygon,
				visionsPolygonStartIndexes = visionsPolygonStartIndexes,
				visionsPolygonEndIndexes = visionsPolygonEndIndexes,
				coverables = coverablesPosition,
				isCoverResult = isCoverResult
			};


			handle = job.Schedule(this.coverablesPosition.Length, 1);
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
			visionsPolygon.Dispose();
			visionsPolygonStartIndexes.Dispose();
			visionsPolygonEndIndexes.Dispose();
		}

		private void CreateContainer_PolygonVisions(IEnumerable<IShape> visions)
		{
			ConvexPolygon[] polygons = visions.OfType<ConvexPolygon>().ToArray();

			int polygonCount = polygons.Length;
			visionsPolygon = new NativeList<Vector2>(0, Allocator.TempJob);
			visionsPolygonStartIndexes = new NativeArray<int>(polygonCount, Allocator.TempJob);
			visionsPolygonEndIndexes = new NativeArray<int>(polygonCount, Allocator.TempJob);

			for (int i = 0; i < polygons.Length; i++)
			{
				ConvexPolygon polygon = polygons[i];
				visionsPolygonStartIndexes[i] = i == 0 ? 0 : visionsPolygonStartIndexes[i - 1] + 1;
				visionsPolygonEndIndexes[i] = visionsPolygonStartIndexes[i] + polygon.vertices.Count - 1;

				foreach (var vertex in polygon.vertices)
				{
					visionsPolygon.Add(vertex);
				}
			}
		}

		private void CreateCoverablesPosition(List<IFogCoverable> coverables)
		{
			Vector2[] coverablesPosition = coverables
				.Select(x => x.ModelBounds)
				.OfType<Circle>()
				.Select(x => x.position)
				.ToArray();

			this.coverablesPosition = new NativeArray<Vector2>(coverablesPosition, Allocator.TempJob);
		}
	}
}
