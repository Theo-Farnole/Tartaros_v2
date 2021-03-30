namespace Tartaros.Map.Editor
{
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	public class MapDrawerManager
	{
		#region Fields
		private static Dictionary<Map, MapSitesDrawer> _drawers = new Dictionary<Map, MapSitesDrawer>();
		#endregion Fields

		#region Methods
		[DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Active)]
		public static void RenderCustomGizmo(Map map, GizmoType gizmoType)
		{
			if (ShouldCreateDrawer(map) == true)
			{
				Debug.LogFormat("Create drawer of {0}.", map);

				MapSitesDrawer drawer = new MapSitesDrawer(map);
				_drawers.Add(map, drawer);
			}

			if (_drawers.ContainsKey(map) == true && _drawers[map] != null)
			{
				_drawers[map].CanEdit = Selection.Contains(map);
				_drawers[map].Draw();
			}
		}

		private static bool ShouldCreateDrawer(Map item)
		{
			if (_drawers.ContainsKey(item))
			{
				return _drawers[item] == null;
			}
			else
			{
				return true;
			}
		}
		#endregion Methods
	}
}
