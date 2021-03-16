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

		private MapSiteDrawer _siteDrawer = new MapSiteDrawer();

		private Site _pendingCreationSite = null;
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

				Handles.DrawLine(lastVertex.Position, GetPositionUnderCursor());

				if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
				{
					Selection.activeObject = Map;
					_pendingCreationSite.AddVertex(new Vertex(GetPositionUnderCursor()));
				}
			}

			_siteDrawer.lineColor = Color.green;
			_siteDrawer.DrawSite(_pendingCreationSite);
		}

		private Vector3 GetPositionUnderCursor()
		{
			Camera camera = Camera.current;

			if (camera == null) throw new System.NotSupportedException();

			// the Y position is flipped, so we have to account for that
			// we also have to account for parts above the "Scene" window
			Vector2 mousePosition = new Vector2(
			   Event.current.mousePosition.x,
			   Screen.height - (Event.current.mousePosition.y + 45)
			);

			Plane plane = new Plane(Vector3.back, 0 - camera.transform.position.z);
			Ray ray = camera.ScreenPointToRay(mousePosition);

			if (plane.Raycast(ray, out float distance))
			{
				Vector3 hitPoint = ray.GetPoint(distance);
				return hitPoint;
			}
			else
			{
				Debug.LogError("NOT SUPPORTED");
				return Vector3.zero;
			}
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
