namespace Tartaros.Entities
{
	using Tartaros.Entities.Detection;
	using Tartaros.FogOfWar;
	using UnityEngine;

	public class ConfigureVisionFromDetectionRange : MonoBehaviour
	{
		private void Start()
		{
			var fogCircle = GetComponent<FogCircleVision>();
			var viewRadius = GetComponent<Entity>().EntityData.GetBehaviour<EntityDetectionData>().DetectionRange;

			if (fogCircle != null)
			{
				fogCircle.Radius = viewRadius;
			}
		}
	}
}
