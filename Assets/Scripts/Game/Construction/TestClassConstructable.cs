namespace Tartaros.Construction
{
    using System.Collections;
    using UnityEngine;
    using Tartaros.Construction;

    public class TestClassConstructable : MonoBehaviour, IConstructable
    {
        public GameObject _testCube = null;

        GameObject IConstructable.ModelPrefab => _testCube;
    }
}