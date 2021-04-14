namespace Tartaros
{
	/// <summary>
	/// Implement this interface to receive pool objects callbacks.
	/// </summary>
	public interface IObjectPooleable
	{
		void OnObjectReused();
		void OnObjectRelease();
	}

}