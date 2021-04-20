namespace Tartaros.Construction
{
	using Tartaros.Economy;
	using Tartaros.UI;
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class TestClassConstructable : SerializedMonoBehaviour, IConstructable
	{
		public GameObject _testCube = null;
		public GameObject _gameplayPrefab = null;
		public ISectorResourcesWallet _price = null;
		public Vector2 _size = Vector2.one;
		public bool _isWall = false;


		GameObject IConstructable.PreviewPrefab => _testCube;

		ISectorResourcesWallet IConstructable.Price => _price;

		Vector2 IConstructable.Size => _size;

		Sprite IPortraiteable.Portrait => null;

		IConstructionRule[] IConstructable.Rules => null;

		bool IConstructable.IsWall => _isWall;

		GameObject IConstructable.GameplayPrefab => _gameplayPrefab;

		GameObject IConstructable.WallCornerModel => throw new System.NotImplementedException();

		GameObject IConstructable.WallCornerGameplay => throw new System.NotImplementedException();

		GameObject IConstructable.ConstructionKitModel => throw new System.NotImplementedException();

		int IConstructable.TimeToConstruct => throw new System.NotImplementedException();
	}
}