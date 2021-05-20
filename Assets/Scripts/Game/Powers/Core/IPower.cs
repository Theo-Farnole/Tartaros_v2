
namespace Tartaros.Powers
{
    using UnityEngine;

    public interface IPower
    {
        float Range { get; }
        int Price { get; }

        GameObject PrefabPower { get; }
    }
}