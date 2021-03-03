namespace Tartaros.FogOfWar
{
    using UnityEngine;
    public interface IFogCoverable
    {
        bool IsCovered { get; }

        Rect GetWorldVolume();
    }
}