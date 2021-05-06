namespace Tartaros.Construction
{
	using UnityEngine;

	public static class IConstructableExtensions
	{
		public static GameObject InstantiateConstructionKit(this IConstructable constructable, Vector3 constructionPosition)
		{
			GameObject constructionKit = GameObject.Instantiate(constructable.ConstructionKitModel, constructionPosition, Quaternion.identity);
			ConstructionDelay constructionDelay = constructionKit.GetComponent<ConstructionDelay>();

			constructionDelay.Constructable = constructable;

			return constructionKit;
		}
	}
}
