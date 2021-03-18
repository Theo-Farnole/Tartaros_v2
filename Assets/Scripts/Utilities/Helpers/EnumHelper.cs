namespace Tartaros
{
	using System;

	public static class EnumHelper
	{
		public static T[] GetValues<T>() where T : Enum
		{
			return (T[])Enum.GetValues(typeof(T));
		}
	}
}
