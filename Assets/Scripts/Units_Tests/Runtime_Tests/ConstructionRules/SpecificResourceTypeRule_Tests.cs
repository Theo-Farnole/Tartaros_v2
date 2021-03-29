namespace Tartaros.Tests
{
	using System.Collections;
	using UnityEngine;
	using NUnit.Framework;
	using Tartaros.Economy;
	using Tartaros.Map;
	using System.Collections.Generic;
	using Tartaros.Sectors;
	using UnityEngine.TestTools;
	using Tartaros.ServicesLocator;
	using Tartaros.Construction;

	public partial class SpecificResourceTypeRule_Tests
	{

		#region Fields

		public static readonly SectorRessourceType WANTED_RESOURCE = SectorRessourceType.Food;
		public static readonly SectorRessourceType UNWANTED_RESOURCE = SectorRessourceType.Stone;
		public static readonly Vector3 POSITION_IN_SECTOR_WITH_WANTED_RESOURCE = new Vector3(10, 0, 0);
		public static readonly Vector3 POSITION_IN_SECTOR_WITH_DIFFERENT_RESOURCE = new Vector3(0, 0, 10);
		public static readonly Vector3 POSITION_IN_SECTOR_WITHOUT_RESOURCE = new Vector3(10, 0, 10);
		public static readonly Vector3 POSITION_NOT_IN_SECTOR = new Vector3(100, 0, 10);

		private IConstructionRule _rule = null;
		private DebugMap _debugMap = null;
		#endregion Fields

		#region Methods
		[UnitySetUp]
		public IEnumerator SetUp()
		{
			Services services = SetupHelper.CreateService();

			_debugMap = new DebugMap(services, GenerateSectors());

			_rule = new OnlyConstructOnSpecificResourceTypeSector(WANTED_RESOURCE);

			yield return null;
		}

		[Test]
		public void When_PositionNotInSector_Should_ReturnTrue()
		{
			LogAssert.Expect(LogType.Error, OnlyConstructOnSpecificResourceTypeSector.BuildErrorMessage_NoSectorFoundAtPosition(POSITION_NOT_IN_SECTOR));
			Assert.IsTrue(_rule.CanConstruct(POSITION_NOT_IN_SECTOR));
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

		private static Dictionary<Vector3, ISector> GenerateSectors()
		{
			return new Dictionary<Vector3, ISector>()
			{
				{ POSITION_IN_SECTOR_WITH_WANTED_RESOURCE, new DebugResourceSector(WANTED_RESOURCE) },
				{ POSITION_IN_SECTOR_WITH_DIFFERENT_RESOURCE, new DebugResourceSector(UNWANTED_RESOURCE) },
				{ POSITION_IN_SECTOR_WITHOUT_RESOURCE, new DebugResourceSector(UNWANTED_RESOURCE) }
			};
		}
		#endregion Methods
	}
}