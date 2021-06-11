namespace Tartaros.Math
{
	using System.Collections.Generic;
	using UnityEngine;

	public struct ConvexPolygon : IContainable, IShape
	{
		#region Fields
		public static ConvexPolygon OneSquare => new ConvexPolygon(new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1));
		public List<Vector2> vertices;
		#endregion Fields

		#region Properties
		public Vector2[] Normals
		{
			get
			{
				List<Vector2> output = new List<Vector2>();

				for (int i = 0; i < vertices.Count; i++)
				{
					bool lastVertex = i == vertices.Count - 1;

					Vector2 currentVertex = vertices[i];
					Vector2 nextVertex = lastVertex ? vertices[0] : vertices[i + 1];

					Vector2 edge = nextVertex - currentVertex;
					Vector2 normal = Vector2.Perpendicular(edge).normalized;
					output.Add(normal);
				}

				return output.ToArray();
			}
		}
		#endregion Properties

		#region Ctor
		public ConvexPolygon(params Vector2[] points)
		{
			this.vertices = new List<Vector2>(points);
		}

		public ConvexPolygon(Rectangle rect) : this(rect.TopLeft, rect.Max, rect.BottomRight, rect.Min)
		{

		}
		#endregion Ctor

		#region Methods		
		public bool ContainsWorldPosition(Vector3 position)
		{
			return ContainsPoint2D(new Vector2(position.x, position.z));
		}

		public bool ContainsPoint2D(Vector2 point)
		{
			return MathHelper.IsPointInPolygon(vertices, point);
		}

		bool IContainable.ContainsPosition(Vector3 worldPosition) => ContainsWorldPosition(worldPosition);
		#endregion Methods
	}
}