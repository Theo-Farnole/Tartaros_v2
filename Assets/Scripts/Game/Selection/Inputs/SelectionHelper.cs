namespace Tartaros
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Selection;
	using UnityEngine;

	public static class SelectionHelper 
	{
		public static ISelectable[] GetSelectablesInRectangle(ISelectable[] selectablesToFiltrer, Bounds bounds)
		{
			// We cache variables for performance reasons
			Camera camera = Camera.main;
			Bounds selectionRect = bounds;

			ISelectable[] selectablesInRectangle = selectablesToFiltrer
				.Where(selectable => camera.IsInWorldPointInBounds(selectionRect, selectable.Position))
				.ToArray();			

			return selectablesInRectangle;
		}

		public static ISelectable[] GetSelectablesOfTheSameData(ISelectable entitySelected, ISelectable[] selectableInRectangle)
		{
			var entityData = entitySelected.GameObject.GetComponent<Entity>().EntityData;
			List<ISelectable> selectablesSameData = new List<ISelectable>();

			foreach (var selectable in selectableInRectangle)
			{
				var selectableData = selectable.GameObject.GetComponent<Entity>().EntityData;

				if(selectableData == entityData)
				{
					selectablesSameData.Add(selectable);
				}
			}

			return selectablesSameData.ToArray();
		}
	}
}