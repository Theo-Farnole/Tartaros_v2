namespace Tartaros
{
	using System;

	public class NoSingletonInstanceFound<T> : Exception
	{
		public NoSingletonInstanceFound()
			: base(string.Format("Missing singleton instance. Please add a {0} component in the Unity Scene.", typeof(T).Name))
		{
		}
	}
}
