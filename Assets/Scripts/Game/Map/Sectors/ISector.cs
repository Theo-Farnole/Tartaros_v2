namespace Tartaros.Sectors
{
	using Tartaros.Economy;
	using Tartaros.Math;
	using UnityEngine;

	public interface ISector
	{
		bool IsCaptured { get; set; }
		GameObject[] ObjectsInSector { get; }
		ISectorResourcesWallet CapturePrice { get; }
		bool ContainsPosition(Vector3 worldPosition);
	}
}
