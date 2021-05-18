namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Entities;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class UISelectionPanelShowManager : MonoBehaviour
	{
		#region Enums
		public enum SelectionPanel
		{
			None,
			Temple,
			OneEntity,
			MultipleEntities
		}
		#endregion Enums

		#region Fields
		[Title("Panels References")]
		[SerializeField] private SelectionTemplePanel _selectionTemplePanel = null;
		[SerializeField] private OneSelectedPanel _oneSelectedPanel = null;
		[SerializeField] private MultiEntitiesSelectedPanel _multiEntitiesSelectedPanel = null;

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
			if (_selection.SelectedSelectables.Length == 1)
			{
				MonoBehaviour monoBehaviour = _selection.SelectedSelectables[0] as MonoBehaviour;

				if (monoBehaviour.TryGetComponent(out Entity entity))
				{
					if (entity.EntityData == _templeData)
					{
						ShowPanelAndHideOthers(SelectionPanel.Temple);
					}
					else
					{
						ShowPanelAndHideOthers(SelectionPanel.OneEntity);
					}
				}
			}
			else if (_selection.SelectedSelectables.Length > 1)
			{
				ShowPanelAndHideOthers(SelectionPanel.MultipleEntities);
			}
		}

		private void ShowPanelAndHideOthers(SelectionPanel panelToShow)
		{
			ManageActivation(_oneSelectedPanel, SelectionPanel.OneEntity);
			ManageActivation(_selectionTemplePanel, SelectionPanel.Temple);
			ManageActivation(_multiEntitiesSelectedPanel, SelectionPanel.MultipleEntities);

			void ManageActivation(APanel panel, SelectionPanel associatedPanel)
			{
				if (panelToShow == associatedPanel)
				{
					panel.Show();
				}
				else
				{
					panel.Hide();
				}
			}
		}
		#endregion Methods
	}
}