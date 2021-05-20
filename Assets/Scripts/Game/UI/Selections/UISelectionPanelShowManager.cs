namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.Map;
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
			MultipleEntities,
			Sector
		}
		#endregion Enums

		#region Fields
		[Title("Panels References")]
		[SerializeField] private SelectionTemplePanel _selectionTemplePanel = null;
		[SerializeField] private OneSelectedPanel _oneSelectedPanel = null;
		[SerializeField] private MultiEntitiesSelectedPanel _multiEntitiesSelectedPanel = null;
		[SerializeField] private SectorSelectedPanel _sectorPanel = null;

		[Title("Data ")]
		[SerializeField] private EntityData _templeData = null;

		private ISelection _selection = null;

		private Dictionary<SelectionPanel, APanel> _panels = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_selection = Services.Instance.Get<CurrentSelection>();
			_panels = new Dictionary<SelectionPanel, APanel>()
			{
				{ SelectionPanel.Temple, _selectionTemplePanel },
				{ SelectionPanel.OneEntity, _oneSelectedPanel },
				{ SelectionPanel.MultipleEntities, _multiEntitiesSelectedPanel},
				{ SelectionPanel.Sector, _sectorPanel },
			};
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
			if (_selection.ObjectsCount == 1)
			{
				MonoBehaviour monoBehaviour = _selection.Objects[0] as MonoBehaviour;

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
				else if (monoBehaviour.TryGetComponent(out ISector sector))
				{
					ShowPanelAndHideOthers(SelectionPanel.Sector);
				}
			}
			else if (_selection.ObjectsCount > 1)
			{
				ShowPanelAndHideOthers(SelectionPanel.MultipleEntities);
			}
		}

		private void ShowPanelAndHideOthers(SelectionPanel panelToShow)
		{
			foreach (var kvp in _panels)
			{
				if (kvp.Key == panelToShow)
				{
					kvp.Value.Show();
				}
				else
				{
					kvp.Value.Hide();
				}
			}
		}
		#endregion Methods
	}
}