namespace Tartaros.Tests.Performances
{
	using NUnit.Framework;
	using System.Diagnostics;
	using UnityEngine;

	public class DistanceSq_vs_Distance_Performances_Tests
	{
		private const int ITERATIONS_COUNT = 10000000;

		[Test]
		public void DistanceSq_Should_BeFaster_Than_Distance()
		{
			float distanceSq = GetDistanceSqElapsedMs();
			float distance = GetDistanceElapsedMs();

			UnityEngine.Debug.LogFormat("DistanceSq time is {0} | Distance time is {1}", distanceSq, distance);

			Assert.Less(distanceSq, distance);
		}

		private float GetDistanceSqElapsedMs()
		{
			Stopwatch sw = new Stopwatch();

			Vector3 p1 = Vector3.one * 5;
			Vector3 p2 = Vector3.up * -3;

			sw.Start();

			for (int i = 0; i < ITERATIONS_COUNT; i++)
			{
				MathHelper.DistanceSq(p1, p2);
			}

			sw.Stop();

			return sw.ElapsedMilliseconds;
		}

		private float GetDistanceElapsedMs()
		{
			Stopwatch sw = new Stopwatch();

			Vector3 p1 = Vector3.one * 5;
			Vector3 p2 = Vector3.up * -3;

			sw.Start();

			for (int i = 0; i < ITERATIONS_COUNT; i++)
			{
				Vector3.Distance(p1, p2);
			}

			sw.Stop();

			return sw.ElapsedMilliseconds;
		}
	}
}
