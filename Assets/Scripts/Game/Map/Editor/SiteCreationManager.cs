namespace Tartaros.Map.Editor
{
	using UnityEditor;
	using UnityEngine;

	public class SiteCreationManager
	{
		#region Fields
		private const float HANDLE_SITE = .1f;

		private readonly Map _map = null;
		private readonly SiteDrawer _siteDrawer = null;
		private readonly WaypointPositionInput _waypointPositionInput = null;

		private Site _pendingCreationSite = null;
		#endregion Fields

		#region Properties
		public bool IsCreatingSite => _pendingCreationSite != null;
		#endregion Properties

		#region Ctor
		public SiteCreationManager(Map map, SiteDrawer siteDrawer)
		{
			_map = map;
			_siteDrawer = siteDrawer;
			_waypointPositionInput = new WaypointPositionInput();
		}
		#endregion Ctor

		#region Methods
		public void Update()
		{
			if (_pendingCreationSite == null) return;

			HideGizmosTool();

			DrawVerticesButtons();

			if (_pendingCreationSite != null && _pendingCreationSite.VerticesCount > 0)
			{
				DrawLineFromLastVertexToCursor();

				if (ShouldAddVertex())
				{
					AddVertexOnCursorPosition();
				}
			}

			DrawSite();
		}

		public void DrawGUI()
		{
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

		private static bool ShouldAddVertex()
		{
			return Event.current.type == EventType.MouseDown && Event.current.button == 0;
		}

		private void DrawLineFromLastVertexToCursor()
		{
			Handles.color = Color.blue;
			Handles.DrawLine(_pendingCreationSite.LastVertex.Position, _waypointPositionInput.GetPositionUnderCursor());
		}

		private void DrawSite()
		{
			if (_pendingCreationSite == null) return;

			_siteDrawer.lineColor = Color.green;
			_siteDrawer.DrawSite(_pendingCreationSite);
		}

		private static void HideGizmosTool()
		{
			HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
		}

		private void DrawVerticesButtons()
		{
			foreach (Vertex vertex in _map.MapData.Vertices)
			{
				bool clickOnHandle = Handles.Button(vertex.Position, Quaternion.identity, HANDLE_SITE, HANDLE_SITE, Handles.RectangleHandleCap);

				if (clickOnHandle == true)
				{
					AddAlreadyExistingVertex(vertex);
				}
			}
		}

		private void AddAlreadyExistingVertex(Vertex vertex)
		{
			if (_pendingCreationSite.IsVertexFirstWaypoint(vertex) == true)
			{
				ValidatePendingSite();
			}
			else
			{
				_pendingCreationSite.AddVertex(vertex);
			}
		}

		private void AddVertexOnCursorPosition()
		{
			_pendingCreationSite.AddVertex(new Vertex(_waypointPositionInput.GetPositionUnderCursor()));
		}

		private void ValidatePendingSite()
		{
			if (_pendingCreationSite == null) throw new System.NotSupportedException();

			Undo.RecordObject(_map.MapData, "Add site");

			_map.MapData.AddSite(_pendingCreationSite);
			_pendingCreationSite = null;

			EditorUtility.SetDirty(_map);
		}
		#endregion Methods
	}
}
