namespace Tartaros
{
	using System;
	using System.Collections;
	using UnityEngine;

	public static class MonoBehaviourExtension
	{
		public static bool TryGetComponentInParent<T>(this MonoBehaviour monoBehaviour, out T entity) => monoBehaviour.gameObject.TryGetComponentInParent(out entity);
		public static bool TryGetComponentInChildren<T>(this MonoBehaviour monoBehaviour, out T entity) => monoBehaviour.gameObject.TryGetComponentInChildren(out entity);

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
		/// Get component. If missing, throw exception.
		/// </summary>
		public static T GetComponentWithException<T>(this MonoBehaviour monoBehaviour)
		{
			if (monoBehaviour.TryGetComponent(out T component))
			{
				return component;
			}
			else
			{
				throw new MissingComponentException(typeof(T), monoBehaviour);
			}
		}

		/// <summary>
		/// Execute task after specified frame coutn.
		/// </summary>
		/// <param name="mono"></param>
		/// <param name="time"></param>
		/// <param name="task"></param>
		public static Coroutine ExecuteAfterFrame(this MonoBehaviour mono, Action task, int frameCount = 1)
		{
			return mono.StartCoroutine(ExecuteAfterFrameCoroutine(task, frameCount));
		}

		static IEnumerator ExecuteAfterFrameCoroutine(Action task, int frameCount)
		{
			for (int i = 0; i < frameCount; i++)
			{
				yield return new WaitForEndOfFrame();
			}

			task();
		}

		/// <summary>
		/// Get component. If no component is attached, add one.
		/// </summary>
		public static T GetOrAddComponent<T>(this MonoBehaviour monoBehaviour) where T : Component
		{
			return monoBehaviour.gameObject.GetOrAddComponent<T>();
		}
	}

}