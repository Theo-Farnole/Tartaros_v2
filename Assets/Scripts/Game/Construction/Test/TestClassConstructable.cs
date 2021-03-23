namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using Tartaros.UI;
	using UnityEngine;

	public class TestClassConstructable : MonoBehaviour, IConstructable
    {
        public GameObject _testCube = null;
        public ISectorResourcesWallet _price = null;
		public Vector2 _size = Vector2.one;

        GameObject IConstructable.ModelPrefab => _testCube;

        ISectorResourcesWallet IConstructable.Price => _price;

		Vector2 IConstructable.Size => _size;

		Sprite IPortraiteable.Portrait => null;
	}
}