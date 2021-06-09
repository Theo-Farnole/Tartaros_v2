namespace Tartaros.FogOfWar
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using Unity.Collections;
	using Unity.Jobs;
	using UnityEngine;

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
			IShape[] visions = _visions.Select(x => x.VisionShape).ToArray();

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
			this.coverablesPosition.Dispose();
			isCoverResult.Dispose();
			visionsPolygon.Dispose();
			visionsPolygonStartIndexes.Dispose();
			visionsPolygonEndIndexes.Dispose();
		}

		private void CreateContainer_PolygonVisions(IShape[] visions)
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
			Vector2[] coverablesPosition = coverables.Select(x => x.ModelBounds).OfType<Circle>().Select(x => x.position).ToArray();
			this.coverablesPosition = new NativeArray<Vector2>(coverablesPosition, Allocator.TempJob);
		}
	}
}
