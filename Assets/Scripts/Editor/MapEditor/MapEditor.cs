namespace Tartaros.Map.Editor
{
	using Sirenix.OdinInspector.Editor;
	using Tartaros.Editor;
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(Map))]
	public class MapEditor : OdinEditor
	{
		#region Fields
		public const float HANDLE_SIZE = 0.5f;
		public static readonly Color HANDLE_COLOR = Color.red;
		public static readonly Quaternion HANDLE_ROTATION = Quaternion.Euler(90, 0, 0);

		private SiteCreationManager _siteCreationManager = null;
		#endregion Fields

		#region Properties
		public Map Map => target as Map;
		#endregion Properties

		#region Methods
		protected override void OnEnable()
		{
			base.OnEnable();

			_siteCreationManager = new SiteCreationManager(Map);
		}

		private void OnSceneGUI()
		{
			if (Map.MapData == null) return;

			if (DoVerticesMoveHandleShouldBeDraw())
			{
				DrawVerticesMoveHandle();
			}

			_siteCreationManager.Update();
			DrawGUI();
		}

		private bool DoVerticesMoveHandleShouldBeDraw()
		{
			return _siteCreationManager.IsCreatingSite == false;
		}

		private void DrawVerticesMoveHandle()
		{
			foreach (Vertex2D vertex in Map.MapData.Vertices)
			{
				DrawVertexMoveHandle(vertex);
			}
		}

		private void DrawVertexMoveHandle(Vertex2D vertex)
		{
			EditorGUI.BeginChangeCheck();

			HandlesHelper.PushColor(HANDLE_COLOR);
			Vector3 position = Handles.FreeMoveHandle(vertex.WorldPosition, HANDLE_ROTATION, HANDLE_SIZE, vertex.WorldPosition, Handles.DotHandleCap);
			HandlesHelper.PopColor();

			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(Map.MapData, "Move position");

				vertex.WorldPosition = position;
				EditorUtility.SetDirty(Map.MapData);
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
		#endregion Methods

	}
}
