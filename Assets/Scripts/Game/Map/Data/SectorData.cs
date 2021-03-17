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
		private List<Vertex> _vertices = new List<Vertex>();
		#endregion Fields

		#region Properties
		public Vertex[] Vertices => _vertices.ToArray();
		public Vertex LastVertex => _vertices[_vertices.Count - 1];

		public Vertex this[int i] => _vertices[i];
		public int VerticesCount => _vertices.Count;
		public Vector3[] AllPoints => _vertices.Select(x => x.Position).ToArray();
		public Vector3 Centroid => MathHelper.CalculateCentroid(AllPoints);
		public ConvexPolygon ConvexPolygon => new ConvexPolygon(AllPoints.Select(vector => new Vector2(vector.x, vector.z)).ToArray());
		#endregion Properties

		#region Methods
		public void AddVertex(Vertex vertex)
		{
			_vertices.Add(vertex);
		}

		/// <summary>
		/// Returns an array that start and end with the first vertex's position.
		/// </summary>
		public Vector3[] GetWorldPointsWrapped()
		{
			List<Vector3> sitePoints = Vertices.Select(x => x.Position).ToList();

			if (sitePoints.Count > 0)
			{
				sitePoints.Add(this[0].Position);
			}

			return sitePoints.ToArray();
		}

		public bool IsVertexFirstWaypoint(Vertex vertex)
		{
			return VerticesCount > 1 && vertex == this[0];
		}
		#endregion Methods
	}
}
