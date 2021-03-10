namespace Tartaros.ServicesLocator
{
	using System;

	public class MissingServiceException<TMissingService> : Exception
	{
		public MissingServiceException()
			: base(string.Format("The service {0} is missing. Please, register it in Services.", typeof(TMissingService).Name))
		{
		}
	}
}
