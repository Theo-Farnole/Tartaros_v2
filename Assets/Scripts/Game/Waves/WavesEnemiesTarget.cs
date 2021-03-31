namespace Tartaros.Wave
{
	using Tartaros.Entities;
	using UnityEngine;

	[RequireComponent(typeof(IAttackable))]
	public class WavesEnemiesTarget : MonoBehaviour
	{
		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "crosshair.png");
		}
	}
}
