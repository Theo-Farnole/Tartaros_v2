namespace Tartaros.Selection
{
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class CurrentSelection : MonoBehaviour, ISelection
	{
		#region Fields
		[SerializeField]
		private Team _selectableTeam = Team.Player;

		List<ISelectable> _selectedObjets = new List<ISelectable>();
		#endregion Fields

		#region Properties
		ISelectable[] ISelection.SelectedSelectables => _selectedObjets.ToArray();
		#endregion Properties

		#region Methods
		void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		void ISelection.AddToSelection(ISelectable selectable)
		{
			if ((this as ISelection).IsSelected(selectable) == true)
			{
				Debug.LogErrorFormat("Error while trying to add to selection: selectable \"{0}\" is already in selection.", GetSelectableName(selectable));
				return;
			}

			if (DoSelectableBelongToSelectableTeam(selectable) == false) return;

			_selectedObjets.Add(selectable);
			selectable.OnSelected();
		}

		void ISelection.AddToSelection(ISelectable[] selectables)
		{
			if (selectables == null) return;

			foreach (ISelectable selectable in selectables)
			{
				(this as ISelection).AddToSelection(selectable);
			}
		}

		void ISelection.RemoveFromSelection(ISelectable selectable)
		{
			if ((this as ISelection).IsSelected(selectable) == false)
			{
				Debug.LogErrorFormat("Error while trying to remove from selection: selectable \"{0}\" is not in selection.", GetSelectableName(selectable));
				return;
			}

			if (DoSelectableBelongToSelectableTeam(selectable) == false) return;

			_selectedObjets.Remove(selectable);
			selectable.OnUnselected();
		}

		void ISelection.ClearSelection()
		{
			for (int i = _selectedObjets.Count - 1; i >= 0; i--)
			{
				(this as ISelection).RemoveFromSelection(_selectedObjets[i]);
			}
		}

		bool ISelection.IsSelected(ISelectable selectable)
		{
			return _selectedObjets.Contains(selectable);
		}

		void ISelection.AlternateSelection(ISelectable selectable)
		{
			var selfSelection = this as ISelection;

			if (selfSelection.IsSelected(selectable))
			{
				selfSelection.RemoveFromSelection(selectable);
			}
			else
			{
				selfSelection.AddToSelection(selectable);
			}
		}

		private string GetSelectableName(ISelectable selectable)
		{
			return selectable is MonoBehaviour obj ? obj.name : selectable.ToString();
		}

		private bool DoSelectableBelongToSelectableTeam(ISelectable selectable)
		{
			return _selectableTeam == selectable.Team;
		}
		#endregion Methods
	}
}
