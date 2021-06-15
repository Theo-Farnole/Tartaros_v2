namespace Tartaros.Wave
{
    using UnityEngine;
	using UnityEngine.AI;

	public interface ISpawnPoint
    {
        SpawnPointIdentifier Identifier { get; }
        Vector3 TransformPoint { get; }
        Vector3 SpawnPoint { get; }
        Vector3[] Waypoints { get; }
        NavMeshPath[] NavPaths { get; }
    }
}