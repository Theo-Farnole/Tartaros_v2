namespace Tartaros.UI
{
	using Tartaros.Entities;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SelectionTemplePanel : APanel
	{
		#region Fields
		[SerializeField] private EntityData _templeData = null;
		[SerializeField] private SpawnButton[] _spawnButtons = null;

		private EntityUnitsSpawner _shownSpawner = null;
		private ISelection _selection = null;
		#endregion Fields

		#region Methods
		protected override void Awake()
		{
			base.Awake();

			_selection = Services.Instance.Get<CurrentSelection>();
		}

		private void OnEnable()
		{
			_selection.SelectionChanged -= SelectionChanged;
			_selection.SelectionChanged += SelectionChanged;
		}

		private void OnDisable()
		{
			_selection.SelectionChanged -= SelectionChanged;
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_selection.SelectedSelectables.Length == 1)
			{
				var selectedMonoBehaviour = (_selection.SelectedSelectables[0] as MonoBehaviour);

				if (selectedMonoBehaviour.TryGetComponent(out EntityUnitsSpawner unitsSpawner))
				{
					_shownSpawner = unitsSpawner;
					UpdatePanel();
				}
			}
		}

		private void UpdatePanel()
		{
			EntityUnitsSpawner unitsSpawner = _shownSpawner.GetComponentWithException<EntityUnitsSpawner>();

			ISpawnable[] spawnables = unitsSpawner.Spawnable;

			for (int i = 0, length = _spawnButtons.Length; i < length; i++)
			{
				if (i < spawnables.Length)
				{
					_spawnButtons[i].Construct(unitsSpawner, spawnables[i]);
				}
			}
		}
		#endregion Methods
	}
}
