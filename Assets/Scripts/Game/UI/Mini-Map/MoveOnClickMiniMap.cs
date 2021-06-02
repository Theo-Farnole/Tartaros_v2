namespace Tartaros.UI.MiniMap
{
	using System.Collections;
	using Tartaros.CameraSystem;
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
			var worldPosition = _miniMap.UIToWorldPosition(mapPosition);
			Debug.DrawRay(worldPosition, Vector3.up * 50, Color.red, Mathf.Infinity);

			if(worldPosition != null)
			{
				_camera.GetComponent<CameraController>().MoveCameraAtTargetPosition(worldPosition);
			}

			Debug.Log(worldPosition);
		}

		private Vector3 GetWorldPosition(Vector2 mapPosition)
		{
			

			return Vector3.zero;
		}
	}
}