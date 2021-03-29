namespace Tartaros.Tests
{
	using NUnit.Framework;
	using Tartaros.Map;
	using UnityEngine;

	public class NeightborsSectors_Tests
	{
		#region Fields
		private Sector _sector1 = null;
		private Sector _sector2 = null;
		#endregion Fields

		#region Methods
		[Test]
		public void When_SectorsShareNoVertex_Should_ReturnFalse()
		{
			// arrange
			_sector1 = new GameObject("Sector 1").AddComponent<Sector>();
			_sector2 = new GameObject("Sector 2").AddComponent<Sector>();

			// act
			Vertex2D sharedVertex = new Vertex2D(Vector2.one);

			_sector1.SectorData = new SectorData(
				new Vertex2D(Vector2.one),
				new Vertex2D(Vector2.up),
				new Vertex2D(Vector2.zero),
				new Vertex2D(Vector2.right)
			);

			_sector2.SectorData = new SectorData(
				new Vertex2D(5, 0, 0),
				new Vertex2D(5, 5, 0),
				new Vertex2D(0, 5, 0),
				new Vertex2D(5, 0, 0)
			);

			// assert
			Assert.IsFalse(_sector1.IsSectorNeightborOf(_sector2));
		}

		[Test]
		public void When_SectorsShareOneVertex_Should_ReturnFalse()
		{
			// arrange
			_sector1 = new GameObject("Sector 1").AddComponent<Sector>();
			_sector2 = new GameObject("Sector 2").AddComponent<Sector>();

			// act
			Vertex2D sharedVertex = new Vertex2D(Vector2.one);

			_sector1.SectorData = new SectorData(
				sharedVertex,
				new Vertex2D(Vector2.up),
				new Vertex2D(Vector2.zero),
				new Vertex2D(Vector2.right)
			);

			_sector2.SectorData = new SectorData(
				sharedVertex,
				new Vertex2D(2, 1, 0),
				new Vertex2D(2, 2, 0),
				new Vertex2D(1, 2, 0)
			);

			// assert
			Assert.IsFalse(_sector1.IsSectorNeightborOf(_sector2));
		}

		[Test]
		public void When_SectorsShareTwoVertex_Should_ReturnTrue()
		{
			// arrange
			_sector1 = new GameObject("Sector 1").AddComponent<Sector>();
			_sector2 = new GameObject("Sector 2").AddComponent<Sector>();

			// act
			Vertex2D sharedVertex = new Vertex2D(Vector2.one);
			Vertex2D sharedVertex2 = new Vertex2D(Vector2.right);

			_sector1.SectorData = new SectorData(
				sharedVertex,
				sharedVertex2,
				new Vertex2D(Vector2.zero),
				new Vertex2D(Vector2.up)
			);

			_sector2.SectorData = new SectorData(
				sharedVertex,
				sharedVertex2,
				new Vertex2D(2, 0, 0),
				new Vertex2D(2, 1, 0)
			);

			// assert
			Assert.IsTrue(_sector1.IsSectorNeightborOf(_sector2));
		}
		#endregion Methods
	}
}