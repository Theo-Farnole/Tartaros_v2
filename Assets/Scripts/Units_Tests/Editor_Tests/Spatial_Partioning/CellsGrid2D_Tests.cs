namespace Tartaros.Tests
{
	using NUnit.Framework;
	using UnityEngine;

	public class CellsGrid2D_Tests
	{
		[Test]
		public void When_Prewarm_Should_CreateCell()
		{
			const int CELL_SIZE = 1;
			const int PREWARM_LENGTH = 3; // 3*3 should create 9 
			var cellsGrid2D = new CellsGrid2D<object>(CELL_SIZE, PREWARM_LENGTH);

			Assert.AreEqual(9, cellsGrid2D.AllCells.Length);
		}


		[Test]
		public void When_Prewarm_Should_NotCreateNegativeCell()
		{
			const int CELL_SIZE = 1;
			const int PREWARM_LENGTH = 3; // 3*3 should create 9 
			var cellsGrid2D = new CellsGrid2D<object>(CELL_SIZE, PREWARM_LENGTH);

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
			var cellsGrid2D = new CellsGrid2D<object>(CELL_SIZE, PREWARM_LENGTH);

			var cellsInRadius = cellsGrid2D.GetCellsInRadius(new Vector3(2.5f, 0, 2.5f), 1);

			Assert.AreEqual(9, cellsInRadius.Length);
		}

		[Test]
		public void When_GetCoordsFromWorldPosition_Should_ReturnCorrectCoords()
		{
			const int CELL_SIZE = 2;
			var cellsGrid2D = new CellsGrid2D<object>(CELL_SIZE);

			Vector3 worldPosition = new Vector3(3.5f, 0, 3.5f);
			Vector2 expectedCoords = Vector2.one * 2;
			var actualCoords = cellsGrid2D.GetCoordsFromWorldPosition(worldPosition);

			Assert.AreEqual(expectedCoords, actualCoords);
		}
	}
}
