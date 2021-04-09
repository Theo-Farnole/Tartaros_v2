namespace Tartaros
{
	using UnityEngine;

	public interface IContainable
	{
		bool ContainsPosition(Vector3 worldPosition);
	}
}
