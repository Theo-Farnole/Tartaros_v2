namespace Tartaros.Map.Editor
{
	using System.Collections.Generic;
	using Tartaros.Math;
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(Map))]
	public class MapEditor : Editor
	{
		#region Fields
		public const float HANDLE_SITE = .1f;
		public static readonly Quaternion HANDLE_ROTATION = Quaternion.Euler(90, 0, 0);

		private SiteCreationManager _siteCreationManager = null;
		private SiteDrawer _siteDrawer = null;
		#endregion Fields

		#region Properties
		public Map Map => target as Map;

		#endregion Properties

		#region Methods
		private void OnEnable()
		{
			_siteDrawer = new SiteDrawer();
			_siteCreationManager = new SiteCreationManager(Map, _siteDrawer);
		}

		public void OnSceneGUI()
		{
			ForceRedraw();

			if (DoVerticesMoveHandleShouldBeDraw())
			{
				DrawVerticesMoveHandle();
			}

			DrawSites(Color.white);
			DrawGUI();

			_siteCreationManager.Update();
		}

		private static void ForceRedraw()
		{
			if (Event.current.type == EventType.Repaint)
			{
				SceneView.RepaintAll();
			}
		}

		private bool DoVerticesMoveHandleShouldBeDraw()
		{
			return _siteCreationManager.IsCreatingSite == false;
		}

		private void DrawSites(Color color)
		{
			for (int i = 0; i < Map.MapData.Sectors.Length; i++)
			{
				SectorData site = Map.MapData.Sectors[i];
				_siteDrawer.lineColor = color;
				_siteDrawer.DrawSite(site, i.ToString());
			}
		}

		private void DrawGUI()
		{
			Handles.BeginGUI();
			{
				GUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(false));
				{
					GUILayout.Label("Map Editor", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));

					_siteCreationManager.DrawGUI();

					if (GUILayout.Button("Check for errors", GUILayout.Width(150)))
					{
						MapErrorsChecker.HasErrors(Map);
					}
				}
				GUILayout.EndVertical();
			}
			Handles.EndGUI();
		}

		private void DrawVerticesMoveHandle()
		{
			foreach (Vertex vertex in Map.MapData.Vertices)
			{
				DrawVertexMoveHandle(vertex);
			}
		}

		private void DrawVertexMoveHandle(Vertex vertex)
		{
			EditorGUI.BeginChangeCheck();

			Vector3 position = Handles.FreeMoveHandle(vertex.Position, HANDLE_ROTATION, HANDLE_SITE, vertex.Position, Handles.RectangleHandleCap);

			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(Map.MapData, "Move position");

				vertex.Position = position;
				EditorUtility.SetDirty(Map.MapData);
			}
		}
		#endregion Methods
	}
}
