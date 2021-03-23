namespace Tartaros.UI
{
	using Tartaros.Construction;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Button))]
	public class ConstructButton : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Image _buildingPortrait = null;

		private IConstructable _toConstructOnClick = null;

		private ConstructionManager _constructionManager = null;
		private Button _button = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_button = GetComponent<Button>();
			_constructionManager = Services.Instance.Get<ConstructionManager>();
		}

		private void OnEnable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		public void Initialize(IConstructable toConstructOnClick)
		{
			_toConstructOnClick = toConstructOnClick;

			_buildingPortrait.sprite = _toConstructOnClick.Portrait;
		}

		private void OnButtonClick()
		{
			if (_toConstructOnClick == null) return;

			if (_constructionManager.CanEnterConstruction(_toConstructOnClick))
			{
				_constructionManager.EnterConstructionMode(_toConstructOnClick);
			}
		}
		#endregion Methods
	}
}