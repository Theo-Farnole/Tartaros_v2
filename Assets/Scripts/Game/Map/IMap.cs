namespace Tartaros.Map
{
	using UnityEngine;
	
	using Tartaros.Map;

	public interface IMap
	{
		Bounds2D MapBounds { get; }

		Bounds2D GameplayBounds { get; }

		ISector[] Sectors { get; }

		bool CanBuild(Vector3 buildingPosition, Vector2 buildingSize);
		ISector GetSectorOnPosition(Vector3 position);

		bool IsSectorNeightborOfCapturedSectors(ISector sector);
	}
}