namespace Tartaros.UI.MiniMap
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class FrustumCameraMiniMap : MonoBehaviour
	{
		[SerializeField]
		private MiniMap _miniMap = null;
		[SerializeField]
		private GameObject _mapBackground = null;
		[SerializeField]
		private GameObject _navigationLine = null;

		private Camera _camera = null;
		private Vector3 _planeDistanceFromCamera = Vector3.zero;
		private Plane _plane;
		private RectTransform _rootTransform = null;
		private DrawLineUI _drawLine = null;

		private void Update()
		{
			UpdateLineUIPosition();
		}

		private void StartSetUp()
		{
			_camera = Camera.main;
			_rootTransform = _miniMap.RootTransform;
			InstanciatePlane();
		}

		private void InstanciatePlane()
		{
			_planeDistanceFromCamera = Vector3.zero;
			_plane = new Plane(Vector3.up, _planeDistanceFromCamera);
		}

		private Vector3[] GetViewportCorner()
		{
			List<Vector3> listVector = new List<Vector3>();

			//topLeft
			listVector.Add(GetCameraFrustumPosition(new Vector3(0, Screen.height)));
			//topRight
			listVector.Add(GetCameraFrustumPosition(new Vector3(Screen.width, Screen.height)));
			//botRight
			listVector.Add(GetCameraFrustumPosition(new Vector3(Screen.width, 0f)));
			//botLeft
			listVector.Add(GetCameraFrustumPosition(new Vector3(0f, 0f)));
			//topLeft
			listVector.Add(GetCameraFrustumPosition(new Vector3(0, Screen.height)));

			return listVector.ToArray();
		}

		
		private Vector3 GetCameraFrustumPosition(Vector3 position)
		{
			float cameraDistance = Camera.main.transform.position.y;
			Ray positionRay = Camera.main.ScreenPointToRay(position);
			

			float enter = 0;
			if (_plane.Raycast(positionRay, out enter))
			{
				Vector3 hitPoint = positionRay.GetPoint(enter);
				return hitPoint;
			}
			else
			{
				return Vector3.zero;
			}
		}

		private List<Vector2> GetVectors2(Vector3[] corners)
		{
			List<Vector2> list = new List<Vector2>();
			foreach (Vector3 corner in corners)
			{

				list.Add(_miniMap.WordToUiPosition(corner));
			}
			return list;
		}

		public void InstanciateLineUI()
		{
			StartSetUp();

			var cameraCorners = GetVectors2(GetViewportCorner());

			GameObject cameraLine = GameObject.Instantiate(_navigationLine, _mapBackground.transform);
			_drawLine = cameraLine.GetComponent<DrawLineUI>();


			_drawLine.Setup(
				Mathf.RoundToInt(_rootTransform.rect.width),
				Mathf.RoundToInt(_rootTransform.rect.height));

			_drawLine.SetColor(Color.white);

			_drawLine.SetNavigationPoints(cameraCorners);
		}

		private void UpdateLineUIPosition()
		{
			_drawLine.ClearPoints();
			var cameraCorners = GetVectors2(GetViewportCorner());
			_drawLine.SetNavigationPoints(cameraCorners);
		}
	}
}