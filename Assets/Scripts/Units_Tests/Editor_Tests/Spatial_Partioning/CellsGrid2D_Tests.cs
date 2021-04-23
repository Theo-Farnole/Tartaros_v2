namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System.Linq;
	using UnityEngine;

	internal class TestCell
	{
		public TestCell(Vector2 coords, CellsGrid2D<TestCell> grid)
		{

		}
	}

	public class CellsGrid2D_Tests
	{


		[Test]
		public void When_Prewarm_Should_CreateCell()
		{
			const int CELL_SIZE = 1;
			const int PREWARM_LENGTH = 3; // 3*3 should create 9 
			var cellsGrid2D = new CellsGrid2D<TestCell>(CELL_SIZE, PREWARM_LENGTH);

			Assert.AreEqual(9, cellsGrid2D.AllCells.Length);
		}


		[Test]
		public void When_Prewarm_Should_NotCreateNegativeCell()
		{
			const int CELL_SIZE = 1;
			const int PREWARM_LENGTH = 3; // 3*3 should create 9 
			var cellsGrid2D = new CellsGrid2D<TestCell>(CELL_SIZE, PREWARM_LENGTH);

			var negativeWorldPosition = new Vector3(-0.5f, 0, -0.5f);
			cellsGrid2D.GetCellAtWorldPosition(negativeWorldPosition); // create a cell if it doesn't exists


			// prewarm create 9 cells (3x3)
			// if we query a cell in negative position, it should create it
			// so we have 10 cells
			Assert.AreEqual(10, cellsGrid2D.AllCells.Length);
		}

		[Test]
		public void When_GetCellsInRadius_While_CellSizeIsOne_Should_Return_NineCells()
		{
			const int CELL_SIZE = 1;
			const int PREWARM_LENGTH = 5; // 3*3 should create 9 
			const int RADIUS = 1;
			var cellsGrid2D = new CellsGrid2D<TestCell>(CELL_SIZE, PREWARM_LENGTH);

			Vector3 center = new Vector3(2.5f, 0, 2.5f);
			var cellsInRadius = cellsGrid2D.GetCellsInRadius(center, RADIUS);

			Assert.AreEqual(9, cellsInRadius.Count());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.left * RADIUS), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.left * RADIUS + Vector3.forward * RADIUS), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.forward * RADIUS), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.right * RADIUS + Vector3.forward * RADIUS), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.right * RADIUS), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.right * RADIUS + Vector3.back * RADIUS), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.back * RADIUS), cellsInRadius.ToArray());
			Assert.Contains(cellsGrid2D.GetCellAtWorldPosition(center + Vector3.left * RADIUS + Vector3.back * RADIUS), cellsInRadius.ToArray());
		}

		[Test]
		public void When_GetCoordsFromWorldPosition_Should_ReturnCorrectCoords()
		{
			const int CELL_SIZE = 2;
			var cellsGrid2D = new CellsGrid2D<TestCell>(CELL_SIZE);

			Vector3 worldPosition = new Vector3(3.5f, 0, 3.5f);
			Vector2 expectedCoords = Vector2.one * 2;
			var actualCoords = cellsGrid2D.GetCoordsFromWorldPosition(worldPosition);

			Assert.AreEqual(expectedCoords, actualCoords);
		}
	}
}
