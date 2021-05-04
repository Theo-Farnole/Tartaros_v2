using UnityEngine;

namespace CTS
{
    /// <summary>
    /// Be aware this will not prevent a non singleton constructor such as `T myT = new T();`
    /// To prevent that, add `protected T () {}` to your singleton class.
    /// 
    /// As a note, this is made as MonoBehaviour because we need Coroutines.
    /// Adapted from http://wiki.unity3d.com/index.php/Singleton
    /// 
    /// public class Manager : Singleton<Manager>
    /// {
    ///     protected Manager() { } // guarantee this will be always a singleton only - can't use the constructor!
    ///     public string myGlobalVar = "whatever";
    /// }
    /// public class MyClass : MonoBehaviour {
    ///	    void Awake () {
    ///		    Debug.Log(Manager.Instance.myGlobalVar);
    ///	    }
    /// }
    /// </summary>
    public class CTSSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString();
						singleton.hideFlags = HideFlags.HideAndDontSave;

                        if (Application.isPlaying)
                        {
                            DontDestroyOnLoad(singleton);
                        }
                    }

                    return _instance;
                }
            }
        }
	}
}