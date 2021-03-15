namespace Tartaros.Map
{
	using System;
	using System.Collections.Generic;
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
		#endregion Methods
	}
}
