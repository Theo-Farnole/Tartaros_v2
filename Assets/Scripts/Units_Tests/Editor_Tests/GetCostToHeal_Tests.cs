namespace Tartaros.Tests.Entities
{
	using NUnit.Framework;
	using Tartaros.Economy;
	using Tartaros.Entities;

	public class GetCostToHeal_Tests
	{
		[Test]
		public void Test_Calculation_01()
		{
			EntityHealWithCostData data = new EntityHealWithCostData(new SectorResourcesWallet(10, 0, 0));

			var expectedCost = new SectorResourcesWallet(1, 0, 0);
			var actualCost = data.GetCostToHeal(5, 100);

			Assert.AreEqual(expectedCost, actualCost);
		}

		[Test]
		public void Test_Calculation_02()
		{
			EntityHealWithCostData data = new EntityHealWithCostData(new SectorResourcesWallet(0, 50, 50));

			var expectedCost = new SectorResourcesWallet(0, 40, 40);
			var actualCost = data.GetCostToHeal(8, 10);

			Assert.AreEqual(expectedCost, actualCost);
		}
	}
}
