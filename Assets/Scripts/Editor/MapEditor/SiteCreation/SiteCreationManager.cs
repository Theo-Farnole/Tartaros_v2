namespace Tartaros.Map.Editor
{
	using Tartaros.Editor;
	using UnityEditor;
	using UnityEngine;

	public class SiteCreationManager
	{
		#region Fields
		private const float HANDLE_SIZE = .1f;
		private readonly Color HANDLE_COLOR = Color.green;
		private readonly Quaternion HANDLE_ROTATION = Quaternion.Euler(90, 0, 0);

		private readonly Map _map = null;
		private readonly WaypointPositionInput _waypointPositionInput = null;
		private SiteDrawer _siteDrawer = null;

		private SectorData _pendingCreationSite = null;
		#endregion Fields

		#region Properties
		public bool IsCreatingSite => _pendingCreationSite != null;
		#endregion Properties

		#region Ctor
		public SiteCreationManager(Map map)
		{
			_map = map;
			_siteDrawer = new SiteDrawer();
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
				if (GUILayout.Button("Cancel sector editing", GUILayout.Width(150)))
				{
					CancelCreation();
				}
			}
			else
			{
				if (GUILayout.Button("Add new sector", GUILayout.Width(150)))
				{
					StartCreation();
				}
			}
		}

		private void StartCreation()
		{
			_pendingCreationSite = new SectorData();
			Tools.current = Tool.None;
		}

		private void CancelCreation()
		{
			_pendingCreationSite = null;
			Tools.current = Tool.Move;
		}

		private static bool ShouldAddVertex()
		{
			return Event.current.type == EventType.MouseDown && Event.current.button == 0;
		}

		private void DrawLineFromLastVertexToCursor()
		{
			Handles.color = Color.blue;
			Handles.DrawLine(_pendingCreationSite.LastVertex.WorldPosition, _waypointPositionInput.GetPositionUnderCursor());
		}

		private void DrawSite()
		{
			if (_pendingCreationSite == null) return;

			_siteDrawer.lineColor = Color.green;
			_siteDrawer.DrawBorders(_pendingCreationSite);
			_siteDrawer.DrawColorInsideBorders(_pendingCreationSite);
		}

		private static void HideGizmosTool()
		{
			HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
		}

		private void DrawVerticesButtons()
		{
			foreach (Vertex2D vertex in _map.MapData.Vertices)
			{
				Handles.color = Color.white;

				HandlesHelper.PushColor(HANDLE_COLOR);
				bool clickOnHandle = Handles.Button(vertex.WorldPosition, HANDLE_ROTATION, HANDLE_SIZE, HANDLE_SIZE, Handles.DotHandleCap);
				HandlesHelper.PopColor();

				if (clickOnHandle == true)
				{
					AddAlreadyExistingVertex(vertex);
				}
			}
		}

		private void AddAlreadyExistingVertex(Vertex2D vertex)
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
			_pendingCreationSite.AddVertex(new Vertex2D(_waypointPositionInput.GetPositionUnderCursor()));
		}

		private void ValidatePendingSite()
		{
			if (_pendingCreationSite == null) throw new System.NotSupportedException();

			Undo.RecordObject(_map.MapData, "Add site");

			_map.MapData.AddSector(_pendingCreationSite);
			_pendingCreationSite = null;
			Tools.current = Tool.Move;

			EditorUtility.SetDirty(_map);
		}
		#endregion Methods
	}
}
