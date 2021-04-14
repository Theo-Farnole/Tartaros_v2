using UnityEngine;
using System.Linq;

namespace Tartaros
{
	public static class ObjectsFinder
	{
		public static T[] FindObjectsOfInterface<T>()
		{
			return Object.FindObjectsOfType<MonoBehaviour>().OfType<T>().ToArray();
		}
	}
}
