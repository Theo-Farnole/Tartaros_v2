namespace Tartaros
{
	using System;

	public class MissingDatabaseReference<T> : Exception
	{
		public MissingDatabaseReference(object sender) : base(string.Format("Missing database {0} in {1}.", typeof(T), sender.ToString()))
		{

		}
	}
}
