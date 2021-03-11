namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;
	using UnityEngine.TestTools;

	public class EntityDetection_IsInAttackRange_Tests
	{
		#region Fields
		private const int ATTACK_RANGE = 5;
		private const int DETECTION_RANGE = 7;
		private readonly static Vector3 PLAYER_DETECTION_POSITION = Vector3.zero;
		private readonly static Vector3 IN_DETECTION_RANGE_POSITION = new Vector3(0, 0, 2);
		private readonly static Vector3 OUT_OF_DETECTION_RANGE_POSITION = new Vector3(0, 0, 10);

		private EntityDetection _playerDetection = null;
		#endregion Fields

		#region Methods
		[UnitySetUp]
		public IEnumerator SetUp()
		{
			LogAssert.ignoreFailingMessages = true;

			SetupHelper.CreateService();
			SetupHelper.CreateEntitiesKDTree();

			Entity entity = SetupHelper.CreateEntity(PLAYER_DETECTION_POSITION, Team.Player, EntityType.Unit, "Player");
			SetupHelper.AddAttackBehaviour(entity, ATTACK_RANGE);
			_playerDetection = SetupHelper.AddDetectionBehaviour(entity, DETECTION_RANGE);

			yield return null;
		}

		[TearDown]
		public void TearDown()
		{
			LogAssert.ignoreFailingMessages = false;
		}

		[Test]
		public void When_PointInRange_Should_ReturnTrue()
		{
			Assert.IsTrue(_playerDetection.IsInAttackRange(IN_DETECTION_RANGE_POSITION));
		}

		[Test]
		public void When_PointOutOfRange_Should_ReturnFalse()
		{
			Assert.IsFalse(_playerDetection.IsInAttackRange(OUT_OF_DETECTION_RANGE_POSITION));
		}

		[Test]
		public void When_EntityInRange_Should_ReturnTrue()
		{
			var otherEntity = SetupHelper.CreateEntity(IN_DETECTION_RANGE_POSITION, Team.Player, EntityType.Unit, "Other Entity");

			Assert.IsTrue(_playerDetection.IsInAttackRange(otherEntity));
		}

		[Test]
		public void When_EntityOutOfRange_Should_ReturnFalse()
		{
			var otherEntity = SetupHelper.CreateEntity(OUT_OF_DETECTION_RANGE_POSITION, Team.Player, EntityType.Unit, "Other Entity");

			Assert.IsFalse(_playerDetection.IsInAttackRange(otherEntity));
		}
		#endregion Methods
	}
}
