namespace Tartaros.Wave
{
	using System.Collections;
	using UnityEngine;
	using Tartaros;
	public class SpawnPoint : MonoBehaviour, ISpawnPoint
	{
		#region Fields
		[SerializeField]
		private float _randomRadius = 0;

		[SerializeField]
		private SpawnPointIdentifier _identifier;
		#endregion Fields

		#region Properties
		SpawnPointIdentifier ISpawnPoint.Identifier => _identifier;

		Vector3 ISpawnPoint.SpawnPoint => Random.insideUnitCircle.ToXZ() * _randomRadius + transform.position;
		#endregion Properties

		#region Methods
		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "skull-crossed-bones.png");
			Gizmos.DrawWireSphere(transform.position, _randomRadius);
		}
		#endregion Methods
	}
}