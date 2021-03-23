namespace Tartaros.Tests
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using NUnit.Framework;
	using Tartaros.Economy;
	using Tartaros.Map;
	using Tartaros.Sectors;
	using Tartaros.Utilities;

	public class SpecificResourceTypeRule_Tests
	{
		#region Fields
		private class DebugMap : IMap
		{
			Bounds2D IMap.MapBounds => throw new System.NotImplementedException();

			bool IMap.CanBuild(Vector2 buildingPosition, Vector2 buildingSize)
			{
				throw new System.NotImplementedException();
			}

			ISector IMap.GetSectorOnPosition(Vector3 position)
			{
				throw new System.NotImplementedException();
			}
		}

		public readonly SectorRessourceType WANTED_RESOURCE = SectorRessourceType.Food;
		public readonly Vector3 POSITION_IN_SECTOR_WITH_WANTED_RESOURCE = new Vector3(10, 0, 0);
		public readonly Vector3 POSITION_IN_SECTOR_WITH_DIFFERENT_RESOURCE = new Vector3(0, 0, 10);
		public readonly Vector3 POSITION_IN_SECTOR_WITHOUT_RESOURCE = new Vector3(10, 0, 10);
		public readonly Vector3 POSITION_NOT_IN_SECTOR = new Vector3(100, 0, 10);

		private IConstructionRule _rule = null;
		#endregion Fields

		#region Methods
		[SetUp]
		public void SetUp()
		{
			

			_rule = new OnlyConstructOnSpecificResourceTypeSector(WANTED_RESOURCE);
			new GameObject("Map").AddComponent<Dbug>
		}

		[Test]
		public void When_PositionNotInSector_Should_ReturnTrue()
		{
			Assert.IsFalse(_rule.CanConstruct(POSITION_NOT_IN_SECTOR));
		}

		[Test]
		public void When_PositionInSector_Without_Resource_Should_ReturnFalse()
		{
			Assert.IsFalse(_rule.CanConstruct(POSITION_IN_SECTOR_WITHOUT_RESOURCE));
		}

		[Test]
		public void When_PositionInSector_With_DifferentResource_Should_ReturnFalse()
		{
			Assert.IsFalse(_rule.CanConstruct(POSITION_IN_SECTOR_WITH_DIFFERENT_RESOURCE));
		}

		[Test]
		public void When_PositionInSector_With_WantedResource_Should_ReturnTrue()
		{
			Assert.IsTrue(_rule.CanConstruct(POSITION_IN_SECTOR_WITH_WANTED_RESOURCE));
		}
		#endregion Methods
	}
}