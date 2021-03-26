namespace Tartaros
{
	using System.Collections.Generic;
	using UnityEngine;

	public static class MeshGenerator
	{
		private const int CircleSegmentCount = 64;
		private const int CircleVertexCount = CircleSegmentCount + 2;
		private const int CircleIndexCount = CircleSegmentCount * 3;

		public static Mesh GenerateCircleMesh()
		{
			Mesh circle = new Mesh();
			List<Vector3> vertices = new List<Vector3>(CircleVertexCount);
			int[] indices = new int[CircleIndexCount];
			float segmentWidth = Mathf.PI * 2f / CircleSegmentCount;
			float angle = 0f;
			vertices.Add(Vector3.zero);

			for (int i = 1; i < CircleVertexCount; ++i)
			{
				vertices.Add(new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)));
				angle -= segmentWidth;
				if (i > 1)
				{
					int j = (i - 2) * 3;
					indices[j + 0] = 0;
					indices[j + 1] = i - 1;
					indices[j + 2] = i;
				}
			}

			circle.SetVertices(vertices);
			circle.SetIndices(indices, MeshTopology.Triangles, 0);
			circle.RecalculateBounds();
			return circle;
		}
	}
}
