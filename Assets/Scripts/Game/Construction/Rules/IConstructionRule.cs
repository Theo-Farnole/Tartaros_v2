namespace Tartaros.Map
{
	using UnityEngine;

	public interface IConstructionRule
	{
		bool CanConstruct(Vector3 position);
	}
}
