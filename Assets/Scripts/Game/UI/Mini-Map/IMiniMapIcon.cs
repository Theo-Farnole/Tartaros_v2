namespace Tartaros.UI.MiniMap
{
    using UnityEngine;
    public interface IMiniMapIcon
    {
        Vector3 WorldPosition { get; }

        Sprite Icon { get; }
    }
}