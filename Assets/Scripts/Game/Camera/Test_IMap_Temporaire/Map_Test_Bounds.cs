namespace Tartaros.Map
{
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public class Map_Test_Bounds : MonoBehaviour, IMap
	{
		#region Fields
		[SerializeField]
		private Bounds2D _bounds2D = new Bounds2D(-100, 100, -100, 100);
		#endregion Fields

		#region Properties
		Bounds2D IMap.MapBounds => _bounds2D;

		ISector[] IMap.Sectors => throw new System.NotImplementedException();
		#endregion Properties

		#region Methods
		private void OnDrawGizmos()
		{
			_bounds2D.DrawGizmos();
		}

		ISector IMap.GetSectorOnPosition(Vector3 position)
		{
			throw new System.NotImplementedException();
		}

		bool IMap.CanBuild(Vector3 buildingPosition, Vector2 buildingSize)
		{
			return true;
		}

		bool IMap.IsSectorNeightborOfCapturedSectors(ISector sector)
		{
			throw new System.NotImplementedException();
		}
		#endregion Methods
	}

}