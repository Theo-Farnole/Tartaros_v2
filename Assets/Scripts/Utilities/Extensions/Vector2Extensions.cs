namespace Tartaros
{
	using UnityEngine;

	public static class Vector2Extensions
	{
		public static Vector3 ToXZ(this Vector2 v2)
		{
			return new Vector3(v2.x, 0, v2.y);
		}
	}
}
