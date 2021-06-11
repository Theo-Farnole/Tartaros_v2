namespace Tartaros.Math
{
	using System.Security;
	using Unity.Collections;
	using UnityEngine;
	using UnityEngine.Assertions;

	struct PolygonsContainer
	{
		#region Fields
		private NativeList<Vector2> visionsPolygonVertices;
		private NativeList<int> visionsPolygonStartIndexes;
		private NativeList<int> visionsPolygonLength;

		private int _polygonSum;
		#endregion Fields

		#region Properties
		public int PolygonsCount => visionsPolygonStartIndexes.Length; 
		#endregion Properties

		/// <summary>
		/// We need a useless parameter to bypass "struct cannot have constructor without parameter"
		/// </summary>
		/// <param name="uselessParameter"></param>
		public PolygonsContainer(int uselessParameter)
		{
			_polygonSum = 0;

			visionsPolygonVertices = new NativeList<Vector2>(0, Allocator.TempJob);
			visionsPolygonStartIndexes = new NativeList<int>(0, Allocator.TempJob);
			visionsPolygonLength = new NativeList<int>(0, Allocator.TempJob);
		}

		public void Clear()
		{
			_polygonSum = 0;

			visionsPolygonVertices = new NativeList<Vector2>(0, Allocator.TempJob);
			visionsPolygonStartIndexes = new NativeList<int>(0, Allocator.TempJob);
			visionsPolygonLength = new NativeList<int>(0, Allocator.TempJob);
		}

		public void Dispose()
		{
			visionsPolygonVertices.Dispose();
			visionsPolygonStartIndexes.Dispose();
			visionsPolygonLength.Dispose();
		}

		public void AddPolygon(ConvexPolygon polygon)
		{
			int verticesCount = polygon.vertices.Count;

			visionsPolygonStartIndexes.Add(_polygonSum);
			visionsPolygonLength.Add(verticesCount);

			_polygonSum += verticesCount;

			for (int j = 0; j < verticesCount; j++)
			{
				visionsPolygonVertices.Add(polygon.vertices[j]);
			}

			Assert.AreEqual(visionsPolygonStartIndexes.Length, PolygonsCount);
			Assert.AreEqual(visionsPolygonLength.Length, PolygonsCount);
		}

		public NativeSlice<Vector2> GetPolygonVertices(int index)
		{
			NativeSlice<Vector2> vertices = new NativeSlice<Vector2>(visionsPolygonVertices, visionsPolygonStartIndexes[index], visionsPolygonLength[index]);

			return vertices;
		}
	}
}
