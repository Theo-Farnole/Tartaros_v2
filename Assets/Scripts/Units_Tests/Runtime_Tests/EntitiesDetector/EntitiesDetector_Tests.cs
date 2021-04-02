namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System.Collections;
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;
	using UnityEngine.TestTools;

	public class EntitiesDetector_Tests
	{
		#region Fields
		private const int DETECTOR_RADIUS = 5;
		private EntitiesKDTrees _entitiesDetector = null;
		#endregion Fields

		#region Methods
		[UnitySetUp]
		public IEnumerator SetUp()
		{
			LogAssert.ignoreFailingMessages = true;

			//SetupHelper.CreateService();
			_entitiesDetector = SetupHelper.CreateEntitiesKDTree();

			yield return null;
		}

		[Test]
		public void When_EntitiesInRange_Should_ReturnEntities()
		{
			Entity[] entitiesInRadius = SpawnEntitiesInRadius();

			Entity[] output = _entitiesDetector.GetEveryEntityInRadius(Team.Player, Vector3.zero, DETECTOR_RADIUS);

			foreach (Entity entityInRadius in entitiesInRadius)
			{
				Assert.IsTrue(output.Contains(entityInRadius));
			}
		}

		[Test]
		public void When_EntitiesNoInScene_Should_ReturnEmpty()
		{
			Entity[] output = _entitiesDetector.GetEveryEntityInRadius(Team.Player, Vector3.zero, DETECTOR_RADIUS);

			Assert.AreEqual(0, output.Length);
		}

		[Test]
		public void When_EntitiesNotInRange_Should_ReturnEmpty()
		{
			SpawnEntitiesNotInRadius();

			Entity[] output = _entitiesDetector.GetEveryEntityInRadius(Team.Player, Vector3.zero, DETECTOR_RADIUS);

			Assert.AreEqual(0, output.Length);
		}

		[Test]
		public void When_SomeEntitiesInAndSomeOutRange_Should_ReturnEntitiesInRadius()
		{
			Entity[] entitiesInRadius = SpawnEntitiesInRadius();
			Entity[] entitiesNotInRadius = SpawnEntitiesNotInRadius();

			Entity[] output = _entitiesDetector.GetEveryEntityInRadius(Team.Player, Vector3.zero, DETECTOR_RADIUS);

			foreach (Entity entityInRadius in entitiesInRadius)
			{
				Assert.IsTrue(output.Contains(entityInRadius));
			}

			foreach (Entity entityOutRadius in entitiesNotInRadius)
			{
				Assert.IsFalse(output.Contains(entityOutRadius));
			}
		}

		private static Entity[] SpawnEntitiesNotInRadius()
		{
			return new Entity[]
			{
				SetupHelper.CreateEntity(new Vector3(15, 0, 50), Team.Player, EntityType.Unit),
				SetupHelper.CreateEntity(new Vector3(60, 0, 20), Team.Player, EntityType.Unit),
				SetupHelper.CreateEntity(new Vector3(30, 0, 40), Team.Player, EntityType.Unit)
			};
		}

		private static Entity[] SpawnEntitiesInRadius()
		{
			return new Entity[]
			{
				SetupHelper.CreateEntity(Vector3.one, Team.Player, EntityType.Unit),
				SetupHelper.CreateEntity(Vector3.one, Team.Player, EntityType.Unit),
				SetupHelper.CreateEntity(Vector3.one, Team.Player, EntityType.Unit)
			};
		}
		#endregion Methods
	}
}
