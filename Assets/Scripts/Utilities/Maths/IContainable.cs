namespace Tartaros
{
	using UnityEngine;

	public interface IContainable
	{
		public bool ContainsPosition(Vector3 worldPosition);
	}
}
