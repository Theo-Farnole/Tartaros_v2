namespace Tartaros
{
	using System.Collections;
	using System.Linq;
	using Tartaros.Selection;
	using UnityEngine;

	public static class SelectionHelper 
	{
		public static ISelectable[] KeepSelectablesInRectangle(ISelectable[] selectablesToFiltrer, Bounds bounds)
		{
			// We cache variables for performance reasons
			Camera camera = Camera.main;
			Bounds selectionRect = bounds;

			ISelectable[] selectablesInRectangle = selectablesToFiltrer
				.Where(selectable => camera.IsInWorldPointInBounds(selectionRect, selectable.Position))
				.ToArray();

			return selectablesInRectangle;
		}
	}
}