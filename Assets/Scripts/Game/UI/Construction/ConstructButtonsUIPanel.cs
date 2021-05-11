namespace Tartaros.UI
{
	using System.Collections.Generic;
	using Tartaros.Construction;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class ConstructButtonsUIPanel : MonoBehaviour
	{
		#region Fields
		[SerializeField] private int _constructionSlotsCount = 4;

		[SerializeField] private GameObject _constructButtonPrefab = null;
		[SerializeField] private GameObject _constructButtonLockedPrefab = null;

		[SerializeField] private RectTransform _constructButtonRoot = null;

		private ConstructionManagerData _constructionManagerData = null;
		private ConstructionManager _constructionManager = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_constructionManager = Services.Instance.Get<ConstructionManager>();
			_constructionManagerData = _constructionManager.ConstructionManagerData;
		}

		private void Start()
		{
			BuildUI();

			if (_constructionManagerData.Constructables.Length > _constructionSlotsCount)
			{
				Debug.LogWarning("There is more constructables to display than available construction slot.");
			}
		}

		void BuildUI()
		{
			RemoveConstructButtonInRoot();

			IConstructable[] constructables = _constructionManagerData.Constructables;

			for (int i = 0; i < _constructionSlotsCount; i++)
			{
				GameObject button = InstantiateButton(i);

				button.transform.SetParent(_constructButtonRoot);
				button.transform.localScale = Vector3.one;
			}

			GameObject InstantiateButton(int i)
			{
				if (i < constructables.Length)
				{
					GameObject button = Instantiate(_constructButtonPrefab);
					button.GetComponent<ConstructButton>().Initialize(constructables[i]);

					return button;
				}
				else
				{
					return Instantiate(_constructButtonLockedPrefab);
				}
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
