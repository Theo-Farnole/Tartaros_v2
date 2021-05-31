namespace Tartaros.Wave
{
	using Sirenix.OdinInspector.Editor;
	using System.Collections;
	using Tartaros.Editor;
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(SpawnPoint))]
	public class SpawnPointEditor : OdinEditor
	{
		public const float HANDLE_SIZE = 0.5f;
		public static readonly Color HANDLE_COLOR = Color.red;
		public static readonly Quaternion HANDLE_ROTATION = Quaternion.Euler(90, 0, 0);

		#region Properties
		public SpawnPoint Spawn => target as SpawnPoint;
		#endregion Properties




		private void OnSceneGUI()
		{
			
		}

		private void DrawVerticesMoveHandle()
		{
			//foreach (Vector3 vertex in Spawn.)
			//{
			//	DrawVertexMoveHandle(vertex);
			//}


		}

		private void DrawVertexMoveHandle(Vector3 vertex)
		{
			//EditorGUI.BeginChangeCheck();

			//HandlesHelper.PushColor(HANDLE_COLOR);
			//Vector3 position = Handles.FreeMoveHandle(vertex, HANDLE_ROTATION, HANDLE_SIZE, vertex, Handles.DotHandleCap);
			//HandlesHelper.PopColor();

			//if (EditorGUI.EndChangeCheck())
			//{
			//	Undo.RecordObject(Map.MapData, "Move position");

			//	vertex.WorldPosition = position;
			//	EditorUtility.SetDirty(Map.MapData);
			//}
		}

	}
}