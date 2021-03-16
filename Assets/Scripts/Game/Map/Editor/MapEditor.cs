﻿namespace Tartaros.Map.Editor
{
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(Map))]
	public class MapEditor : Editor
	{
		#region Fields
		private const float HANDLE_SITE = .1f;
		private const float SITE_COLOR_OPACITY = 0.5f;
		private static readonly Quaternion HANDLE_ROTATION = Quaternion.Euler(90, 0, 0);

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
			foreach (var site in Map.MapData.Sites)
			{
				_siteDrawer.lineColor = color;
				_siteDrawer.DrawSite(site);
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
				Undo.RecordObject(target, "Free Move LookAt Point");
				vertex.Position = position;
			}
		}
		#endregion Methods
	}
}
