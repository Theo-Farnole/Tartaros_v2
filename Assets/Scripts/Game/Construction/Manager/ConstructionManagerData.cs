namespace Tartaros.Construction
{
	using Sirenix.OdinInspector;
	using System.Linq;
	using Tartaros.Entities;
	using UnityEngine;

	public partial class ConstructionManagerData : SerializedScriptableObject
	{
		[SerializeField]
		[AssetsOnly]
		[ValidateInput("ValidateConstructables")]
		private EntityData[] _constructables = null;

		public IConstructable[] Constructables => _constructables.Where(x => x.HasBehaviour<IConstructable>()).Select(x => x.GetBehaviour<IConstructable>()).ToArray();
	}

#if UNITY_EDITOR
	public partial class ConstructionManagerData
	{
		private bool ValidateConstructables(EntityData[] entityData)
		{
			return entityData.Where(x => x.HasBehaviour<IConstructable>()).Count() == entityData.Length;
		}
	}
#endif
}