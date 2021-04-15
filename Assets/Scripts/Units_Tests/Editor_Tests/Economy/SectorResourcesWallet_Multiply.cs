namespace Tartaros.Tests.Economy
{
	using NUnit.Framework;
	using Tartaros.Economy;

	public class SectorResourcesWallet_Multiply
	{
		[Test]
		public void Test_Calculation_01()
		{
			SectorResourcesWallet expected = new SectorResourcesWallet(0, 0, 2);
			const float multiplicator = 2;

			SectorResourcesWallet wallet = new SectorResourcesWallet(0, 0, 1);

			ISectorResourcesWallet actual = ISectorResourcesWalletMath.Multiply(wallet, multiplicator);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_Calculation_02()
		{
			SectorResourcesWallet expected = new SectorResourcesWallet(0, 0, 5);
			const float multiplicator = 0.5f;

			SectorResourcesWallet wallet = new SectorResourcesWallet(0, 0, 10);

			ISectorResourcesWallet actual = ISectorResourcesWalletMath.Multiply(wallet, multiplicator);
			Assert.AreEqual(expected, actual);
		}
	}
}
