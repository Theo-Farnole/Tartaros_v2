namespace Tartaros.Map
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Vertex2D
	{
		[SerializeField]
		private Vector2 _position;

		public Vector3 WorldPosition
		{
			get => _position.ToXZ();
			set => _position = new Vector2(value.x, value.z);
		}

		public Vector2 Position2D => _position;

		public Vertex2D(Vector3 worldPosition)
		{
			WorldPosition = worldPosition;
		}

		public Vertex2D(float x, float y, float z) : this(new Vector3(x, y, z))
		{ }
	}
}
