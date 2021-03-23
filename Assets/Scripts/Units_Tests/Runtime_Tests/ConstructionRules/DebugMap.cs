namespace Tartaros.Tests
{
	using System.Collections.Generic;
	using Tartaros.Sectors;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	internal class DebugMap : IMap
	{
		#region Fields
		private Dictionary<Vector3, ISector> _sectors = null;
		private Services _services = null;
		#endregion Fields

		#region Properties
		Bounds2D IMap.MapBounds => throw new System.NotImplementedException();
		#endregion Properties

		#region Ctor
		public DebugMap(Services services, Dictionary<Vector3, ISector> sectors)
		{
			_sectors = sectors.Clone();
			_services = services;

			_services.RegisterService<IMap>(this);
		}

		~DebugMap()
		{
			_services.UnregisterService<IMap>();			
		}
		#endregion Ctor

		#region Methods
		bool IMap.CanBuild(Vector2 buildingPosition, Vector2 buildingSize)
		{
			throw new System.NotImplementedException();
		}

		ISector IMap.GetSectorOnPosition(Vector3 position)
		{
			if (_sectors.TryGetValue(position, out ISector value))
			{
				return value;
			}
			else
			{
				Debug.LogFormat("No sector found at position {0}.", position);
				return null;
			}
		}
		#endregion Methods
	}
}