namespace Tartaros.Map
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	[Serializable]
	public class Site
	{
		#region Fields
		[SerializeField]
		private List<Vertex> _vertices = new List<Vertex>();
		#endregion Fields

		#region Properties
		public Vertex[] Vertices => _vertices.ToArray();

		public Vertex this[int i] => _vertices[i];
		public int VerticesCount => _vertices.Count;
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
		#endregion Methods
	}
}
