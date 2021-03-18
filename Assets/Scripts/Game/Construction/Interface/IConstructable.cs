
namespace Tartaros.Construction
{
    using Tartaros.Economy;
    using UnityEngine;

    public interface IConstructable
    {
        GameObject ModelPrefab { get; }
        ISectorResourcesWallet Price { get; }
    }
}