namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class GloryGemsManagerUI : MonoBehaviour
	{
		#region Fields
		[Title("Settings")]
		[SerializeField] private int _gemsCount = 11;
		[SerializeField] private int _maxGloryPerGem = 10;

		[Title("References")]
		[SerializeField] private GameObject _prefabGem = null;
		[SerializeField] private RectTransform _gemsParent = null;

		private GloryGemUI[] _gems = null;
		private IPlayerGloryWallet _playerGlory = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_playerGlory = Services.Instance.Get<IPlayerGloryWallet>();
		}

		private void Start()
		{
			InstantiateGems();
		}

		private void OnEnable()
		{
			_playerGlory.AmountChanged -= PlayerGloryChanged;
			_playerGlory.AmountChanged += PlayerGloryChanged;
		}

		private void OnDisable()
		{
			_playerGlory.AmountChanged -= PlayerGloryChanged;
		}

		private void InstantiateGems()
		{
			if (_gems != null) throw new System.NotSupportedException("Gems are already instanciated.");

			_gems = new GloryGemUI[_gemsCount];

			_gemsParent.DestroyChildren();

			for (int i = 0; i < _gemsCount; i++)
			{
				GloryGemUI gem = Instantiate(_prefabGem, _gemsParent).GetComponent<GloryGemUI>();
				gem.transform.localScale = Vector3.one;
				gem.GloryAmount = 0;
				gem.MaxGlory = _maxGloryPerGem;

				_gems[i] = gem;
			}

			UpdateGemsValue();
		}

		private void PlayerGloryChanged(object sender, GloryAmountChangedArgs e)
		{
			UpdateGemsValue();
		}

		private void UpdateGemsValue()
		{
			var notAssignedGlory = _playerGlory.GetAmount();

			for (int i = 0; i < _gemsCount; i++)
			{
				int gemGlory = Mathf.Min(notAssignedGlory, _maxGloryPerGem);
				notAssignedGlory -= gemGlory;

				_gems[i].GloryAmount = gemGlory;
			}
		}

		[Button]
		public void ShowCostPreview(int gloryCost)
		{
			int gemsCountForCost = GetGemsCountForCost(gloryCost);

			for (int i = 0; i < _gems.Length; i++)
			{
				bool showCostPreview = i < gemsCountForCost;

				GloryGemUI gem = _gems[i];
				gem.ShowCostPreview = showCostPreview;
			}
		}

		private int GetGemsCountForCost(int gloryCost)
		{
			float raw = (float)gloryCost / (float)_maxGloryPerGem;
			int ceiled = Mathf.CeilToInt(raw);
			return ceiled;
		}

		[Button]
		public void HideCostPreview()
		{
			foreach (var gem in _gems)
			{
				gem.ShowCostPreview = false;
			}
		}
		#endregion Methods
	}
}
