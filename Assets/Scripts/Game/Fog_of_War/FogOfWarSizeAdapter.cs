namespace Tartaros.FogOfWar
{
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class FogOfWarSizeAdapter : MonoBehaviour
	{
		#region Fields
		[SerializeField] private Camera[] _cameras = new Camera[0];
		[SerializeField] private Projector _projector = null;

		private IMap _map = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();
		}

		private void Start()
		{
			AdaptSize();
		}

		private void AdaptSize()
		{
			Bounds2D mapBounds = _map.MapBounds;

			float orthographicSize = Mathf.Max(mapBounds.boundsX.Size, mapBounds.boundsY.Size) / 2;
			Vector3 centerPosition = new Vector3(mapBounds.CenterX, 10, mapBounds.CenterY);

			foreach (Camera camera in _cameras)
			{
				camera.orthographicSize = orthographicSize;
				camera.transform.position = centerPosition;
			}

			_projector.orthographicSize = orthographicSize;
			_projector.transform.position = centerPosition;
		}
		#endregion Methods
	}
}