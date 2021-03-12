namespace Tartaros
{
	using UnityEngine;

	public static class GameObjectExtensions
	{
		public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T entity)
		{
			entity = gameObject.GetComponentInParent<T>();
			return entity != null;
		}
	}
}
