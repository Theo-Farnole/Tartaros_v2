namespace Tartaros
{
	using UnityEngine;

	public static class Vector2Extensions
	{
		public static Vector3 ToXZ(this Vector2 v2)
		{
			return new Vector3(v2.x, 0, v2.y);
		}

		public static Vector2 Min(this Vector2 vector, float max)
		{
			return new Vector2(Mathf.Min(vector.x, max), Mathf.Min(vector.y, max));
		}

		public static Vector2 GetDirectionTo(this Vector2 vector, Vector2 target)
		{
			return (target - vector).normalized;
		}


		public static float GetSqDistanceTo(this Vector2 v1, Vector2 v2)
		{
			return (v1 - v2).sqrMagnitude;
		}
	}
}
