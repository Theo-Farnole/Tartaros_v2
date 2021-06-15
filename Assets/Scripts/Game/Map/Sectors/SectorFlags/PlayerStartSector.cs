namespace Tartaros.Map
{
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject))]
	public class PlayerStartSector : MonoBehaviour
	{
		private IMap _map = null;
		private ISectorsCaptureManager _captureManager = null;

		private void Awake()
		{
			gameObject.GetOrAddComponent<SectorObject>();

			_map = Services.Instance.Get<IMap>();
			_captureManager = Services.Instance.Get<ISectorsCaptureManager>();
		}

		private void Start()
		{
			ISector sector = _map.GetSectorOnPosition(transform.position);
			_captureManager.ForceCapture(sector);
			//sector.IsCaptured = true;
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "red-flag.png");
		}
	}
}
