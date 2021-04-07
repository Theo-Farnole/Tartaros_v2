namespace Tartaros.Wave
{
	using Tartaros.ServicesLocator;
	using TF.CheatsGUI;
	using UnityEngine;

	public static class EnemiesWavesManagerCheats
	{
		[Cheat]
		public static void StartWave()
		{
			GameObject.FindObjectOfType<EnemiesWavesManager>().StartNewWave();
		}
	}
}
