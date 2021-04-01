namespace Tartaros.Sectors
{
	using System;
	using Tartaros.Economy;
	using Tartaros.Math;
	using UnityEngine;

	public class CapturedArgs : EventArgs
	{ }

	public interface ISector
	{
		event EventHandler<CapturedArgs> Captured;

		bool IsCaptured { get; set; }
		GameObject[] ObjectsInSector { get; }
		ISectorResourcesWallet CapturePrice { get; }
		bool ContainsPosition(Vector3 worldPosition);
	}
}
