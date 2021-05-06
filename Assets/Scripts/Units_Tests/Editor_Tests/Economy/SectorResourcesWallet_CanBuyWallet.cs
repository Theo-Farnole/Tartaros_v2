namespace Tartaros.Tests.Economy
{
	using NUnit.Framework;
	using Tartaros.Economy;
	using UnityEngine.Assertions.Must;

	public class SectorResourcesWallet_CanBuyWallet
	{
		[Test]
		public void When_AllResourcesAreLesser_Should_ReturnTrue()
		{
			SectorResourcesWallet w1 = new SectorResourcesWallet(100, 100, 100);
			SectorResourcesWallet w2 = new SectorResourcesWallet(0, 0, 0);

			Assert.IsTrue(w1.CanBuy(w2));
		}

		[Test]
		public void When_AllResourcesAreEquals_Should_ReturnTrue()
		{
			SectorResourcesWallet w1 = new SectorResourcesWallet(100, 100, 100);
			SectorResourcesWallet w2 = new SectorResourcesWallet(100, 100, 100);

			Assert.IsTrue(w1.CanBuy(w2));
		}

		[Test]
		public void When_AllResourcesAreGreater_Should_ReturnFalse()
		{
			SectorResourcesWallet w1 = new SectorResourcesWallet(100, 100, 100);
			SectorResourcesWallet w2 = new SectorResourcesWallet(200, 200, 200);

			Assert.IsFalse(w1.CanBuy(w2));
		}

		[Test]
		public void When_OneResourceIsLesser_Should_ReturnTrue()
		{
			SectorResourcesWallet w1 = new SectorResourcesWallet(100, 100, 100);
			SectorResourcesWallet w2 = new SectorResourcesWallet(0, 0, 0);

			Assert.IsTrue(w1.CanBuy(w2));
		}

		[Test]
		public void When_OneResourceIsEquals_Should_ReturnTrue()
		{
			SectorResourcesWallet w1 = new SectorResourcesWallet(100, 100, 100);
			SectorResourcesWallet w2 = new SectorResourcesWallet(100, 0, 0);

			Assert.IsTrue(w1.CanBuy(w2));
		}

		[Test]
		public void When_OneResourceIsGreater_Should_ReturnFalse()
		{
			SectorResourcesWallet w1 = new SectorResourcesWallet(100, 100, 100);
			SectorResourcesWallet w2 = new SectorResourcesWallet(106, 0, 0);

			Assert.IsFalse(w1.CanBuy(w2));
		}
	}
}
