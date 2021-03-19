namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using UnityEngine;

    public class Test_IspawnableData : IWaveSpawnableData
    {
        GameObject IWaveSpawnableData.Prefab => GameObject.CreatePrimitive(PrimitiveType.Capsule);
    }

}