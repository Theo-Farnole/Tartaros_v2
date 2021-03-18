namespace Tartaros.UI
{
	using Tartaros.Construction;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class ConstructButtonsUIManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private GameObject _constructButtonPrefab = null;

		[SerializeField]
		private RectTransform _constructButtonRoot = null;

		private ConstructionManagerData _constructionManagerData = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			var constructionManager = Services.Instance.Get<ConstructionManager>();
			_constructionManagerData = constructionManager.ConstructionManagerData;

			BuildUI();
		}

		void BuildUI()
		{
			foreach (IConstructable constructable in _constructionManagerData.Constructables)
			{
				GameObject button = Instantiate(_constructButtonPrefab);
				button.transform.SetParent(_constructButtonRoot);
				button.transform.localScale = Vector3.one;

				button.GetComponent<ConstructButton>().Initialize(constructable);
			}
		}
		#endregion Methods
	}
}
