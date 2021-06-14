namespace Tartaros.Wave
{
	using Sirenix.OdinInspector.Editor;
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(SpawnPoint))]
	public class SpawnPointEditor : OdinEditor
	{
		private Vector3[] _editingWaypoints = null;

		#region Properties
		public SpawnPoint SpawnPoint => target as SpawnPoint;
		#endregion Properties


		#region Methods
		private void OnSceneGUI()
		{
			EditorGUI.BeginChangeCheck();

			_editingWaypoints = DrawWaypointsHandles();

			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(SpawnPoint, "Moving waypoints");
				SpawnPoint.Waypoints = _editingWaypoints;
			}
		} 

		private Vector3[] DrawWaypointsHandles()
		{
			Vector3[] waypoints = SpawnPoint.Waypoints;
			Vector3[] output = new Vector3[waypoints.Length];

			for (int i = 0, length = waypoints.Length; i < length; i++)
			{
				output[i] = Handles.PositionHandle(waypoints[i], Quaternion.identity);
			}

			return output;
		}
		#endregion Methods
	}
}