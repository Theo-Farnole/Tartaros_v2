namespace Tartaros.Tests
{
	using NUnit.Framework;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;

	public class EntityDetection_IsDetectionInRange_Tests
	{
		#region Fields
		private const int DETECTION_RANGE = 5;
		private readonly static Vector3 PLAYER_DETECTION_POSITION = Vector3.zero;
		private readonly static Vector3 IN_DETECTION_RANGE_POSITION = new Vector3(0, 0, 2);
		private readonly static Vector3 OUT_OF_DETECTION_RANGE_POSITION = new Vector3(0, 0, 10);

		private EntityDetection _playerDetection = null;
		#endregion Fields

		#region Methods
		[SetUp]
		public void SetUp()
		{
			SetupHelper.CreateService();
			SetupHelper.CreateEntitiesKDTree();

			Entity entity = SetupHelper.CreateEntity(PLAYER_DETECTION_POSITION, Team.Player, EntityType.Unit, "Player");
			_playerDetection = SetupHelper.AddDetectionBehaviour(entity, DETECTION_RANGE);
		}

		[Test]
		public void IsInDetectionRange_When_PointInRange_Should_ReturnTrue()
		{
			bool isInDetectionRange = _playerDetection.IsInDetectionRange(IN_DETECTION_RANGE_POSITION);
			Assert.IsTrue(isInDetectionRange);
		}

		[Test]
		public void IsInDetectionRange_When_PointOutOfRange_Should_ReturnFalse()
		{
			bool isInDetectionRange = _playerDetection.IsInDetectionRange(OUT_OF_DETECTION_RANGE_POSITION);
			Assert.IsFalse(isInDetectionRange);
		}

		[Test]
		public void IsInDetectionRange_When_EntityInRange_Should_ReturnTrue()
		{
			var otherEntity = SetupHelper.CreateEntity(IN_DETECTION_RANGE_POSITION, Team.Player, EntityType.Unit, "Other Entity");

			bool isInDetectionRange = _playerDetection.IsInDetectionRange(otherEntity);
			Assert.IsTrue(isInDetectionRange);
		}

		[Test]
		public void IsInDetectionRange_When_EntityOutOfRange_Should_ReturnFalse()
		{
			var otherEntity = SetupHelper.CreateEntity(OUT_OF_DETECTION_RANGE_POSITION, Team.Player, EntityType.Unit, "Other Entity");

			bool isInDetectionRange = _playerDetection.IsInDetectionRange(otherEntity);
			Assert.IsFalse(isInDetectionRange);
		}
		#endregion Methods
	}
}
