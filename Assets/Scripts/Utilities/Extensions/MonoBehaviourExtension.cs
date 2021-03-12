namespace Tartaros
{
	using System;
	using System.Collections;
	using UnityEngine;

	public static class MonoBehaviourExtension
	{
		public static bool TryGetComponentInParent<T>(this MonoBehaviour monoBehaviour, out T entity)
		{
			return monoBehaviour.gameObject.TryGetComponentInParent(out entity);
		}

		/// <summary>
		/// Execute task after realtime.
		/// </summary>
		/// <param name="mono"></param>
		/// <param name="time"></param>
		/// <param name="task"></param>
		public static Coroutine ExecuteAfterTime(this MonoBehaviour mono, float time, Action task)
		{
			return mono.StartCoroutine(ExecuteAfterTimeCoroutine(time, task));
		}

		/// <summary>
		/// Called from ExecuteAfterTime.
		/// </summary>
		static IEnumerator ExecuteAfterTimeCoroutine(float time, Action task)
		{
			yield return new WaitForSecondsRealtime(time);

			task();
		}

		/// <summary>
		/// Execute task after one frame.
		/// </summary>
		/// <param name="mono"></param>
		/// <param name="time"></param>
		/// <param name="task"></param>
		public static Coroutine ExecuteAfterFrame(this MonoBehaviour mono, Action task)
		{
			return mono.StartCoroutine(ExecuteAfterFrameCoroutine(task));
		}

		static IEnumerator ExecuteAfterFrameCoroutine(Action task)
		{
			yield return new WaitForEndOfFrame();

			task();
		}

		/// <summary>
		/// Get component. If no component is attached, add one.
		/// </summary>
		public static T GetOrAddComponent<T>(this MonoBehaviour monoBehaviour) where T : Component
		{
			T component = monoBehaviour.GetComponent(typeof(T)) as T;

			if (component == null)
			{
				component = monoBehaviour.gameObject.AddComponent(typeof(T)) as T;
			}

			return component;
		}
	}

}