namespace Tartaros
{
	using Tartaros.Dialogue;
	using Tartaros.Map;
	using Tartaros.Map.Village;
	using UnityEngine;

	public static class CameraFocusExtensions
	{
		public static Vector3? GetDestination(this CameraFocus cameraFocus)
		{
			switch (cameraFocus)
			{
				case CameraFocus.None:
					return null;

				case CameraFocus.FirstVillage:
					return Object.FindObjectOfType<Village>().transform.position;

				case CameraFocus.Poseidon:
					return Object.FindObjectOfType<SpecialSector>().transform.position;

				default:
					throw new System.NotImplementedException(cameraFocus.ToString());
			}
		}
	}
}