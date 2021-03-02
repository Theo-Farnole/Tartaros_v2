namespace Tartaros.Utilities
{
	using UnityEngine;

	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance = null;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					T[] instances =
						FindObjectsOfType<T>();

					if (instances.Length > 1)
					{
						Debug.LogWarning(instances[0].name + " There is more than one instance of " + typeof(T) + " Singleton. ");
					}
					if (instances != null && instances.Length > 0)
					{
						_instance = instances[0];
					}
				}

				return _instance;
			}
		}

		void OnDestroy()
		{
			_instance = null;
		}
	}
}