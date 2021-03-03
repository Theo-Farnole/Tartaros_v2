namespace Tartaros.Sectors
{
    using UnityEngine;
    using Tartaros.Utilities;
    public interface IMap
    {
        Bounds1D MapBounds { get; }
        bool CanBuild(Vector2 buildingPosition, Vector2 buildingSize);
    }
}