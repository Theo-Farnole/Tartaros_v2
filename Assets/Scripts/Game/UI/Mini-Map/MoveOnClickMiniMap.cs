namespace Tartaros.UI.MiniMap
{
	using System.Collections;
	using UnityEngine;

	public class MoveOnClickMiniMap : MonoBehaviour
	{
		private Camera _camera = null;
		private MiniMap _miniMap = null;

		private void Awake()
		{
			_camera = Camera.main;
			_miniMap = GetComponent<MiniMap>();
		}


		public void MoveCameraOnPosition(Vector2 mapPosition)
		{
			var test = _miniMap.UIToWorldPosition(mapPosition);

			Debug.Log(test);
		}

		private Vector3 GetWorldPosition(Vector2 mapPosition)
		{
			

			return Vector3.zero;
		}
	}
}