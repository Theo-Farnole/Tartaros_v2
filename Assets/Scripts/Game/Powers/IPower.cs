
namespace Tartaros.Power
{
    using UnityEngine;
    public interface IPower
    {
        float range { get; }
        int price { get; }

        GameObject prefabPower { get; }
        void Cast();
    }
}