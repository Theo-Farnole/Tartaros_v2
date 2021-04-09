namespace Tartaros
{
	using System;

	public class MissingDataReference<T> : Exception
	{
		public MissingDataReference(object sender) : base(string.Format("Missing data {0} in {1}.", typeof(T).Name, sender.ToString()))
		{

		}
	}
}
