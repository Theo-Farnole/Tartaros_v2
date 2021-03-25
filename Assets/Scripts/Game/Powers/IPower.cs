
namespace Tartaros.Power
{
    using UnityEngine;
    public interface IPower
    {
        float range { get; }

        GameObject prefabPower { get; }
        void Cast();
    }
}