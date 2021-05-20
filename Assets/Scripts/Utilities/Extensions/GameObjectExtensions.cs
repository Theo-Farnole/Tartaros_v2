namespace Tartaros
{
	using UnityEngine;

	public static class GameObjectExtensions
	{
		public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T entity)
		{
			if (gameObject is null) throw new System.ArgumentNullException(nameof(gameObject));

			entity = gameObject.GetComponentInParent<T>();
			return entity != null;
		}

		public static bool TryGetComponentInChildren<T>(this GameObject gameObject, out T entity)
		{
			if (gameObject is null) throw new System.ArgumentNullException(nameof(gameObject));

			entity = gameObject.GetComponentInChildren<T>();
			return entity != null;
		}

		/// <summary>
		/// Get component. If no component is attached, add one.
		/// </summary>
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			T component = gameObject.GetComponent(typeof(T)) as T;

			if (component == null)
			{
				component = gameObject.AddComponent(typeof(T)) as T;
			}

			return component;
		}
	}
}
