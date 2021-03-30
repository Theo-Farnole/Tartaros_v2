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
                    InitializeInstance();
                }

                return _instance;
            }
        }

        private static void InitializeInstance()
        {
            if (_instance != null)
            {
                Debug.LogErrorFormat("Cannot initialize instance: there is already a instance of {0}.", typeof(T));
                return;
            }

            T[] instances = FindObjectsOfType<T>();

            if (instances.Length == 0) throw new NoSingletonInstanceFound<T>();

            if (instances.Length > 1)
            {
                Debug.LogWarning(instances[0].name + " There is more than one instance of " + typeof(T) + " Singleton. ");
            }
            if (instances != null && instances.Length > 0)
            {
                _instance = instances[0];
            }
        }

        public static bool HasInstance
        {
            get
            {
                try
                {
                    return Instance != null;
                }
                catch (NoSingletonInstanceFound<T>)
                {
                    return false;
                }
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
        }

        void OnDestroy()
        {
            _instance = null;
        }
    }
}