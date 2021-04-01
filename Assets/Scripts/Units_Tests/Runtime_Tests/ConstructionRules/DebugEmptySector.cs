namespace Tartaros.Tests
{
	using UnityEngine;
	using Tartaros.Sectors;
	using Tartaros.Economy;
    using System;

    internal class DebugEmptySector : ISector
	{
		GameObject[] ISector.ObjectsInSector => throw new System.NotImplementedException();

		bool ISector.IsCaptured { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		ISectorResourcesWallet ISector.CapturePrice => throw new System.NotImplementedException();

        event EventHandler<CapturedArgs> ISector.Captured
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

     

        bool ISector.ContainsPosition(Vector3 worldPosition)
		{
			throw new System.NotImplementedException();
		}
	}
}