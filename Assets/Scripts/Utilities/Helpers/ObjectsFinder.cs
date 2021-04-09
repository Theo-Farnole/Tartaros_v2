using UnityEngine;
using System.Linq;

namespace Tartaros.Utilities
{
	public static class ObjectsFinder
	{
		public static T[] FindObjectsOfInterface<T>()
		{
			return Object.FindObjectsOfType<MonoBehaviour>().OfType<T>().ToArray();
		}
	}
}
