namespace Tartaros.Tests
{
	using UnityEngine;
	using Tartaros.Sectors;


	internal class DebugEmptySector : ISector
	{
		GameObject[] ISector.ObjectsInSector => throw new System.NotImplementedException();

		bool ISector.CanCapture()
		{
			throw new System.NotImplementedException();
		}

		void ISector.Capture()
		{
			throw new System.NotImplementedException();
		}

		bool ISector.ContainsPosition(Vector3 worldPosition)
		{
			throw new System.NotImplementedException();
		}
	}
}