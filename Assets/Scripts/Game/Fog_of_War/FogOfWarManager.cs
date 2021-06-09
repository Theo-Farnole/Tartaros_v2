namespace Tartaros.FogOfWar
{
	using Sirenix.Utilities;
	using System.CodeDom.Compiler;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using Tartaros.ServicesLocator;
	using Unity.Burst;
	using Unity.Collections;
	using Unity.Jobs;
	using UnityEngine;
	using UnityEngine.ParticleSystemJobs;

	public class FogOfWarManager : MonoBehaviour
	{
		#region Fields
		[ShowInRuntime] private List<IFogVision> _visions = new List<IFogVision>();
		[ShowInRuntime] private List<IFogCoverable> _coverables = new List<IFogCoverable>();

		private FOWCalculator _fowCalculator = new FOWCalculator();
		#endregion Fields

		#region Methods
		private void Update()
		{
			_fowCalculator.Update(_visions, _coverables);
		}

		private void LateUpdate()
		{
			_fowCalculator.LateUpdate(_coverables);
		}

		private void OnDisable()
		{
			UncoverAllCoverables();
		}

		private void UncoverAllCoverables()
		{
			foreach (var coverable in _coverables)
			{
				coverable.IsCovered = false;
			}
		}

		public void AddVision(IFogVision vision)
		{
			if (_visions.Contains(vision) == true)
			{
				Debug.LogErrorFormat("Cannot add fog vision {0}. It is already in visions list.", vision.ToString());
				return;
			}

			_visions.Add(vision);
		}

		public void RemoveVision(IFogVision vision)
		{
			if (_visions.Contains(vision) == false)
			{
				Debug.LogErrorFormat("Cannot remove fog vision {0}. It is not in visions list.", vision.ToString());
				return;
			}

			_visions.Remove(vision);
		}

		public void AddCoverable(IFogCoverable coverable)
		{
			if (_coverables.Contains(coverable) == true)
			{
				Debug.LogErrorFormat("Cannot add fog coverable {0}. It is already in coverables list.", coverable.ToString());
				return;
			}

			_coverables.Add(coverable);
		}

		public void RemoveCoverable(IFogCoverable coverable)
		{
			if (_coverables.Contains(coverable) == false)
			{
				Debug.LogErrorFormat("Cannot remove fog coverable {0}. It is not in coverables list.", coverable.ToString());
				return;
			}

			_coverables.Remove(coverable);
		}

		private void UpdateCoverablesVisibility()
		{
			// TODO TF: (performance) cache this
			IShape[] visions = _visions.Select(x => x.VisionShape).ToArray();

			foreach (IFogCoverable coverable in _coverables)
			{
				IShape coverableShape = coverable.ModelBounds;

				bool isVisible = CollisionOverlapCalculator.DoOverlap(coverableShape, visions);
				coverable.IsCovered = !isVisible;
			}
		}
		#endregion Methods
	}

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
}
