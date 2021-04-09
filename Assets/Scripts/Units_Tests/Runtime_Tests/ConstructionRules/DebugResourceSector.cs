namespace Tartaros.Tests
{
	using System;
	using Tartaros.Economy;
	using Tartaros.Map;
	using UnityEngine;

	internal class DebugResourceSector : ISector
	{
		#region Fields
		[SerializeField]
		private SectorRessourceType resourceType = SectorRessourceType.Food;

		private FlagResourceToSector _flagResourceToSector = null;
		#endregion Fields

		#region Ctor
		public DebugResourceSector(SectorRessourceType _resourceType)
		{
			this.resourceType = _resourceType;

			string name = string.Format("Resource {0}", _resourceType.ToString());
			_flagResourceToSector = new GameObject(name).AddComponent<FlagResourceToSector>();
			_flagResourceToSector.Type = _resourceType;
		}

		~DebugResourceSector()
		{
			GameObject.Destroy(_flagResourceToSector.gameObject);
		}
		#endregion Ctor

		#region Methods
		GameObject[] ISector.ObjectsInSector => new GameObject[]
		{
			_flagResourceToSector.gameObject
		};

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
		#endregion Methods
	}
}