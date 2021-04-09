namespace Tartaros.Map
{
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class PlayerStartSector : MonoBehaviour
	{
		private void Start()
		{
			IMap map = Services.Instance.Get<IMap>();
			ISectorsCaptureManager captureSector = Services.Instance.Get<ISectorsCaptureManager>();

			ISector sector = map.GetSectorOnPosition(transform.position);
			captureSector.ForceCapture(sector);
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "red-flag.png");
		}
	}
}
