namespace Tartaros.UI.MiniMap
{
    using UnityEngine;
    public interface IMiniMapPolygon
    {
        Vector3 Polygon { get; }
        Color Color { get; }
    }
}