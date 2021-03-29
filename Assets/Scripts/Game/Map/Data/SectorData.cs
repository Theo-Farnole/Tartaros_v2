namespace Tartaros.Map
{
	using Sirenix.Serialization;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Economy;
	using Tartaros.Math;
	using UnityEngine;

	[Serializable]
	public class SectorData
	{
		#region Fields
		[SerializeField]
		private List<Vertex2D> _vertices = new List<Vertex2D>();

		[OdinSerialize]
		private ISectorResourcesWallet _capturePrice = null;
		#endregion Fields

		#region Properties
		public ISectorResourcesWallet CapturePrice => _capturePrice;
		public Vertex2D[] Vertices => _vertices.ToArray();
		public Vertex2D LastVertex => _vertices[_vertices.Count - 1];

		public Vertex2D this[int i] => _vertices[i];
		public int VerticesCount => _vertices.Count;
		public Vector3[] AllWorldsPoint => _vertices.Select(x => x.WorldPosition).ToArray();
		public Vector3 Centroid => MathHelper.CalculateCentroid(AllWorldsPoint);
		public ConvexPolygon ConvexPolygon => new ConvexPolygon(AllWorldsPoint.Select(vector => new Vector2(vector.x, vector.z)).ToArray());
		#endregion Properties

		#region Ctor
		public SectorData(params Vertex2D[] vertices) : this(vertices, null)
		{

		}

		public SectorData(Vertex2D[] vertices, ISectorResourcesWallet capturePrice)
		{
			_vertices = new List<Vertex2D>(vertices);
			_capturePrice = capturePrice;
		}
		#endregion Ctor

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
