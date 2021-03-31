namespace Tartaros.Construction
{
	using UnityEngine;

	public interface IConstructionRule
	{
		bool CanConstruct(Vector3 position);
		string ErrorMessage { get; }
	}
}
