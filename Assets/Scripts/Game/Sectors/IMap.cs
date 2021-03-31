namespace Tartaros.Sectors
{
	using UnityEngine;
	using Tartaros.Utilities;
	using Tartaros.Map;

	public interface IMap
	{
		Bounds2D MapBounds { get; }
		ISector[] Sectors { get; }

		bool CanBuild(Vector3 buildingPosition, Vector2 buildingSize);
		ISector GetSectorOnPosition(Vector3 position);

		bool IsSectorNeightborOfCapturedSectors(ISector sector);
	}
}