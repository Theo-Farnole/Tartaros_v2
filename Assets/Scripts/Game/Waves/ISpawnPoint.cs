namespace Tartaros.Wave
{
    using UnityEngine;

    public interface ISpawnPoint
    {
        SpawnPointIdentifier Identifier { get; }
        Vector3 SpawnPoint { get; }
    }
}