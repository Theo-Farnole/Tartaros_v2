namespace Tartaros
{
	using UnityEngine;

	public static class InterfaceExtensions
	{
		public static bool IsInterfaceDestroyed<T>(this T @interface) where T : class
		{
			if (@interface == null) return true;

			if (@interface is MonoBehaviour monoBehaviour)
			{
				return monoBehaviour == null;
			}
			else
			{
				throw new System.NotSupportedException("Interface {0} cannot be casted to a MonoBehaviour.".Format(@interface.GetType()));
			}
		}
	}
}
