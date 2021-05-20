namespace Tartaros.Construction
{
	using UnityEngine;

	public static class IConstructableExtensions
	{
		public static GameObject InstantiateConstructionKit(this IConstructable constructable, Vector3 constructionPosition)
		{
			return InstantiateConstructionKit(constructable, constructionPosition, Quaternion.identity);
		}

		public static GameObject InstantiateConstructionKit(this IConstructable constructable, Vector3 constructionPosition, Quaternion rotation)
		{
			GameObject constructionKit = GameObject.Instantiate(constructable.ConstructionKitModel, constructionPosition, rotation);
			ConstructionDelay constructionDelay = constructionKit.GetComponent<ConstructionDelay>();

			constructionDelay.Constructable = constructable;

			return constructionKit;
		}
	}
}
