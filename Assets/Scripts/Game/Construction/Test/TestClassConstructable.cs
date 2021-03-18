namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using UnityEngine;

	public class TestClassConstructable : MonoBehaviour, IConstructable
    {
        public GameObject _testCube = null;
        public ISectorResourcesWallet _price = null;

        GameObject IConstructable.ModelPrefab => _testCube;

        ISectorResourcesWallet IConstructable.Price => _price;
    }
}