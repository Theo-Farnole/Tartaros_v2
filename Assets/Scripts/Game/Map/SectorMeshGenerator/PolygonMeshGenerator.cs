namespace Tartaros.Map
{
	using System.Linq;
	using Tartaros.Math;
	using UnityEngine;

	public static class PolygonMeshGenerator
	{
		#region Methods
		public static Mesh GenerateMesh(ConvexPolygon convexPolygon)
		{
			var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(convexPolygon.points.ToArray(), v => v);

			// exemple: https://gist.github.com/Hyperparticle/68586a8834ed6cafd4a1b2ba32ccf6ed
			var triangulator = new Triangulator(convexPolygon.points.ToArray());
			var indices = triangulator.Triangulate();

			Mesh mesh = new Mesh
			{
				vertices = vertices3D,
				triangles = indices
			};

			mesh.RecalculateNormals();
			mesh.RecalculateBounds();

			return mesh;
		}


		#endregion Methods
	}
}
