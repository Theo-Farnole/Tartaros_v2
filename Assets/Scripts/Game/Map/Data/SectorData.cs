namespace Tartaros.Map
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using UnityEngine;

	[Serializable]
	public class SectorData
	{
		#region Fields
		[SerializeReference]
		private List<Vertex2D> _vertices = new List<Vertex2D>();
		#endregion Fields

		#region Properties
		public Vertex2D[] Vertices => _vertices.ToArray();
		public Vertex2D LastVertex => _vertices[_vertices.Count - 1];

		public Vertex2D this[int i] => _vertices[i];
		public int VerticesCount => _vertices.Count;
		public Vector3[] AllPoints => _vertices.Select(x => x.WorldPosition).ToArray();
		public Vector3 Centroid => MathHelper.CalculateCentroid(AllPoints);
		public ConvexPolygon ConvexPolygon => new ConvexPolygon(AllPoints.Select(vector => new Vector2(vector.x, vector.z)).ToArray());
		#endregion Properties

		#region Methods
		public void AddVertex(Vertex2D vertex)
		{
			_vertices.Add(vertex);
		}

		/// <summary>
		/// Returns an array that start and end with the first vertex's position.
		/// </summary>
		public Vector3[] GetWorldPointsWrapped()
		{
			List<Vector3> sitePoints = Vertices.Select(x => x.WorldPosition).ToList();

			if (sitePoints.Count > 0)
			{
				sitePoints.Add(this[0].WorldPosition);
			}

			return sitePoints.ToArray();
		}

		public bool IsVertexFirstWaypoint(Vertex2D vertex)
		{
			return VerticesCount > 1 && vertex == this[0];
		}
		#endregion Methods
	}
}
