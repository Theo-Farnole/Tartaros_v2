namespace Tartaros.Sectors
{
	using Tartaros.Math;
	using UnityEngine;

	public interface ISector
	{
		GameObject[] ObjectsInSector { get; }
		bool ContainsPosition(Vector3 worldPosition);
		bool CanCapture();
		void Capture();
	}
}
