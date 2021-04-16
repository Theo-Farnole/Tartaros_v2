namespace Tartaros.Construction
{
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.UI;
	using UnityEngine;

	public class CheckObjectUnderCursorManager
	{

		private IConstructable _toBuild = null;

		public CheckObjectUnderCursorManager(IConstructable toBuild)
		{
			_toBuild = toBuild;
		}

		public GameObject GetObjectUnderCursor()
		{
			GameObject objectUnderCursor = MouseHelper.GetGameObjectUnderCursor();
			if (objectUnderCursor != null && objectUnderCursor.TryGetComponentInParent(out Entity entity))
			{
				return entity.gameObject;
			}
			Debug.LogError("There is no entity to return");
			return null;
		}

		public bool IsTheSameConstructable()
		{
			GameObject objectUnderCursor = MouseHelper.GetGameObjectUnderCursor();

			if (objectUnderCursor != null
				&& objectUnderCursor.TryGetComponentInParent(out Entity entity)
				&& entity.EntityData.TryGetBehaviour<EntityConstructableData>(out EntityConstructableData data))
			{
				IConstructable constructable = entity.EntityData.GetBehaviour<EntityConstructableData>() as IConstructable;
				if (constructable == _toBuild)
				{
					return true;
				}
			}
			return false;
		}

		public Entity GetEntityUnderCursor()
		{
			return GetObjectUnderCursor().GetComponent<Entity>();
		}
	}
}