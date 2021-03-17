namespace Tartaros.Map
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Vertex
	{
		[SerializeField]
		private Vector3 _position;

		public Vector3 Position { get => _position; set => _position = value; }

		public Vertex(Vector3 position)
		{
			_position = position;
		}
	}
}
