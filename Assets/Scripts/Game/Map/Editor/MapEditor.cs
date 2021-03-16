namespace Tartaros.Map.Editor
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEditor;
	using UnityEngine;
	using UnityEngine.InputSystem;

	[CustomEditor(typeof(Map))]
	public class MapEditor : Editor
	{
		#region Fields
		private const float HANDLE_SITE = .1f;
		private const float SITE_COLOR_OPACITY = 0.5f;
		private static readonly Quaternion HANDLE_ROTATION = Quaternion.Euler(90, 0, 0);

		private Site _pendingCreationSite = null;

		private MapSiteDrawer _siteDrawer = new MapSiteDrawer();
		private WaypointPositionInput _waypointPositionInput = new WaypointPositionInput();
		#endregion Fields

		#region Properties
		public Map Map => target as Map;
		public bool IsCreatingSite => _pendingCreationSite != null;
		#endregion Properties

		#region Methods
		public void OnSceneGUI()
		{
			ForceRedraw();

			if (IsCreatingSite == false)
			{
				DrawVertices();
			}

			DrawSites(Color.white);
			DrawGUI();

			ManagePendingCreationSite();
		}

		private static void ForceRedraw()
		{
			if (Event.current.type == EventType.Repaint)
			{
				SceneView.RepaintAll();
			}
		}

		private void ManagePendingCreationSite()
		{
			if (_pendingCreationSite == null) return;

			HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

			foreach (Vertex vertex in Map.MapData.Vertices)
			{
				bool clickOnHandle = Handles.Button(vertex.Position, Quaternion.identity, HANDLE_SITE, HANDLE_SITE, Handles.RectangleHandleCap);

				if (clickOnHandle == true)
				{
					if (IsVertexFirstOfNewSite(vertex) == true)
					{
						ValidatePendingSite();
					}
					else
					{
						_pendingCreationSite.AddVertex(vertex);
					}
				}
			}

			if (_pendingCreationSite.VerticesCount > 0)
			{
				Vertex lastVertex = _pendingCreationSite[_pendingCreationSite.VerticesCount - 1];
				Handles.color = Color.blue;

				Handles.DrawLine(lastVertex.Position, _waypointPositionInput.GetPositionUnderCursor());

				if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
				{
					Selection.activeObject = Map;
					_pendingCreationSite.AddVertex(new Vertex(_waypointPositionInput.GetPositionUnderCursor()));
				}
			}

			_siteDrawer.lineColor = Color.green;
			_siteDrawer.DrawSite(_pendingCreationSite);
		}

		private void ValidatePendingSite()
		{
			if (_pendingCreationSite == null) throw new System.NotSupportedException();

			Map.MapData.AddSite(_pendingCreationSite);
			_pendingCreationSite = null;
		}

		private bool IsVertexFirstOfNewSite(Vertex vertex)
		{
			return _pendingCreationSite.VerticesCount > 1 && vertex == _pendingCreationSite[0];
		}

		private void DrawSites(Color color)
		{
			foreach (var site in Map.MapData.Sites)
			{
				_siteDrawer.lineColor = color;
				_siteDrawer.DrawSite(site);
			}
		}

		private void DrawVertices()
		{
			foreach (Vertex vertex in Map.MapData.Vertices)
			{
				DrawVertex(vertex);
			}
		}

		private void DrawGUI()
		{
			Handles.BeginGUI();
			{
				GUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(false));
				{
					GUILayout.Label("Map Editor", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));

					if (IsCreatingSite)
					{
						if (GUILayout.Button("Cancel sector editing", GUILayout.Width(100)))
						{
							_pendingCreationSite = null;
						}
					}
					else
					{
						if (GUILayout.Button("Add new sector", GUILayout.Width(100)))
						{
							_pendingCreationSite = new Site();
							Tools.current = Tool.None;
						}
					}
				}
				GUILayout.EndVertical();
			}
			Handles.EndGUI();
		}

		private void DrawVertex(Vertex vertex)
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
