namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Entities;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class UISelectionPanelShowManager : MonoBehaviour
	{
		#region Fields
		[Title("Panels References")]
		[SerializeField] private SelectionTemplePanel _selectionTemplePanel = null;
		[SerializeField] private OneSelectedPanel _oneSelectedPanel = null;

		[Title("Data ")]
		[SerializeField] private EntityData _templeData = null;

		private ISelection _selection = null;
		#endregion Fields

		// SectorWithResourcesSelectedPanel
		// MultiEntitiesSleectedPanel

		#region Methods
		private void Awake()
		{
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
			if (_selection.SelectedSelectables.Length == 0)
			{
				_selectionTemplePanel.Hide();
				_oneSelectedPanel.Hide();
			}
			else if (_selection.SelectedSelectables.Length == 1)
			{
				MonoBehaviour monoBehaviour = _selection.SelectedSelectables[0] as MonoBehaviour;

				if (monoBehaviour.TryGetComponent(out Entity entity))
				{
					if (entity.EntityData == _templeData)
					{
						_selectionTemplePanel.Show();
					}
					else
					{
						_oneSelectedPanel.Show();
					}
				}
			}
		}
		#endregion Methods
	}
}