namespace Tartaros
{
	using UnityEngine;

	public static class Vector3Extensions
	{
		public static Vector2 GetVector2FromXZ(this Vector3 v3)
		{
			return new Vector2(v3.x, v3.z);
		}

	}
}
