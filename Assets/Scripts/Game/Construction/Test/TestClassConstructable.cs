namespace Tartaros.Construction
{
    using System.Collections;
    using UnityEngine;
    using Tartaros.Construction;
    using Tartaros.Economy;

    public class TestClassConstructable : MonoBehaviour, IConstructable
    {
        public GameObject _testCube = null;
        public Price _price = null;

        GameObject IConstructable.ModelPrefab => _testCube;

        Price IConstructable.price => _price;
    }
}