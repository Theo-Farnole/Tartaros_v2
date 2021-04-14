namespace Tartaros.UI
{
	using System.Collections.Generic;
	using Tartaros.Construction;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class ConstructButtonsUIPanel : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private GameObject _constructButtonPrefab = null;

		[SerializeField]
		private RectTransform _constructButtonRoot = null;

		private ConstructionManagerData _constructionManagerData = null;
		private ConstructionManager _constructionManager = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_constructionManager = Services.Instance.Get<ConstructionManager>();
		}

		private void Start()
		{
			_constructionManagerData = _constructionManager.ConstructionManagerData;

			BuildUI();
		}

		void BuildUI()
		{
			RemoveConstructButtonInRoot();

			foreach (IConstructable constructable in _constructionManagerData.Constructables)
			{
				GameObject button = Instantiate(_constructButtonPrefab);
				button.transform.SetParent(_constructButtonRoot);
				button.transform.localScale = Vector3.one;

				button.GetComponent<ConstructButton>().Initialize(constructable);
			}
		}

		void RemoveConstructButtonInRoot()
		{
			foreach (var constructButton in GetConstructButtonsInRoot())
			{
				GameObject.Destroy(constructButton.gameObject);
			}
		}

		ConstructButton[] GetConstructButtonsInRoot()
		{
			List<ConstructButton> output = new List<ConstructButton>();

			for (int i = 0; i < _constructButtonRoot.transform.childCount; i++)
			{
				var child = _constructButtonRoot.transform.GetChild(i);

				if (child.TryGetComponent(out ConstructButton constructButton))
				{
					output.Add(constructButton);
				}
			}

			return output.ToArray();
		}
		#endregion Methods
	}
}
