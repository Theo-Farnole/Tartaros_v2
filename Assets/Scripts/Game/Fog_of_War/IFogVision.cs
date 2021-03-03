
namespace Tartaros.FogOfWar
{
    using UnityEngine;
    public interface IFogVision
    {
        bool IsPointVisible(Vector2 worldPoint);
        bool IsEnable();
    }
}